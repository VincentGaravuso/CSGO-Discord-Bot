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
        public async Task Ping([Remainder] string steamID = null)
        {
            if(steamID == null)
            {
                await ReplyAsync("Paste [SteamID] after !ping");
            }

            Task <Root> task = StatsAPI.GetStatsAsync(steamID);
            if(task.Result != null)
            {
                Datum user = task.Result.data[0];
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
