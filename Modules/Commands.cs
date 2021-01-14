using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CSGO_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private CommandService _commands;
        public Commands(CommandService c) { this._commands = c; }

        [Command("commands")]
        [Alias("cmds", "cmd", "csgo_bot", "csgo")]
        [Summary("Displays list of commands")]
        public async Task ShowCommands([Remainder] string rem = null)
        {
            List<CommandInfo> commands = _commands.Commands.ToList();
            var embd = new EmbedBuilder();
            embd.Title = "Commands:";
            embd.WithColor(Color.Red);
            foreach (CommandInfo ci in commands)
            {
                string aliasList = "";
                if (ci.Aliases.Count > 1)
                {
                    int count = 1;
                    foreach (string alias in ci.Aliases)
                    {
                        if (count != 1)
                        {
                            aliasList += alias;
                            if (count != ci.Aliases.Count)
                            {
                                aliasList += ", ";
                            }
                        }
                        count++;
                    }
                }
                embd.AddField($"!{ci.Name}", $"{ci.Summary} \n Alias: {aliasList}", true);
            }
            embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
            await ReplyAsync(embed: embd.Build());
        }

        [Command("help")]
        [Alias("h")]
        [Summary("Displays information about ")]
        public async Task Help([Remainder] string helpCmd = "")
        {
            string helpStatement = String.Empty;
            switch (helpCmd.ToLower())
            {
                case "id":
                    helpStatement = "To find your Steam ID follow these steps: https://tinyurl.com/FindSteamID";
                    break;
                default:
                    helpStatement = "For help with specific commands type '!help' followed by the command you need help with. (To view all commands type '!commands')";
                    break;
            }
            await ReplyAsync(helpStatement);
        }

        [Command("info")]
        [Alias("i")]
        [Summary("Displays basic user information.")]
        public async Task Stats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserRoot> task = StatsAPI.GetStatsAsync(steamID);
            if (task.Result != null)
            {
                if (task.Result.users.Count > 0)
                {
                    User user = task.Result.users[0];
                    var embd = new EmbedBuilder();
                    embd.AddField(user.platformUserHandle,
                        $"Platform {user.platformSlug}")
                        .WithImageUrl(user.avatarUrl);
                    embd.WithColor(Color.Red);
                    embd.WithFooter("Competitive and Casual stats combined");
                    await ReplyAsync(embed: embd.Build());
                }
                else
                {
                    await ReplyAsync("Invalid ID: No data found. Profile may be private!");
                }
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("allmapstats")]
        [Alias("ams")]
        [Summary("Gets user stats from all available maps.")]
        public async Task AllMapStats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<Root> task = StatsAPI.GetMapStatsAsync(steamID);
            if (task.Result != null)
            {
                Task<UserRoot> userRootTask = StatsAPI.GetStatsAsync(steamID);
                User u = userRootTask.Result.users[0];
                EmbedAuthorBuilder embdAuth = new EmbedAuthorBuilder();
                embdAuth.Name = u.platformUserHandle;
                embdAuth.IconUrl = u.avatarUrl;

                var embd = new EmbedBuilder();
                embd.WithAuthor(embdAuth);
                List<Datum> sortedList = task.Result.Data.OrderByDescending(o => o.Stats.Rounds.Value).ToList<Datum>();
                foreach (Datum stats in sortedList)
                {
                    var embdFieldBuilder = new EmbedFieldBuilder();
                    embdFieldBuilder.WithName(stats.Metadata.Name)
                        .WithValue($"Rounds Played: {stats.Stats.Rounds.DisplayValue} | Rounds Won: {stats.Stats.Wins.DisplayValue}");

                    embd.AddField(embdFieldBuilder);
                    embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                }
                embd.WithColor(Color.Red);
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("mapstats")]
        [Alias("ms")]
        [Summary("Gets user stats of specified map.")]
        public async Task MapStats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<Root> task = StatsAPI.GetMapStatsAsync(steamID);
            if (task.Result != null)
            {
                Task<UserRoot> userRootTask = StatsAPI.GetStatsAsync(steamID);
                User u = userRootTask.Result.users[0];
                EmbedAuthorBuilder embdAuth = new EmbedAuthorBuilder();
                embdAuth.Name = u.platformUserHandle;
                embdAuth.IconUrl = u.avatarUrl;

                var embd = new EmbedBuilder();
                embd.WithAuthor(embdAuth);

                foreach (Datum stats in task.Result.Data)
                {
                    var embdFieldBuilder = new EmbedFieldBuilder();
                    embdFieldBuilder.WithName(stats.Metadata.Name)
                        .WithValue($"Rounds Played: {stats.Stats.Rounds.DisplayValue} | Rounds Won: {stats.Stats.Wins.DisplayValue}");
                    embd.AddField(embdFieldBuilder);
                    embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                }
                embd.WithColor(Color.Red);
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }
        [Command("kills")]
        [Alias("k")]
        [Summary("Gets users total number of kills.")]
        public async Task Kills([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result != null)
            {
                var embdAuth = new EmbedAuthorBuilder();
                var embd = new EmbedBuilder();
                Kills killStats = task.Result.Data.Segments[0].Stats.Kills;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {killStats.DisplayName}";
                embd.Description = $"Kills: {killStats.DisplayValue} | Percentile: {killStats.Percentile}";
                if (killStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (killStats.Percentile >= 50)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }
        [Command("deaths")]
        [Alias("d")]
        [Summary("Gets users total number of deaths.")]
        public async Task Deaths([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);
            if (task.Result != null)
            {

                var embdAuth = new EmbedAuthorBuilder();
                var embd = new EmbedBuilder();
                Deaths deathStats = task.Result.Data.Segments[0].Stats.Deaths;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {deathStats.DisplayName}";
                embd.Description = $"Deaths: {deathStats.DisplayValue} | Percentile: {deathStats.Percentile}";
                if (deathStats.Percentile >= 70)
                {
                    embd.WithColor(Color.Red);
                }
                else if (deathStats.Percentile >= 50)
                {
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    embd.WithColor(Color.Green);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("kdratio")]
        [Alias("kd")]
        [Summary("Gets users kill death ratio.")]
        public async Task KillDeathRatio([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                Kd kdStats = task.Result.Data.Segments[0].Stats.Kd;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {kdStats.DisplayName}";
                embd.Description = $"KD: {kdStats.DisplayValue} | Percentile: {kdStats.Percentile}";
                if (kdStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (kdStats.Percentile >= 50)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("shotAccuracy")]
        [Alias("sa", "accuracy")]
        [Summary("Gets users shot accuracy.")]
        public async Task ShotsAccuracy([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                ShotsAccuracy saStats = task.Result.Data.Segments[0].Stats.ShotsAccuracy;
                ShotsFired sfStats = task.Result.Data.Segments[0].Stats.ShotsFired;
                ShotsHit shStats = task.Result.Data.Segments[0].Stats.ShotsHit;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {saStats.DisplayName}";
                embd.Description = $"Shot Accuracy: {saStats.DisplayValue} | Percentile: {saStats.Percentile}" +
                    $"\nShots Fired: {sfStats.DisplayValue} | Shots Hit: {shStats.DisplayValue}";
                if (saStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (saStats.Percentile >= 50)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("bombstats")]
        [Alias("bp", "bombs", "bomb", "plants", "defuses", "defuse")]
        [Summary("Gets number of bomb plants/defuses for given users.")]
        public async Task BombsPlanted([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                BombsPlanted bpStats = task.Result.Data.Segments[0].Stats.BombsPlanted;
                BombsDefused bdStats = task.Result.Data.Segments[0].Stats.BombsDefused;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {bpStats.DisplayName} | {bdStats.DisplayName}";
                embd.Description = $"Bombs Planted: {bpStats.DisplayValue} | Percentile: {bpStats.Percentile}" +
                                   $"\nBombs Defused: {bdStats.DisplayValue} | Percentile: {bdStats.Percentile} ";

                if (bpStats.Percentile >= 70 && bdStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (bpStats.Percentile >= 50 && bdStats.Percentile >= 50)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }


        [Command("timeplayed")]
        [Alias("tp", "time", "playtime")]
        [Summary("Gets users time played.")]
        public async Task TimePlayed([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result.Data != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                TimePlayed tpStats = task.Result.Data.Segments[0].Stats.TimePlayed;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {tpStats.DisplayName}";
                embd.Description = $"Time Played: {tpStats.DisplayValue} | Percentile: {tpStats.Percentile}";
                if (tpStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (tpStats.Percentile >= 50)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("headshots")]
        [Alias("headshot", "hs", "hp")]
        [Summary("Gets users headshot stats.")]
        public async Task Headshots([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);

            if (task.Result != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                HeadshotPct hpStats = task.Result.Data.Segments[0].Stats.HeadshotPct;
                Headshots hsStats = task.Result.Data.Segments[0].Stats.Headshots;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"Stat: {hsStats.DisplayName}";
                embd.Description = $"Headshots: {hsStats.DisplayValue} | Percentile: {hsStats.Percentile}" +
                                   $"\nHeadshot Percentage: {hpStats.DisplayValue} | Percentile: {hpStats.Percentile}";
                if (hsStats.Percentile >= 70 && hpStats.Percentile >= 70)
                {
                    //green
                    embd.WithColor(Color.Green);
                }
                else if (hsStats.Percentile >= 50 && hpStats.Percentile >= 70)
                {
                    //orange
                    embd.WithColor(Color.Orange);
                }
                else
                {
                    //red
                    embd.WithColor(Color.Red);
                }
                embd.WithFooter("Competitive and Casual stats combined");
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }

        [Command("playerStats")]
        [Alias("ps")]
        [Summary("Returns a variety of player stats.")]
        public async Task PlayerStats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);
            await task;
            if (task.Result != null)
            {
                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                Kills killStats = task.Result.Data.Segments[0].Stats.Kills;
                Deaths deathStats = task.Result.Data.Segments[0].Stats.Deaths;
                Kd kdStats = task.Result.Data.Segments[0].Stats.Kd;
                ShotsAccuracy shotAccuracyStats = task.Result.Data.Segments[0].Stats.ShotsAccuracy;
                ShotsFired shotsFiredStats = task.Result.Data.Segments[0].Stats.ShotsFired;
                ShotsHit shotsHitStats = task.Result.Data.Segments[0].Stats.ShotsHit;
                BombsDefused bombsDefusedStats = task.Result.Data.Segments[0].Stats.BombsDefused;
                BombsPlanted bombsPlantedStats = task.Result.Data.Segments[0].Stats.BombsPlanted;
                HeadshotPct hpStats = task.Result.Data.Segments[0].Stats.HeadshotPct;
                Headshots hsStats = task.Result.Data.Segments[0].Stats.Headshots;
                TimePlayed timePlayedStats = task.Result.Data.Segments[0].Stats.TimePlayed;

                embdAuth.Name = task.Result.Data.PlatformInfo.PlatformUserHandle;
                embdAuth.IconUrl = task.Result.Data.PlatformInfo.AvatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                embd.Title = $"All Stats:";

                embd.Description =
                    $"{kdStats.DisplayName}: {kdStats.DisplayValue}\n" +
                    $"{killStats.DisplayName}: {killStats.DisplayValue}\n" +
                    $"{deathStats.DisplayName}: {deathStats.DisplayValue}\n" +
                    $"{shotAccuracyStats.DisplayName}: {shotAccuracyStats.DisplayValue}\n" +
                    $"{shotsFiredStats.DisplayName}: {shotsFiredStats.DisplayValue}\n" +
                    $"{shotsHitStats.DisplayName}: {shotsHitStats.DisplayValue}\n" +
                    $"Headshot Accuracy: {hpStats.DisplayValue}\n" +
                    $"{hsStats.DisplayName}: {hsStats.DisplayValue}\n" +
                    $"{bombsPlantedStats.DisplayName}: {bombsPlantedStats.DisplayValue}\n" +
                    $"{bombsDefusedStats.DisplayName}: {bombsDefusedStats.DisplayValue}\n" +
                    $"{timePlayedStats.DisplayName}: {timePlayedStats.DisplayValue}";

                embd.WithFooter("Competitive and Casual stats combined");
                embd.WithColor(Color.Red);
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }


        [Command("inventory")]
        [Alias("inv", "in")]
        [Summary("Returns the value of users CSGO inventory.")]
        public async Task Inventory([Remainder] string steamID = null)
        {
            if (steamID.Any(x => char.IsLetter(x)))
            {
                try
                {
                    
                }
                catch
                {
                    //No user found return
                }
                await ReplyAsync("This command requires your numeric steam ID: For help getting your steam ID type: !h ID");
                return;
            }
            if (steamID == null)
            {
                await ReplyAsync("This command requires your steam ID: !<command> <steamID>. For help getting your steam ID type: !h ID");
                return;
            }


            Task<InventoryModel> task = StatsAPI.GetInventoryStats(steamID);
            if (task.Result != null)
            {
                Task<UserRoot> userTask = StatsAPI.GetStatsAsync(steamID);

                var embd = new EmbedBuilder();
                var embdAuth = new EmbedAuthorBuilder();
                InventoryModel inventory = task.Result;

                embdAuth.Name = userTask.Result.users[0].platformUserHandle;
                embdAuth.IconUrl = userTask.Result.users[0].avatarUrl;

                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
                if(inventory.Success.ToLower() != "true")
                {
                    await ReplyAsync($"{inventory.Success}");
                    return;
                }
                embd.Title = $"Stat: Inventory";
                embd.Description = $"Inventory Value: {inventory.Value} {inventory.Currency}\nItems: {inventory.Items}";
                try
                {
                    double val = double.Parse(inventory.Value, System.Globalization.CultureInfo.InvariantCulture);
                    if (val >= 1000)
                    {
                        //Gold
                        embd.WithColor(new Color(0xFFD700));
                    }
                    else if (val >= 500)
                    {
                        //Red
                        embd.WithColor(new Color(0x991f20));
                    }
                    else if (val >= 250)
                    {
                        //Violet
                        embd.WithColor(new Color(0x9e29b0));
                    }
                    else if (val >= 75)
                    {
                        //Purple
                        embd.WithColor(new Color(0x7c43e9));
                    }
                    else if (val >= 30)
                    {
                        //Blue
                        embd.WithColor(new Color(0x425dd8));
                    }
                    else
                    {
                        //Grey
                        embd.WithColor(new Color(0xFFFFFF));
                    }
                }
                catch
                {
                    embd.WithColor(Color.DarkerGrey);
                }
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }
    }
}
