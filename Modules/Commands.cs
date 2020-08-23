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

        [Command("info")]
        [Alias("i")]
        [Summary("Displays user information.")]
        public async Task Stats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("Paste [SteamID] after !Stats");
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
                    embd.WithColor(new Color(0x016FA0));
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
                await ReplyAsync("Paste [SteamID] after !allmapstats \nFor help getting your SteamID type: '!help id'");
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
                embd.WithColor(new Color(0x016FA0));
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
                await ReplyAsync("Paste [SteamID] after !mapstats");
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
                embd.WithColor(new Color(0x016FA0));
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
                await ReplyAsync("Paste [SteamID] after !mapstats");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);
            if (task.Result != null)
            {
                Task<UserRoot> userRootTask = StatsAPI.GetStatsAsync(steamID);
                User u = userRootTask.Result.users[0];
                EmbedAuthorBuilder embdAuth = new EmbedAuthorBuilder();
                embdAuth.Name = u.platformUserHandle;
                embdAuth.IconUrl = u.avatarUrl;

                var embd = new EmbedBuilder();
                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");

                Kills killStats = task.Result.Data.Segments[0].Stats.Kills;
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
                await ReplyAsync("Paste [SteamID] after !mapstats");
                return;
            }

            Task<UserInfoRoot> task = StatsAPI.GetUserStats(steamID);
            if (task.Result != null)
            {
                Task<UserRoot> userRootTask = StatsAPI.GetStatsAsync(steamID);
                User u = userRootTask.Result.users[0];
                EmbedAuthorBuilder embdAuth = new EmbedAuthorBuilder();
                embdAuth.Name = u.platformUserHandle;
                embdAuth.IconUrl = u.avatarUrl;

                var embd = new EmbedBuilder();
                embd.WithAuthor(embdAuth);
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");

                Deaths deathStats = task.Result.Data.Segments[0].Stats.Deaths;
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
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found. Profile may be private!");
            }
        }


        [Command("commands")]
        [Alias("cmds", "cmd", "csgo_bot", "csgo")]
        [Summary("Displays list of commands")]
        public async Task ShowCommands([Remainder] string rem = null)
        {
            List<CommandInfo> commands = _commands.Commands.ToList();
            var embd = new EmbedBuilder();
            embd.Title = "Commands:";
            embd.WithColor(new Color(0x016FA0));
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
                embd.AddField($"!{ci.Name}", $"{ci.Summary} \n Alias: {aliasList}");
                embd.WithThumbnailUrl("https://i.pinimg.com/originals/b1/02/24/b10224ae75edd5debd06c44662cbcb30.png");
            }
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
    }
}
