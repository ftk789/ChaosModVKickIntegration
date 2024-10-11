﻿using Serilog;
using Shared;
using TwitchChatVotingProxy.ChaosPipe;
using TwitchChatVotingProxy.OverlayServer;
using TwitchChatVotingProxy.VotingReceiver;

namespace TwitchChatVotingProxy
{
    class TwitchChatVotingProxy
    {
        private static readonly ILogger m_Logger = Log.Logger.ForContext<TwitchChatVotingProxy>();

        private static async Task Main(string[] args)
        {
            if (args.Length < 1 || args[0] != "--startProxy")
            {
                Console.WriteLine("Please don'tt start the voting proxy process manually as it's only supposed to be launched by the mod itself."
                    + "\nPass --startProxy as an argument if you want to start the proxy yourself for debugging purposes.");

                Console.ReadKey();
                return;
            }

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("chaosmod/chaosproxy.log",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();

            m_Logger.Information("===============================");
            m_Logger.Information("Starting chaos mod twitch proxy");
            m_Logger.Information("===============================");

            var config = new OptionsFile("chaosmod/configs/voting.ini", "chaosmod/configs/twitch.ini", "chaosmod/twitch.ini");
            config.ReadFile();

            var mutex = new Mutex(false, "ChaosModVVotingMutex");
            mutex.WaitOne();

            var votingMode = (EVotingMode)config.ReadValueInt("VotingChanceSystem", 0, "TwitchVotingChanceSystem");
            var overlayMode = (EOverlayMode)config.ReadValueInt("VotingOverlayMode", 0, "TwitchVotingOverlayMode");
            var retainInitialVotes = config.ReadValueBool("VotingChanceSystemRetainChance", false, "TwitchVotingChanceSystemRetainChance");

            OverlayServer.OverlayServer? overlayServer = null;
            if (overlayMode == EOverlayMode.OVERLAY_OBS)
            {
                var overlayServerPort = config.ReadValueInt("OverlayServerPort", 9091);
                var overlayServerConfig = new OverlayServerConfig(votingMode, retainInitialVotes, overlayServerPort);
                overlayServer = new OverlayServer.OverlayServer(overlayServerConfig);
            }

            var chaosPipe = new ChaosPipeClient();

            var votingReceivers = new List<(string Name, IVotingReceiver VotingReceiver)>();
            if (config.ReadValueBool("EnableVotingTwitch", false))
            {
                votingReceivers.Add(("Twitch", new TwitchVotingReceiver(config, chaosPipe)));
            }
            if (config.ReadValueBool("EnableVotingKick", false))
            {
                votingReceivers.Add(("Kick", new KickVotingReceiver(config, chaosPipe)));
            }
            if (config.ReadValueBool("EnableVotingDiscord", false))
            {
                votingReceivers.Add(("Discord", new DiscordVotingReceiver(config, chaosPipe)));
            }

            foreach (var votingReceiver in votingReceivers)
            {
                m_Logger.Information($"Initializing {votingReceiver.Name} voting");

                try
                {
                    if (!await votingReceiver.VotingReceiver.Init())
                    {
                        m_Logger.Fatal($"Failed to initialize {votingReceiver.Name} voting");
                        return;
                    }
                }
                catch (Exception exception)
                {
                    m_Logger.Fatal($"Failed to initialize {votingReceiver.Name} voting\nException occurred: {exception}");
                    chaosPipe.SendErrorMessage($"Error occurred while initializing {votingReceiver.Name} voting. Check chaosproxy.log for details.");

                    return;
                }
            }

            m_Logger.Information("Initializing controller");

            var permittedUsernames = config.ReadValue("PermittedUsernames", "", "TwitchPermittedUsernames")?.ToLower()
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();
            var chaosModControllerConfig = new ChaosModControllerConfig()
            {
                VotingMode = votingMode,
                OverlayMode = overlayMode,
                RetainInitialVotes = retainInitialVotes,
                PermittedUsernames = permittedUsernames,
                VoteablePrefix = config.ReadValue("VoteablePrefix", "")
            };
            _ = new ChaosModController(chaosPipe, overlayServer, votingReceivers.Select(item => item.VotingReceiver).ToArray(),
                chaosModControllerConfig);

            m_Logger.Information("Sending hello to mod");

            chaosPipe.SendMessageToPipe("hello");
            while (!chaosPipe.GotHelloBack && chaosPipe.IsConnected())
            {
                await Task.Delay(100);
            }

            if (chaosPipe.GotHelloBack)
            {
                m_Logger.Information("Received hello_back from mod!");
            }

            while (chaosPipe.IsConnected())
            {
                await Task.Delay(100);
            }

            m_Logger.Information("Pipe disconnected, ending program.");
        }
    }
}
