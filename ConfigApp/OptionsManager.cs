﻿using System.IO;
using Shared;

namespace ConfigApp
{
    public static class OptionsManager
    {
        public static OptionsFile ConfigFile { get; } = new OptionsFile("configs/config.ini", "config.ini");
        public static OptionsFile TwitchFile { get; } = new OptionsFile("configs/voting.ini", "configs/twitch.ini", "twitch.ini");
        public static OptionsFile KickFile { get; } = new OptionsFile("configs/voting.ini", "configs/kick.ini", "kick.ini");
        public static OptionsFile EffectsFile { get; } = new OptionsFile("configs/effects.ini", "effects.ini");

        // These are written to manually
        public static OptionsFile WorkshopFile { get; } = new OptionsFile("configs/workshop.ini");

        public static void ReadFiles()
        {
            ConfigFile.ReadFile();
            TwitchFile.ReadFile();
            KickFile.ReadFile();
            EffectsFile.ReadFile();
            WorkshopFile.ReadFile();
        }

        public static void WriteFiles()
        {
            ConfigFile.WriteFile();
            TwitchFile.WriteFile();
            KickFile.WriteFile();
            EffectsFile.WriteFile();
        }

        public static void ResetFiles()
        {
            // Exclude TwitchFile as that one is reset separately

            ConfigFile.ResetFile();
            EffectsFile.ResetFile();
        }

        public static void DeleteCompatFiles()
        {
            static void deleteFiles(string[] files)
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            if (ConfigFile.HasCompatFile())
            {
                deleteFiles(ConfigFile.GetCompatFiles());
            }
            if (TwitchFile.HasCompatFile())
            {
                deleteFiles(TwitchFile.GetCompatFiles());
            }
            if (KickFile.HasCompatFile())
            {
                deleteFiles(KickFile.GetCompatFiles());
            }
            if (EffectsFile.HasCompatFile())
            {
                deleteFiles(EffectsFile.GetCompatFiles());
            }
        }
    }
}
