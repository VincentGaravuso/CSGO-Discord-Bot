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
        [Command("stats")]
        public async Task Stats([Remainder] string steamID = null)
        {
            if(steamID == null)
            {
                await ReplyAsync("Paste [SteamID] after !Stats");
            }

            Task <UserRoot> task = StatsAPI.GetStatsAsync(steamID);
            if(task.Result.users.Count > 0)
            {
                User user = task.Result.users[0];
                var embd = new EmbedBuilder();
                embd.AddField(user.platformUserHandle,
                    $"Platform {user.platformSlug}")
                    .WithImageUrl(user.avatarUrl);
                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No users found.");
            }
        }

        [Command("mapstats")]
        public async Task MapStats([Remainder] string steamID = null)
        {
            if (steamID == null)
            {
                await ReplyAsync("Paste [SteamID] after !mapstats");
            }

            Task<Root> task = StatsAPI.GetMapStatsAsync(steamID);
            if (task.Result.Data.Count > 0)
            {
                Datum stats = task.Result.Data[0];
                var embd = new EmbedBuilder();
                embd.Title = stats.Metadata.Name;
                embd.Description = $"Rounds Played: {stats.Stats.Rounds.DisplayValue} | Rounds Won: {stats.Stats.Wins.DisplayValue}";
                embd.ThumbnailUrl = stats.Metadata.ImageUrl;

                Task<UserRoot> userRootTask = StatsAPI.GetStatsAsync(steamID);
                User u = userRootTask.Result.users[0];
                EmbedAuthorBuilder embdAuth = new EmbedAuthorBuilder();
                embdAuth.Name = u.platformUserHandle;
                embdAuth.IconUrl = u.avatarUrl;

                embd.WithAuthor(embdAuth);

                await ReplyAsync(embed: embd.Build());
            }
            else
            {
                await ReplyAsync("Invalid ID: No data found.");
            }
        }
        [Command("help")]
        public async Task Help([Remainder] string helpCmd = "")
        {
            string helpStatement = String.Empty;
            switch (helpCmd.ToLower())
            {
                case "id":
                    helpStatement = "To find your Steam ID follow these steps: https://tinyurl.com/FindMySteamID";
                    break;
                case "cmd ":
                    helpStatement = "List of commands to come";
                    break;
                default:
                    helpStatement = "For help with specific commands type '!help' followed by the command you need help with. (All commands: id, cmd)";
                    break;
            }
            await ReplyAsync(helpStatement);

        }
        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage ="You don't have the permission ``ban_member``!")]
        public async Task BanMember(IGuildUser user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                await ReplyAsync("Please specify a user!"); 
                return;
            }
            if (reason == null) reason = "Not specified";

            await Context.Guild.AddBanAsync(user, 1, reason);

            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check_mark: {user.Mention} was banned\n**Reason** {reason}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);

            ITextChannel logChannel = Context.Client.GetChannel(642698444431032330) as ITextChannel;
            var EmbedBuilderLog = new EmbedBuilder()
                .WithDescription($"{user.Mention} was banned\n**Reason** {reason}\n**Moderator** {Context.User.Mention}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embedLog = EmbedBuilderLog.Build();
            await logChannel.SendMessageAsync(embed: embedLog);

        }


    }
}
