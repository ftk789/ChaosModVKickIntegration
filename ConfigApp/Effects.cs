﻿namespace ConfigApp
{
    public static class Effects
    {
        public struct EffectInfo
        {
            public string? Name { get; set; } = null;
            public EffectCategory EffectCategory { get; set; } = EffectCategory.Unknown;
            public bool IsTimed { get; set; } = false;
            public bool IsShort { get; set; } = false;

            public EffectInfo()
            {

            }

            public EffectInfo(string name, EffectCategory effectCategory, bool isTimed = false, bool isShort = false)
            {
                Name = name;
                EffectCategory = effectCategory;
                IsTimed = isTimed;
                IsShort = isShort;
            }
        }

        public enum EffectCategory
        {
            Unknown = -1,
            Player,
            Vehicle,
            Peds,
            Screen,
            Time,
            Weather,
            Misc,
            Meta
        }

        public enum EffectTimedType
        {
            Permanent = -3,
            Custom, // Not used here, CustomTime is set to something other than 0 instead
            NotTimed,
            Normal,
            Short,
        }

        public static readonly Dictionary<string, EffectInfo> EffectsMap = new()
        {
            { "player_suicide", new EffectInfo("Suicide", EffectCategory.Player) },
            { "player_plus2stars", new EffectInfo("+2 Wanted Stars", EffectCategory.Player) },
            { "player_5stars", new EffectInfo("5 Wanted Stars", EffectCategory.Player) },
            { "player_neverwanted", new EffectInfo("Never Wanted", EffectCategory.Player, true) },
            { "peds_remweps", new EffectInfo("Remove Weapons From Everyone", EffectCategory.Peds) },
            { "player_heal", new EffectInfo("HESOYAM", EffectCategory.Player) },
            { "player_ignite", new EffectInfo("Ignite Player", EffectCategory.Player) },
            { "spawn_grieferjesus", new EffectInfo("Spawn Griefer Jesus", EffectCategory.Peds) },
            { "peds_spawnimrage", new EffectInfo("Spawn Impotent Rage", EffectCategory.Peds) },
            { "spawn_grieferjesus2", new EffectInfo("Spawn Extreme Griefer Jesus", EffectCategory.Peds) },
            { "peds_ignite", new EffectInfo("Ignite All Nearby Peds", EffectCategory.Peds) },
            { "vehs_explode", new EffectInfo("Explode All Nearby Vehicles", EffectCategory.Vehicle) },
            { "player_upupaway", new EffectInfo("Launch Player Up", EffectCategory.Player) },
            { "vehs_upupaway", new EffectInfo("Launch All Vehicles Up", EffectCategory.Vehicle) },
            { "playerveh_lock", new EffectInfo("Lock Player Inside Vehicle", EffectCategory.Vehicle, true) },
            { "nothing", new EffectInfo("Nothing", EffectCategory.Misc) },
            { "playerveh_killengine", new EffectInfo("Kill Engine Of Every Vehicle", EffectCategory.Vehicle) },
            { "time_morning", new EffectInfo("Set Time To Morning", EffectCategory.Time) },
            { "time_day", new EffectInfo("Set Time To Daytime", EffectCategory.Time) },
            { "time_evening", new EffectInfo("Set Time To Evening", EffectCategory.Time) },
            { "time_night", new EffectInfo("Set Time To Night", EffectCategory.Time) },
            { "weather_extrasunny", new EffectInfo("Extra Sunny Weather", EffectCategory.Weather) },
            { "weather_stormy", new EffectInfo("Stormy Weather", EffectCategory.Weather) },
            { "weather_foggy", new EffectInfo("Foggy Weather", EffectCategory.Weather) },
            { "weather_neutral", new EffectInfo("Neutral Weather", EffectCategory.Weather) },
            { "weather_snowy", new EffectInfo("Snowy Weather", EffectCategory.Weather) },
            { "tp_lsairport", new EffectInfo("Teleport To LS Airport", EffectCategory.Player) },
            { "tp_mazebanktower", new EffectInfo("Teleport To Top Of Maze Bank Tower", EffectCategory.Player) },
            { "tp_fortzancudo", new EffectInfo("Teleport To Fort Zancudo", EffectCategory.Player) },
            { "tp_skyfall", new EffectInfo("Teleport To Heaven", EffectCategory.Player) },
            { "tp_mountchilliad", new EffectInfo("Teleport To Mount Chiliad", EffectCategory.Player) },
            { "tp_random", new EffectInfo("Teleport To Random Location", EffectCategory.Player) },
            { "tp_mission", new EffectInfo("Teleport To Random Mission", EffectCategory.Player) },
            { "tp_fake", new EffectInfo("Fake Teleport", EffectCategory.Player) },
            { "player_tp_store", new EffectInfo("Teleport to Random Store", EffectCategory.Player) },
            { "player_nophone", new EffectInfo("No Phone", EffectCategory.Misc, true) },
            { "player_tpclosestveh", new EffectInfo("Set Player Into Closest Vehicle", EffectCategory.Player) },
            { "playerveh_exit", new EffectInfo("Everyone Exits Their Vehicles", EffectCategory.Peds) },
            { "time_x02", new EffectInfo("x0.2 Gamespeed", EffectCategory.Time, true, true) },
            { "time_x05", new EffectInfo("x0.5 Gamespeed", EffectCategory.Time, true, true) },
            { "time_lag", new EffectInfo("Lag", EffectCategory.Misc, true, true) },
            { "peds_riot", new EffectInfo("Peds Riot", EffectCategory.Peds, true) },
            { "vehs_red", new EffectInfo("Red Traffic", EffectCategory.Vehicle, true) },
            { "vehs_blue", new EffectInfo("Blue Traffic", EffectCategory.Vehicle, true) },
            { "vehs_green", new EffectInfo("Green Traffic", EffectCategory.Vehicle, true) },
            { "vehs_chrome", new EffectInfo("Chrome Traffic", EffectCategory.Vehicle, true) },
            { "vehs_pink", new EffectInfo("Hot Traffic", EffectCategory.Vehicle, true) },
            { "vehs_rainbow", new EffectInfo("Rainbow Traffic", EffectCategory.Vehicle, true) },
            { "vehs_slippery", new EffectInfo("Slippery Vehicles", EffectCategory.Vehicle, true) },
            { "vehs_nogravity", new EffectInfo("Vehicles Have No Gravity", EffectCategory.Vehicle, true, true) },
            { "player_invincible", new EffectInfo("Invincibility", EffectCategory.Player, true) },
            { "vehs_x2engine", new EffectInfo("2x Vehicle Engine Speed", EffectCategory.Vehicle, true) },
            { "vehs_x10engine", new EffectInfo("10x Vehicle Engine Speed", EffectCategory.Vehicle, true) },
            { "vehs_x05engine", new EffectInfo("0.5x Vehicle Engine Speed", EffectCategory.Vehicle, true) },
            { "spawn_rhino", new EffectInfo("Spawn Rhino", EffectCategory.Vehicle) },
            { "spawn_adder", new EffectInfo("Spawn Adder", EffectCategory.Vehicle) },
            { "spawn_dump", new EffectInfo("Spawn Dump", EffectCategory.Vehicle) },
            { "spawn_monster", new EffectInfo("Spawn Monster", EffectCategory.Vehicle) },
            { "spawn_bmx", new EffectInfo("Spawn BMX", EffectCategory.Vehicle) },
            { "spawn_tug", new EffectInfo("Spawn Tug", EffectCategory.Vehicle) },
            { "spawn_cargo", new EffectInfo("Spawn Cargo Plane", EffectCategory.Vehicle) },
            { "spawn_bus", new EffectInfo("Spawn Bus", EffectCategory.Vehicle) },
            { "spawn_blimp", new EffectInfo("Spawn Blimp", EffectCategory.Vehicle) },
            { "spawn_buzzard", new EffectInfo("Spawn Buzzard", EffectCategory.Vehicle) },
            { "spawn_faggio", new EffectInfo("Spawn Faggio", EffectCategory.Vehicle) },
            { "spawn_ruiner3", new EffectInfo("Spawn Ruined Ruiner", EffectCategory.Vehicle) },
            { "spawn_baletrailer", new EffectInfo("Spawn Bale Trailer", EffectCategory.Vehicle) },
            { "spawn_romero", new EffectInfo("Where's The Funeral?", EffectCategory.Vehicle) },
            { "spawn_random", new EffectInfo("Spawn Random Vehicle", EffectCategory.Vehicle) },
            { "notraffic", new EffectInfo("No Traffic", EffectCategory.Vehicle, true) },
            { "playerveh_explode", new EffectInfo("Detonate Current Vehicle", EffectCategory.Vehicle) },
            { "peds_ghost", new EffectInfo("Everyone Is A Ghost", EffectCategory.Peds, true) },
            { "vehs_ghost", new EffectInfo("Invisible Vehicles", EffectCategory.Vehicle, true) },
            { "no_radar", new EffectInfo("No Radar", EffectCategory.Screen, true) },
            { "no_hud", new EffectInfo("No HUD", EffectCategory.Screen, true) },
            { "player_superrun", new EffectInfo("Super Run & Super Jump", EffectCategory.Player, true) },
            { "player_ragdoll", new EffectInfo("Ragdoll", EffectCategory.Player) },
            { "peds_ragdoll", new EffectInfo("Ragdoll Everyone", EffectCategory.Peds) },
            { "peds_sensitivetouch", new EffectInfo("Sensitive Touch", EffectCategory.Peds, true, true) },
            { "poorboi", new EffectInfo("Poor Boy", EffectCategory.Player) },
            { "player_famous", new EffectInfo("You Are Famous", EffectCategory.Peds, true) },
            { "player_drunk", new EffectInfo("Drunk", EffectCategory.Player, true) },
            { "player_ohko", new EffectInfo("One Hit KO", EffectCategory.Peds, true) },
            { "screen_lsd", new EffectInfo("LSD", EffectCategory.Screen, true) },
            { "screen_lowrenderdist", new EffectInfo("Where Did Everything Go?", EffectCategory.Screen, true, true) },
            { "screen_fog", new EffectInfo("Extreme Fog", EffectCategory.Screen, true, true) },
            { "screen_lsnoire", new EffectInfo("LS Noire", EffectCategory.Screen, true) },
            { "screen_bright", new EffectInfo("Deep Fried", EffectCategory.Screen, true, true) },
            { "screen_mexico", new EffectInfo("Is This What Mexico Looks Like?", EffectCategory.Screen, true) },
            { "screen_fullbright", new EffectInfo("Fullbright", EffectCategory.Screen, true) },
            { "screen_bubblevision", new EffectInfo("Bubble Vision", EffectCategory.Screen, true, true) },
            { "peds_blind", new EffectInfo("Blind Peds", EffectCategory.Peds, true) },
            { "vehs_honkboost", new EffectInfo("Honk Boosting", EffectCategory.Vehicle, true) },
            { "peds_mindmg", new EffectInfo("Minimal Damage", EffectCategory.Peds, true) },
            { "peds_frozen", new EffectInfo("Peds Are Brainless", EffectCategory.Peds, true) },
            { "lowgravity", new EffectInfo("Low Gravity", EffectCategory.Misc, true, true) },
            { "verylowgravity", new EffectInfo("Very Low Gravity", EffectCategory.Misc, true, true) },
            { "insanegravity", new EffectInfo("Insane Gravity", EffectCategory.Misc, true, true) },
            { "invertgravity", new EffectInfo("Invert Gravity", EffectCategory.Misc, true, true) },
            { "playerveh_repair", new EffectInfo("Repair All Vehicles", EffectCategory.Vehicle) },
            { "playerveh_poptires", new EffectInfo("Pop Tires Of Every Vehicle", EffectCategory.Vehicle) },
            { "vehs_poptiresconstant", new EffectInfo("Now This Is Some Tire Poppin'", EffectCategory.Vehicle, true, true) },
            { "player_nospecial", new EffectInfo("No Special Ability", EffectCategory.Player, true) },
            { "peds_dance", new EffectInfo("In The Hood", EffectCategory.Peds, true) },
            { "player_forcedcinematiccam", new EffectInfo("Cinematic Vehicle Cam", EffectCategory.Vehicle, true) },
            { "peds_flee", new EffectInfo("All Nearby Peds Are Fleeing", EffectCategory.Peds) },
            { "playerveh_breakdoors", new EffectInfo("Break Doors Of Every Vehicle", EffectCategory.Vehicle) },
            { "zombies", new EffectInfo("Explosive Zombies", EffectCategory.Peds, true) },
            { "meteorrain", new EffectInfo("Meteor Shower", EffectCategory.Misc, true) },
            { "world_blackout", new EffectInfo("Blackout", EffectCategory.Misc, true) },
            { "time_quickday", new EffectInfo("Timelapse", EffectCategory.Time, true) },
            { "player_break", new EffectInfo("Autopilot", EffectCategory.Player, true, true) },
            { "peds_giverpg", new EffectInfo("Give Everyone An RPG", EffectCategory.Peds) },
            { "peds_stungun", new EffectInfo("Give Everyone A Stun Gun", EffectCategory.Peds) },
            { "peds_minigun", new EffectInfo("Give Everyone A Minigun", EffectCategory.Peds) },
            { "peds_upnatomizer", new EffectInfo("Give Everyone An Up-N-Atomizer", EffectCategory.Peds) },
            { "peds_randomwep", new EffectInfo("Give Everyone A Random Weapon", EffectCategory.Peds) },
            { "peds_railgun", new EffectInfo("Give Everyone A Railgun", EffectCategory.Peds) },
            { "peds_battleaxe", new EffectInfo("Give Everyone A Battle Axe", EffectCategory.Peds) },
            { "player_nosprint", new EffectInfo("No Sprint & No Jump", EffectCategory.Player, true) },
            { "peds_invincible", new EffectInfo("Everyone Is Invincible", EffectCategory.Peds, true) },
            { "vehs_invincible", new EffectInfo("All Vehicles Are Invulnerable", EffectCategory.Vehicle, true) },
            { "player_ragdollondmg", new EffectInfo("Player Ragdolls When Shot", EffectCategory.Player, true) },
            { "vehs_jumpy", new EffectInfo("Jumpy Vehicles", EffectCategory.Vehicle, true, true) },
            { "vehs_lockdoors", new EffectInfo("Lock All Vehicles", EffectCategory.Vehicle) },
            { "chaosmode", new EffectInfo("Doomsday", EffectCategory.Misc, true, true) },
            { "player_noragdoll", new EffectInfo("No Ragdoll", EffectCategory.Peds, true) },
            { "vehs_honkconstant", new EffectInfo("All Vehicles Honk", EffectCategory.Vehicle, true) },
            { "player_tptowaypoint", new EffectInfo("Teleport To Waypoint", EffectCategory.Player) },
            { "peds_sayhi", new EffectInfo("Friendly Neighborhood", EffectCategory.Peds, true) },
            { "peds_insult", new EffectInfo("Unfriendly Neighborhood", EffectCategory.Peds, true) },
            { "player_explosivecombat", new EffectInfo("Explosive Combat", EffectCategory.Peds, true) },
            { "player_allweps", new EffectInfo("Give All Weapons", EffectCategory.Player) },
            { "peds_aimbot", new EffectInfo("Aimbot Peds", EffectCategory.Peds, true) },
            { "spawn_chop", new EffectInfo("Spawn Companion Doggo", EffectCategory.Peds) },
            { "spawn_chimp", new EffectInfo("Spawn Companion Chimp", EffectCategory.Peds) },
            { "spawn_compbrad", new EffectInfo("Spawn Companion Brad", EffectCategory.Peds) },
            { "spawn_comprnd", new EffectInfo("Spawn Random Companion", EffectCategory.Peds) },
            { "player_nightvision", new EffectInfo("Night Vision", EffectCategory.Screen, true) },
            { "player_heatvision", new EffectInfo("Heat Vision", EffectCategory.Screen, true, true) },
            { "player_moneydrops", new EffectInfo("Money Rain", EffectCategory.Misc, true) },
            { "playerveh_tprandompeds", new EffectInfo("Teleport Random Peds Into Current Vehicle", EffectCategory.Peds) },
            { "peds_revive", new EffectInfo("Revive Dead Peds", EffectCategory.Peds) },
            { "world_snow", new EffectInfo("Snow", EffectCategory.Weather, true) },
            { "world_whalerain", new EffectInfo("Whale Rain", EffectCategory.Misc, true) },
            { "playerveh_maxupgrades", new EffectInfo("Add Max Upgrades To Every Vehicle", EffectCategory.Vehicle) },
            { "playerveh_randupgrades", new EffectInfo("Add Random Upgrades To Every Vehicle", EffectCategory.Vehicle) },
            { "player_arenawarstheme", new EffectInfo("Play Arena Wars Theme", EffectCategory.Misc, true) },
            { "peds_driveby", new EffectInfo("Peds Drive-By Player", EffectCategory.Peds, true, true) },
            { "player_randclothes", new EffectInfo("Randomize Player Clothes", EffectCategory.Player) },
            { "peds_rainbowweps", new EffectInfo("Rainbow Weapons", EffectCategory.Misc, true) },
            { "traffic_gtao", new EffectInfo("Traffic Magnet", EffectCategory.Vehicle, true) },
            { "spawn_bluesultan", new EffectInfo("Spawn Blue Sultan", EffectCategory.Peds) },
            { "player_setintorandveh", new EffectInfo("Set Player Into Random Vehicle", EffectCategory.Player) },
            { "traffic_fullaccel", new EffectInfo("Full Acceleration", EffectCategory.Vehicle, true, true) },
            { "misc_spawnufo", new EffectInfo("Spawn UFO", EffectCategory.Misc) },
            { "misc_spawnferriswheel", new EffectInfo("Spawn Ferris Wheel", EffectCategory.Misc) },
            { "peds_explosive", new EffectInfo("Explosive Peds", EffectCategory.Peds, true) },
            { "invertvelocity", new EffectInfo("Invert Current Velocity", EffectCategory.Misc) },
            { "player_tpeverything", new EffectInfo("Teleport Everything To Player", EffectCategory.Player) },
            { "weather_randomizer", new EffectInfo("Disco Weather", EffectCategory.Weather, true) },
            { "world_lowpoly", new EffectInfo("Low Render Distance", EffectCategory.Misc, true) },
            { "peds_obliterate", new EffectInfo("Obliterate All Nearby Peds", EffectCategory.Peds) },
            { "vehs_alarmloop", new EffectInfo("Alarmy Vehicles", EffectCategory.Vehicle, true) },
            { "veh_randomseat", new EffectInfo("Set Player Into Random Vehicle Seat", EffectCategory.Player) },
            { "veh_30mphlimit", new EffectInfo("30MPH Speed Limit", EffectCategory.Vehicle, true, true) },
            { "veh_jesustakethewheel", new EffectInfo("Jesus Take The Wheel", EffectCategory.Vehicle) },
            { "veh_poptire", new EffectInfo("Random Tire Popping", EffectCategory.Vehicle, true, true) },
            { "peds_angryalien", new EffectInfo("Spawn Angry Alien", EffectCategory.Peds) },
            { "peds_angryjimmy", new EffectInfo("Spawn Jealous Jimmy", EffectCategory.Peds) },
            { "vehs_ohko", new EffectInfo("Vehicles Explode On Impact", EffectCategory.Vehicle, true) },
            { "vehs_spamdoors", new EffectInfo("Spammy Vehicle Doors", EffectCategory.Vehicle, true) },
            { "veh_speed_goal", new EffectInfo("Need For Speed", EffectCategory.Vehicle, true, true) },
            { "vehs_flyingcars", new EffectInfo("Flying Cars", EffectCategory.Vehicle, true) },
            { "misc_credits", new EffectInfo("Roll Credits", EffectCategory.Misc, true, true) },
            { "misc_earthquake", new EffectInfo("Earthquake", EffectCategory.Misc, true, true) },
            { "player_tpfront", new EffectInfo("Teleport Player A Few Meters", EffectCategory.Player) },
            { "peds_spawnfancats", new EffectInfo("Spawn Fan Cats", EffectCategory.Peds) },
            { "peds_cops", new EffectInfo("All Peds Are Cops", EffectCategory.Peds, true) },
            { "vehs_rotall", new EffectInfo("Flip All Vehicles", EffectCategory.Vehicle) },
            { "peds_launchnearby", new EffectInfo("Launch All Nearby Peds Up", EffectCategory.Peds) },
            { "peds_attackplayer", new EffectInfo("All Peds Attack Player", EffectCategory.Peds, true) },
            { "player_clone", new EffectInfo("Clone Player", EffectCategory.Player) },
            { "peds_slidy", new EffectInfo("Slidy Peds", EffectCategory.Peds, true) },
            { "peds_spawndancingapes", new EffectInfo("Spawn Dance Troupe", EffectCategory.Peds) },
            { "misc_onebullet", new EffectInfo("One Bullet Mags", EffectCategory.Peds, true) },
            { "peds_phones", new EffectInfo("Whose Phone Is Ringing?", EffectCategory.Peds, true) },
            { "misc_midas", new EffectInfo("Midas Touch", EffectCategory.Player, true) },
            { "peds_spawnrandomhostile", new EffectInfo("Spawn Random Enemy", EffectCategory.Peds) },
            { "peds_portal_gun", new EffectInfo("Portal Guns", EffectCategory.Peds, true) },
            { "misc_fireworks", new EffectInfo("Fireworks!", EffectCategory.Misc, true) },
            { "peds_spawnballasquad", new EffectInfo("Spawn Balla Squad", EffectCategory.Peds) },
            { "playerveh_despawn", new EffectInfo("Remove Current Vehicle", EffectCategory.Vehicle) },
            { "peds_scooterbrothers", new EffectInfo("Scooter Brothers", EffectCategory.Peds) },
            { "peds_intorandomvehs", new EffectInfo("Set Everyone Into Random Vehicles", EffectCategory.Peds) },
            { "player_heavyrecoil", new EffectInfo("Heavy Recoil", EffectCategory.Player, true) },
            { "peds_catguns", new EffectInfo("Catto Guns", EffectCategory.Peds, true) },
            { "player_forcefield", new EffectInfo("Forcefield", EffectCategory.Player, true, true) },
            { "misc_oilleaks", new EffectInfo("Oil Trails", EffectCategory.Misc, true) },
            { "peds_gunsmoke", new EffectInfo("Gunsmoke", EffectCategory.Peds, true) },
            { "player_keeprunning", new EffectInfo("Help My W Key Is Stuck", EffectCategory.Player, true, true) },
            { "veh_weapons", new EffectInfo("Vehicles Shoot Rockets", EffectCategory.Vehicle, true) },
            { "misc_airstrike", new EffectInfo("Airstrike Inbound", EffectCategory.Misc, true) },
            { "peds_mercenaries", new EffectInfo("Mercenaries", EffectCategory.Peds, true) },
            { "peds_loosetrigger", new EffectInfo("Loose Triggers", EffectCategory.Peds, true) },
            { "peds_minions", new EffectInfo("Minions", EffectCategory.Peds, true) },
            { "misc_flamethrower", new EffectInfo("Flamethrowers", EffectCategory.Misc, true) },
            { "misc_dvdscreensaver", new EffectInfo("DVD Screensaver", EffectCategory.Screen, true, true) },
            { "player_fakedeath", new EffectInfo("Fake Death", EffectCategory.Player) },
            { "time_superhot", new EffectInfo("Superhot", EffectCategory.Time, true) },
            { "vehs_beyblade", new EffectInfo("Beyblades", EffectCategory.Vehicle, true, true) },
            { "peds_killerclowns", new EffectInfo("Killer Clowns", EffectCategory.Peds, true, true) },
            { "peds_jamesbond", new EffectInfo("Spawn Deadly Agent", EffectCategory.Peds) },
            { "player_poof", new EffectInfo("Deadly Aim", EffectCategory.Player, true) },
            { "player_simeonsays", new EffectInfo("Simeon Says", EffectCategory.Player, true, true) },
            { "player_lockcamera", new EffectInfo("Lock Camera", EffectCategory.Player, true) },
            { "misc_replacevehicle", new EffectInfo("Replace Current Vehicle", EffectCategory.Vehicle) },
            { "player_tired", new EffectInfo("I'm So Tired", EffectCategory.Player, true) },
            { "player_kickflip", new EffectInfo("Kickflip", EffectCategory.Player) },
            { "misc_superstunt", new EffectInfo("Super Stunt", EffectCategory.Misc) },
            { "player_walkonwater", new EffectInfo("Walk On Water", EffectCategory.Player, true) },
            { "screen_needglasses", new EffectInfo("I Need Glasses", EffectCategory.Screen, true, true) },
            { "player_flip_camera", new EffectInfo("Turn Turtle", EffectCategory.Screen, true, true) },
            { "player_quake_fov", new EffectInfo("Quake FOV", EffectCategory.Screen, true) },
            { "player_rapid_fire", new EffectInfo("Rapid Fire", EffectCategory.Player, true) },
            { "player_on_demand_cartoon", new EffectInfo("On-Demand TV", EffectCategory.Screen, true) },
            { "peds_drive_backwards", new EffectInfo("Peds Drive Backwards", EffectCategory.Peds, true) },
            { "veh_randtraffic", new EffectInfo("Random Traffic", EffectCategory.Vehicle, true) },
            { "misc_rampjam", new EffectInfo("Ramp Jam", EffectCategory.Misc, true) },
            { "misc_vehicle_rain", new EffectInfo("Vehicle Rain", EffectCategory.Misc, true, true) },
            { "misc_fakecrash", new EffectInfo("Fake Crash", EffectCategory.Misc) },
            { "player_gravity", new EffectInfo("Gravity Field", EffectCategory.Player, true, true) },
            { "veh_bouncy", new EffectInfo("Bouncy Vehicles", EffectCategory.Vehicle, true, false) },
            { "peds_stop_stare", new EffectInfo("Stop And Stare", EffectCategory.Peds) },
            { "peds_flip", new EffectInfo("Spinning Peds", EffectCategory.Peds, true, true) },
            { "player_pacifist", new EffectInfo("Pacifist", EffectCategory.Player, true, false) },
            { "peds_busbois", new EffectInfo("Bus Bois", EffectCategory.Peds) },
            { "player_dead_eye", new EffectInfo("Dead Eye", EffectCategory.Player, true) },
            { "player_hacking", new EffectInfo("Realistic Hacking", EffectCategory.Player) },
            { "peds_nailguns", new EffectInfo("Nailguns", EffectCategory.Peds, true, true) },
            { "veh_brakeboost", new EffectInfo("Brake Boosting", EffectCategory.Vehicle, true) },
            { "player_bees", new EffectInfo("Bees", EffectCategory.Player, true) },
            { "player_vr", new EffectInfo("Virtual Reality", EffectCategory.Player, true, true) },
            { "misc_portrait", new EffectInfo("Portrait Mode", EffectCategory.Misc, true) },
            { "misc_highpitch", new EffectInfo("High Pitch", EffectCategory.Misc, true) },
            { "misc_nosky", new EffectInfo("No Sky", EffectCategory.Misc, true) },
            { "player_gta_2", new EffectInfo("GTA 2", EffectCategory.Player, true, true) },
            { "peds_kifflom", new EffectInfo("Kifflom!", EffectCategory.Peds, true) },
            { "meta_timerspeed_0_5x", new EffectInfo("0.5x Timer Speed", EffectCategory.Meta, true) },
            { "meta_timerspeed_2x", new EffectInfo("2x Timer Speed", EffectCategory.Meta, true) },
            { "meta_timerspeed_5x", new EffectInfo("5x Timer Speed", EffectCategory.Meta, true, true) },
            { "meta_effect_duration_2x", new EffectInfo("2x Effect Duration", EffectCategory.Meta, true) },
            { "meta_effect_duration_0_5x", new EffectInfo("0.5x Effect Duration", EffectCategory.Meta, true) },
            { "meta_hide_chaos_ui", new EffectInfo("What's Happening??", EffectCategory.Meta, true) },
            { "meta_spawn_multiple_effects", new EffectInfo("Combo Time", EffectCategory.Meta, true) },
            { "misc_flip_ui", new EffectInfo("Flipped HUD", EffectCategory.Screen, true) },
            { "vehs_crumble", new EffectInfo("Crumbling Vehicles", EffectCategory.Vehicle, true, true) },
            { "misc_fps_limit", new EffectInfo("Console Experience", EffectCategory.Misc, true, true) },
            { "meta_nochaos", new EffectInfo("No Chaos", EffectCategory.Meta, true) },
            { "player_spin_camera", new EffectInfo("Spinning Camera", EffectCategory.Screen, true, true) },
            { "misc_lowpitch", new EffectInfo("Low Pitch", EffectCategory.Misc, true) },
            { "peds_roasting", new EffectInfo("Get Roasted", EffectCategory.Peds, true, true) },
            { "player_binoculars", new EffectInfo("Binoculars", EffectCategory.Screen, true) },
            { "peds_slippery_peds", new EffectInfo("Can't Tie My Shoes", EffectCategory.Peds, true, true) },
            { "vehs_cruise_control", new EffectInfo("Cruise Control", EffectCategory.Vehicle, true, true) },
            { "peds_hands_up", new EffectInfo("Hands Up!", EffectCategory.Peds) },
            { "player_aimbot", new EffectInfo("Aimbot", EffectCategory.Player, true) },
            { "player_jump_jump", new EffectInfo("Jump! Jump!", EffectCategory.Player, true, true) },
            { "peds_spawn_biker", new EffectInfo("Spawn Biker", EffectCategory.Peds) },
            { "peds_spawn_juggernaut", new EffectInfo("Spawn Juggernaut", EffectCategory.Peds) },
            { "misc_witness_protection", new EffectInfo("Witness Protection", EffectCategory.Misc, true) },
            { "misc_quick_sprunk_stop", new EffectInfo("Quick Sprunk Stop", EffectCategory.Misc) },
            { "player_blimp_strats", new EffectInfo("Blimp Strats", EffectCategory.Player) },
            { "peds_spawn_space_ranger", new EffectInfo("Spawn Space Ranger", EffectCategory.Peds) },
            { "peds_mowermates", new EffectInfo("Mower Mates", EffectCategory.Peds) },
            { "peds_tank_bois", new EffectInfo("Tanks A Lot", EffectCategory.Peds) },
            { "veh_repossession", new EffectInfo("Repossession", EffectCategory.Vehicle) },
            { "misc_pause", new EffectInfo("Pause", EffectCategory.Misc) },
            { "vehs_spawn_wizard_broom", new EffectInfo("You're A Wizard, Franklin", EffectCategory.Vehicle) },
            { "player_illegalinnocence", new EffectInfo("Innocence Is Illegal", EffectCategory.Player, true) },
            { "player_zoomzoom_cam", new EffectInfo("Zoom Zoom Cam", EffectCategory.Player, true, true) },
            { "misc_spawn_orange_ball", new EffectInfo("Spawn Orange Ball", EffectCategory.Misc) },
            { "player_no_random_movement", new EffectInfo("Disable Random Direction", EffectCategory.Player, true) },
            { "player_rocket", new EffectInfo("Rocket Man", EffectCategory.Player) },
            { "misc_news_team", new EffectInfo("News Team", EffectCategory.Misc, true, true) },
            { "player_fling_player", new EffectInfo("Fling Player", EffectCategory.Player) },
            { "misc_stuffguns", new EffectInfo("Improvised Weaponry", EffectCategory.Misc, true, true) },
            { "misc_random_waypoint", new EffectInfo("Set Random Waypoint", EffectCategory.Misc) },
            { "peds_eternal_screams", new EffectInfo("Eternal Screams", EffectCategory.Peds, true, true) },
            { "spawn_angry_chimp", new EffectInfo("Spawn Angry Chimp", EffectCategory.Peds, true) },
            { "misc_uturn", new EffectInfo("U-Turn", EffectCategory.Misc) },
            { "peds_spawn_quarreling_couple", new EffectInfo("Spawn Quarreling Couple", EffectCategory.Peds) },
            { "misc_get_towed", new EffectInfo("Get Towed", EffectCategory.Misc) },
            { "peds_bloody", new EffectInfo("Everyone Is Bloody", EffectCategory.Peds) },
            { "misc_weirdpitch", new EffectInfo("Weird Pitch", EffectCategory.Misc, true) },
            { "player_tp_stunt", new EffectInfo("Make Random Stunt Jump", EffectCategory.Player) },
            { "misc_spinning_props", new EffectInfo("Spinning Props", EffectCategory.Misc, true) },
            { "player_grav_sphere", new EffectInfo("Gravity Sphere", EffectCategory.Player, true, true) },
            { "player_sick_cam", new EffectInfo("I Feel Sick", EffectCategory.Screen, true, true) },
            { "misc_ghost_world", new EffectInfo("Ghost Town", EffectCategory.Misc, true) },
            { "peds_headless", new EffectInfo("Mannequins", EffectCategory.Peds, true) },
            { "peds_2x_animation_speed", new EffectInfo("2x Animation Speed", EffectCategory.Peds, true) },
            { "player_tp_to_everything", new EffectInfo("Teleporter Malfunction", EffectCategory.Player, true, true) },
            { "player_laggy_camera", new EffectInfo("Delayed Camera", EffectCategory.Player, true) },
            { "misc_clone_on_death", new EffectInfo("Resurrection Day", EffectCategory.Misc, true, true) },
            { "misc_sideways_gravity", new EffectInfo("Sideways Gravity", EffectCategory.Misc, true, true) },
            { "misc_jumpy_props", new EffectInfo("Jumpy Props", EffectCategory.Misc, true) },
            { "misc_boost_velocity", new EffectInfo("Speed Boost", EffectCategory.Misc) },
            { "peds_prop_hunt", new EffectInfo("Prop Hunt", EffectCategory.Peds, true) },
            { "misc_remove_water", new EffectInfo("Drought", EffectCategory.Misc, true) },
            { "vehs_prop_models", new EffectInfo("Prop Cars", EffectCategory.Vehicle, true) },
            { "vehs_tiny", new EffectInfo("Tiny Vehicles", EffectCategory.Vehicle, true) },
            { "meta_re_invoke", new EffectInfo("Re-Invoke Previous Effects", EffectCategory.Meta) },
            { "screen_tnpanel", new EffectInfo("TN Panel", EffectCategory.Screen, true) },
            { "screen_fckautorotate", new EffectInfo("Goddamn Auto-Rotate", EffectCategory.Screen, true, true) },
            { "screen_warpedcam", new EffectInfo("Warped Camera", EffectCategory.Screen, true, true) },
            { "screen_dimwarp", new EffectInfo("Dimension Warp", EffectCategory.Screen, true, true) },
            { "screen_shatteredscreen", new EffectInfo("Shattered Screen", EffectCategory.Screen, true) },
            { "screen_localcoop", new EffectInfo("Split Screen Co-op", EffectCategory.Screen, true, true) },
            { "screen_invertedcolors", new EffectInfo("Inverted Colors", EffectCategory.Screen, true) },
            { "screen_fourthdimension", new EffectInfo("Fourth Dimension", EffectCategory.Screen, true, true) },
            { "screen_rgbland", new EffectInfo("RGB Land", EffectCategory.Screen, true) },
            { "peds_give_props", new EffectInfo("Give Everyone A Random Prop", EffectCategory.Peds) },
            { "screen_textureless", new EffectInfo("Textureless", EffectCategory.Screen, true) },
            { "screen_mirrored", new EffectInfo("Mirrored Screen", EffectCategory.Screen, true) },
            { "screen_foldedscreen", new EffectInfo("Folded Screen", EffectCategory.Screen, true) },
            { "screen_swappedcolors", new EffectInfo("Swapped Colors", EffectCategory.Screen, true) },
            { "screen_screenfreakout", new EffectInfo("Screen Freakout", EffectCategory.Screen, true, true) },
            { "screen_screenpotato", new EffectInfo("Potato", EffectCategory.Screen, true, true) },
            { "screen_colorfulworld", new EffectInfo("Colorful World", EffectCategory.Screen, true) },
            { "screen_arc", new EffectInfo("Arced Screen", EffectCategory.Screen, true, true) },
            { "world_blackhole", new EffectInfo("Black Hole", EffectCategory.Misc, true, true) },
            { "misc_nowaypoint", new EffectInfo("Remove Waypoint", EffectCategory.Misc) },
            { "player_afk", new EffectInfo("AFK", EffectCategory.Player, true, true) },
            { "misc_solid_props", new EffectInfo("Solid Props", EffectCategory.Misc, true) },
            { "peds_smoketrails", new EffectInfo("Smoke Trails", EffectCategory.Peds, true) },
            { "misc_randomgravity", new EffectInfo("Random Gravity", EffectCategory.Misc, true, true) },
            { "vehs_disassemble", new EffectInfo("Disassemble Current Vehicle", EffectCategory.Vehicle) },
            { "vehs_detach_wheel", new EffectInfo("Detach Random Wheel", EffectCategory.Vehicle) },
            { "screen_maximap", new EffectInfo("Maximap", EffectCategory.Misc, true) },
            { "player_movementx5", new EffectInfo("5x Movement Speed", EffectCategory.Player, true) },
            { "player_movementx10", new EffectInfo("10x Movement Speed", EffectCategory.Player, true) },
            { "player_movementx05", new EffectInfo("0.5x Movement Speed", EffectCategory.Player, true, true) },
            { "player_3stars", new EffectInfo("3 Wanted Stars", EffectCategory.Player ) },
            { "player_1star", new EffectInfo("1 Wanted Star", EffectCategory.Player ) },
            { "player_fakestars", new EffectInfo("Fake Wanted Level", EffectCategory.Player ) },
            { "misc_pay_respects", new EffectInfo("Pay Respects", EffectCategory.Misc, true, true) },
            { "timecycle_fuzzy", new EffectInfo("Static", EffectCategory.Screen, true, true) },
            { "peds_hotcougars", new EffectInfo("Hot Cougars In Your Area", EffectCategory.Peds, true, true) },
            { "peds_grapple_guns", new EffectInfo("Gravity Guns", EffectCategory.Peds, true) },
            { "timecycle_darkworld", new EffectInfo("A Dark World", EffectCategory.Screen, true, true) },
            { "peds_reflectivedamage", new EffectInfo("Friendly Fire", EffectCategory.Peds, true, true) },
            { "peds_toast", new EffectInfo("You're Toast", EffectCategory.Peds, true) },
            { "tp_fakex2", new EffectInfo("Fake Fake Teleport", EffectCategory.Player) },
            { "time_local_time", new EffectInfo("Set Time To System Time", EffectCategory.Time) },
            { "peds_not_menendez", new EffectInfo("Not Menendez!", EffectCategory.Peds, true) },
            { "misc_go_to_jail", new EffectInfo("Bad Boys", EffectCategory.Misc) },
            { "misc_muffled_audio", new EffectInfo("Muffled Audio", EffectCategory.Misc, true) },
            { "misc_fakeuturn", new EffectInfo("Fake U-Turn", EffectCategory.Misc) },
            { "misc_esp", new EffectInfo("ESP", EffectCategory.Misc, true) },
            { "screen_bouncyradar", new EffectInfo("Bouncy Radar", EffectCategory.Screen, true) },
            { "veh_boostbrake", new EffectInfo("Boost Braking", EffectCategory.Vehicle, true) },
            { "cocktail_shaker", new EffectInfo("Cocktail Shaker", EffectCategory.Misc, true, true) },
            { "screen_realfp", new EffectInfo("Real First Person", EffectCategory.Screen, true) },
            { "screen_hueshift", new EffectInfo("Hue Shift", EffectCategory.Screen, true) },
            { "player_copyforce", new EffectInfo("Use The Force", EffectCategory.Player, true, true) },
        };
    }
}