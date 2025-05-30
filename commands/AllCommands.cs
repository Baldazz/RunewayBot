using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RunewayBot.other;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Sockets;
using DSharpPlus.Interactivity;
using DSharpPlus;
using System.Threading.Channels;
using System.Drawing;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Serialization;
using System.Linq.Expressions;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace RunewayBot.commands
{

    public class AllCommands : BaseCommandModule
    {
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////
      //    private static string pc = "server";
       private static string pc = "tester";
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////




        [Command("admin")]
        public async Task Console(CommandContext ctx)
        {
            if (ctx.Member.Id == 236877205454585857)
            /*
            if (ctx.Guild.Id.ToString() == "1286320852257738855"   // testchannel
             || ctx.Guild.Id.ToString() == "505135247642329090")  // runewaychannel
            */
            {
                var bottone1 = new DiscordButtonComponent(ButtonStyle.Danger, "clear", "Clear");
                var bottone2 = new DiscordButtonComponent(ButtonStyle.Danger, "sendMessage", "Update Message");

                DiscordMessageBuilder messagefile = new DiscordMessageBuilder()

                .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("SuperSecretAdminConsole 9000"))
                .AddComponents(bottone1, bottone2);
                await ctx.RespondAsync(messagefile);
            }
        }
        [Command("miao")]
        public async Task Miao(CommandContext ctx)
        {

            DiscordMessageBuilder messagefile = new DiscordMessageBuilder()

            .AddEmbed(new DiscordEmbedBuilder()
                     .WithColor(DiscordColor.Purple)
                     .WithTitle("miao :3"));
                await ctx.RespondAsync(messagefile);
            
        }
        [Command("AI")]
        public async Task DieAI(CommandContext ctx)
        {
            await ctx.Guild.BanMemberAsync(1153984868804468756, reason: "Art 1 - AI 0");
        }

    }
}
