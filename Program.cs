using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using RunewayBot.config;
using RunewayBot.commands;
using System.Threading.Tasks;
using System;
using RunewayBot.other;
using DSharpPlus.Entities;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Xml.Linq;
using System.Runtime.ExceptionServices;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using DSharpPlus.SlashCommands;
using RunewayBot.SlashCommands;

namespace RunewayBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }

        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////
        //  private static string pc = "server";
        private static string pc = "tester";
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////

        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;
            Client.ComponentInteractionCreated += Client_ComponentInteractionCreated;
            Client.GuildCreated += Client_GuildCreated;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            var slashCommands = Client.UseSlashCommands();

            Commands.RegisterCommands<AllCommands>();

            slashCommands.RegisterCommands<AllSlashCommands>();


            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task Client_GuildCreated(DiscordClient sender, GuildCreateEventArgs args)
        {

            Console.WriteLine($"Il bot è entrato nel server -{args.Guild.Name}- (ID: {args.Guild.Id})");

            var defaultChannel = args.Guild.Channels.FirstOrDefault();
           
            var message = ""; // messaggio al join di un nuovo server //////////////////////////////////////////////////////////////////////////////////////////

            await sender.SendMessageAsync(defaultChannel.Value, message);
        }

        private static async Task Client_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs args)
        {
            string path = "";

            if (pc == "tester")
            {
                path = "C:\\Users\\Io\\Desktop\\RunewayBot\\ImageFolder\\";
            }
            else if (pc == "server")
            {
                path = "\\root\\Desktop\\BEANBOT\\RunewayBot\\ImageFolder\\";
                // path = "C:\\Users\\matte\\Desktop\\BEANBOT\\RunewayBot\\ImageFolder\\";
            }

            if (!int.TryParse(args.Interaction.Data.CustomId, out int wawawewe))
            {
                Console.WriteLine("|| " + DateTime.Now.ToString("h:mm:ss tt") + " pressed " + args.Interaction.Data.CustomId);
            }

            #region tasti modifica sigilli /////////////////////////////////////////////////////////////////////////////////////////
            switch (args.Interaction.Data.CustomId)
            {
                case "s2":
                    var userRune1 = new RuneSystem(2, args.Guild.Id, 9);
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.Title = "Il Sigillo è ora composto da 2 frammenti";
                    embed2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed2));
                    return;
                case "s3":
                    var userRune10 = new RuneSystem(3, args.Guild.Id, 9);
                    var embed10 = new DiscordEmbedBuilder();
                    embed10.Title = "Il Sigillo è ora composto da 3 frammenti";
                    embed10.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed10));
                    return;
                case "s4":
                    var userRune2 = new RuneSystem(4, args.Guild.Id, 9);
                    var embed3 = new DiscordEmbedBuilder();
                    embed3.Title = "Il Sigillo è ora composto da 4 frammenti";
                    embed3.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed3));
                    return;
                case "s5":
                    var userRune9 = new RuneSystem(5, args.Guild.Id, 9);
                    var embed9 = new DiscordEmbedBuilder();
                    embed9.Title = "Il Sigillo è ora composto da 5 frammenti";
                    embed9.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed9));
                    return;
                case "s6":
                    var userRune3 = new RuneSystem(6, args.Guild.Id, 9);
                    var embed4 = new DiscordEmbedBuilder();
                    embed4.Title = "Il Sigillo è ora composto da 6 frammenti";
                    embed4.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed4));
                    return;
                case "s7":
                    var userRune11 = new RuneSystem(7, args.Guild.Id, 9);
                    var embed11 = new DiscordEmbedBuilder();
                    embed11.Title = "Il Sigillo è ora composto da 7 frammenti";
                    embed11.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed11));
                    return;
                case "s8":
                    var userRune4 = new RuneSystem(8, args.Guild.Id, 9);
                    var embed5 = new DiscordEmbedBuilder();
                    embed5.Title = "Il Sigillo è ora composto da 8 frammenti";
                    embed5.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed5));
                    return;



                case "sf4":
                    var userRune5 = new RuneSystem(4, args.Guild.Id, 8);
                    var embed6 = new DiscordEmbedBuilder();
                    embed6.Title = "Il Sigillo del Fato è ora composto da 4 frammenti";
                    embed6.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed6));
                    return;
                case "sf5":
                    var userRune33 = new RuneSystem(5, args.Guild.Id, 8);
                    var embed33 = new DiscordEmbedBuilder();
                    embed33.Title = "Il Sigillo del Fato è ora composto da 5 frammenti";
                    embed33.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed33));
                    return;
                case "sf6":
                    var userRune6 = new RuneSystem(6, args.Guild.Id, 8);
                    var embed7 = new DiscordEmbedBuilder();
                    embed7.Title = "Il Sigillo del Fato è ora composto da 6 frammenti";
                    embed7.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed7));
                    return;
                case "sf7":
                    var userRune22 = new RuneSystem(7, args.Guild.Id, 8);
                    var embed22 = new DiscordEmbedBuilder();
                    embed22.Title = "Il Sigillo del Fato è ora composto da 7 frammenti";
                    embed22.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed22));
                    return;
                case "sf8":
                    var userRune7 = new RuneSystem(8, args.Guild.Id, 8);
                    var embed8 = new DiscordEmbedBuilder();
                    embed8.Title = "Il Sigillo del Fato è ora composto da 8 frammenti";
                    embed8.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed8));
                    return;

                case "p2":
                    var userRune1p = new RuneSystem(2, args.Guild.Id, 11);
                    var embed2p = new DiscordEmbedBuilder();

                    if (userRune1p.data[70] == 1)
                        embed2p.Title = "Il Sigillo Parallelo è ora composto da 2 frammenti";
                    if (userRune1p.data[70] == 3)
                        embed2p.Title = "Il primo Sigillo Parallelo è ora composto da 2 frammenti";

                    embed2p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed2p));
                    return;
                case "p3":
                    var userRune10p = new RuneSystem(3, args.Guild.Id, 11);
                    var embed10p = new DiscordEmbedBuilder();
                    if (userRune10p.data[70] == 1)
                        embed10p.Title = "Il Sigillo Parallelo è ora composto da 3 frammenti";
                    if (userRune10p.data[70] == 3)
                        embed10p.Title = "Il primo Sigillo Parallelo è ora composto da 3 frammenti";
                    embed10p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed10p));
                    return;
                case "p4":
                    var userRune2p = new RuneSystem(4, args.Guild.Id, 11);
                    var embed3p = new DiscordEmbedBuilder();
                    if (userRune2p.data[70] == 1)
                        embed3p.Title = "Il Sigillo Parallelo è ora composto da 4 frammenti";
                    if (userRune2p.data[70] == 3)
                        embed3p.Title = "Il primo Sigillo Parallelo è ora composto da 4 frammenti";
                    embed3p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed3p));
                    return;
                case "p5":
                    var userRune9p = new RuneSystem(5, args.Guild.Id, 11);
                    var embed9p = new DiscordEmbedBuilder();

                    if (userRune9p.data[70] == 1)
                        embed9p.Title = "Il Sigillo Parallelo è ora composto da 5 frammenti";
                    if (userRune9p.data[70] == 3)
                        embed9p.Title = "Il primo Sigillo Parallelo è ora composto da 5 frammenti";

                    embed9p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed9p));
                    return;
                case "p6":
                    var userRune3p = new RuneSystem(6, args.Guild.Id, 11);
                    var embed4p = new DiscordEmbedBuilder();

                    if (userRune3p.data[70] == 1)
                        embed4p.Title = "Il Sigillo Parallelo è ora composto da 6 frammenti";
                    if (userRune3p.data[70] == 3)
                        embed4p.Title = "Il primo Sigillo Parallelo è ora composto da 6 frammenti";

                    embed4p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed4p));
                    return;
                case "p7":
                    var userRune11p = new RuneSystem(7, args.Guild.Id, 11);
                    var embed11p = new DiscordEmbedBuilder();

                    if (userRune11p.data[70] == 1)
                        embed11p.Title = "Il Sigillo Parallelo è ora composto da 7 frammenti";
                    if (userRune11p.data[70] == 3)
                        embed11p.Title = "Il primo Sigillo Parallelo è ora composto da 7 frammenti";

                    embed11p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed11p));
                    return;
                case "p8":
                    var userRune4p = new RuneSystem(8, args.Guild.Id, 11);
                    var embed5p = new DiscordEmbedBuilder();

                    if (userRune4p.data[70] == 1)
                        embed5p.Title = "Il Sigillo Parallelo è ora composto da 8 frammenti";
                    if (userRune4p.data[70] == 3)
                        embed5p.Title = "Il primo Sigillo Parallelo è ora composto da 8 frammenti";

                    embed5p.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed5p));
                    return;

                case "p22":
                    var userRune1p2 = new RuneSystem(2, args.Guild.Id, 12);
                    var embed2p2 = new DiscordEmbedBuilder();
                    embed2p2.Title = "Il secondo Sigillo Parallelo è ora composto da 2 frammenti";
                    embed2p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed2p2));
                    return;
                case "p23":
                    var userRune10p2 = new RuneSystem(3, args.Guild.Id, 12);
                    var embed10p2 = new DiscordEmbedBuilder();
                    embed10p2.Title = "Il secondo Sigillo Parallelo è ora composto da 3 frammenti";
                    embed10p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed10p2));
                    return;
                case "p24":
                    var userRune2p2 = new RuneSystem(4, args.Guild.Id, 12);
                    var embed3p2 = new DiscordEmbedBuilder();
                    embed3p2.Title = "Il secondo Sigillo Parallelo è ora composto da 4 frammenti";
                    embed3p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed3p2));
                    return;
                case "p25":
                    var userRune9p2 = new RuneSystem(5, args.Guild.Id, 12);
                    var embed9p2 = new DiscordEmbedBuilder();
                    embed9p2.Title = "Il secondo Sigillo Parallelo è ora composto da 5 frammenti";
                    embed9p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed9p2));
                    return;
                case "p26":
                    var userRune3p2 = new RuneSystem(6, args.Guild.Id, 12);
                    var embed4p2 = new DiscordEmbedBuilder();
                    embed4p2.Title = "Il secondo Sigillo Parallelo è ora composto da 6 frammenti";
                    embed4p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed4p2));
                    return;
                case "p27":
                    var userRune11p2 = new RuneSystem(7, args.Guild.Id, 12);
                    var embed11p2 = new DiscordEmbedBuilder();
                    embed11p2.Title = "Il secondo Sigillo Parallelo è ora composto da 7 frammenti";
                    embed11p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed11p2));
                    return;
                case "p28":
                    var userRune4p2 = new RuneSystem(8, args.Guild.Id, 12);
                    var embed5p2 = new DiscordEmbedBuilder();
                    embed5p2.Title = "Il secondo Sigillo Parallelo è ora composto da 8 frammenti";
                    embed5p2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed5p2));
                    return;

            }
            #endregion

            bool refresh = false;

            if (args.Interaction.Data.CustomId == "rimescola")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 1);

                var embedo = new DiscordEmbedBuilder();
                embedo.Title = "Rune estratte rimesse nel sacchetto";
                embedo.Color = DiscordColor.Azure;

                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
            }
            else if (args.Interaction.Data.CustomId == "reopen")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 69);
                refresh = true;
                #region refresh block /////////////////////////////////////////////////////////////////////////////////////
                if (refresh)
                {
                    var q = new AllSlashCommands();

                    string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    string imagePath = $"{args.Guild.Id}.png";
                    int nBott = 0;


                    for (int i = 0; i < 24; i++)
                    {
                        if (userRune.data[24 + i] != -1)
                        {
                            nBott++;
                        }
                        else
                        {
                            i = 50;
                        }
                    }

                    #region pain ///////////////////////////////////////////////////////////////////////////////////////////////
                    var bottone1 = new DiscordButtonComponent(q.GetButtonColor(userRune, 0), "1", q.GetButtonName(userRune, 0));
                    var bottone2 = new DiscordButtonComponent(q.GetButtonColor(userRune, 1), "2", q.GetButtonName(userRune, 1));
                    var bottone3 = new DiscordButtonComponent(q.GetButtonColor(userRune, 2), "3", q.GetButtonName(userRune, 2));
                    var bottone4 = new DiscordButtonComponent(q.GetButtonColor(userRune, 3), "4", q.GetButtonName(userRune, 3));
                    var bottone5 = new DiscordButtonComponent(q.GetButtonColor(userRune, 4), "5", q.GetButtonName(userRune, 4));
                    var bottone6 = new DiscordButtonComponent(q.GetButtonColor(userRune, 5), "6", q.GetButtonName(userRune, 5));
                    var bottone7 = new DiscordButtonComponent(q.GetButtonColor(userRune, 6), "7", q.GetButtonName(userRune, 6));
                    var bottone8 = new DiscordButtonComponent(q.GetButtonColor(userRune, 7), "8", q.GetButtonName(userRune, 7));
                    var bottone9 = new DiscordButtonComponent(q.GetButtonColor(userRune, 8), "9", q.GetButtonName(userRune, 8));
                    var bottone10 = new DiscordButtonComponent(q.GetButtonColor(userRune, 9), "10", q.GetButtonName(userRune, 9));
                    var bottone11 = new DiscordButtonComponent(q.GetButtonColor(userRune, 10), "11", q.GetButtonName(userRune, 10));
                    var bottone12 = new DiscordButtonComponent(q.GetButtonColor(userRune, 11), "12", q.GetButtonName(userRune, 11));
                    var bottone13 = new DiscordButtonComponent(q.GetButtonColor(userRune, 12), "13", q.GetButtonName(userRune, 12));
                    var bottone14 = new DiscordButtonComponent(q.GetButtonColor(userRune, 13), "14", q.GetButtonName(userRune, 13));
                    var bottone15 = new DiscordButtonComponent(q.GetButtonColor(userRune, 14), "15", q.GetButtonName(userRune, 14));
                    var bottone16 = new DiscordButtonComponent(q.GetButtonColor(userRune, 15), "16", q.GetButtonName(userRune, 15));
                    var bottone17 = new DiscordButtonComponent(q.GetButtonColor(userRune, 16), "17", q.GetButtonName(userRune, 16));
                    var bottone18 = new DiscordButtonComponent(q.GetButtonColor(userRune, 17), "18", q.GetButtonName(userRune, 17));
                    var bottone19 = new DiscordButtonComponent(q.GetButtonColor(userRune, 18), "19", q.GetButtonName(userRune, 18));
                    var bottone20 = new DiscordButtonComponent(q.GetButtonColor(userRune, 19), "20", q.GetButtonName(userRune, 19));
                    var bottone21 = new DiscordButtonComponent(q.GetButtonColor(userRune, 20), "21", q.GetButtonName(userRune, 20));
                    var bottone22 = new DiscordButtonComponent(q.GetButtonColor(userRune, 21), "22", q.GetButtonName(userRune, 21));
                    var bottone23 = new DiscordButtonComponent(q.GetButtonColor(userRune, 22), "23", q.GetButtonName(userRune, 22));
                    var bottone24 = new DiscordButtonComponent(q.GetButtonColor(userRune, 23), "24", q.GetButtonName(userRune, 23));
                    var bottone25 = new DiscordButtonComponent(ButtonStyle.Secondary, "25", "Rimescola nel sacchetto");
                    #endregion
                    var random = new Random();
                    for (int i = 0; i < 24; i++)
                    {
                        if (userRune.data[i + 24] != -1)
                        {
                            if (userRune.data[userRune.data[i + 24]] == 2)
                            {
                                imagePaths[i] = (userRune.data[i + 24] + 1).ToString();
                            }
                            else if (userRune.data[userRune.data[i + 24]] == 3)
                            {
                                switch (random.Next(0, 3))
                                {
                                    case 0:
                                        imagePaths[i] = "01";
                                        break;
                                    case 1:
                                        imagePaths[i] = "02";
                                        break;
                                    case 2:
                                        imagePaths[i] = "03";
                                        break;
                                }
                            }
                        }
                        else
                            i = 25;
                    }
                    var imageToSend = new ImagesManager();
                    imageToSend.ImageStuff(args.Guild.Id, path, imagePaths, nBott);
                    if (System.IO.File.Exists(path + imagePath))
                    {
                        using (var stream = new FileStream(path + imagePath, FileMode.Open))
                        {
                            DiscordMessageBuilder messagefile = new DiscordMessageBuilder();
                            /*    .AddEmbed(new DiscordEmbedBuilder()
                                 .WithColor(DiscordColor.Purple)
                                 .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                            //.AddFile(stream);


                            #region suffering ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////      
                            if (nBott <= 5)
                            {
                                switch (nBott)
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        break;
                                    case 5:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                        break;
                                }
                                messagefile.AddComponents(bottone25);
                            }
                            else if (nBott <= 10)
                            {
                                messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                switch (nBott)
                                {
                                    case 6:
                                        messagefile.AddComponents(bottone6);
                                        break;
                                    case 7:
                                        messagefile.AddComponents(bottone6, bottone7);
                                        break;
                                    case 8:
                                        messagefile.AddComponents(bottone6, bottone7, bottone8);
                                        break;
                                    case 9:
                                        messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9);
                                        break;
                                    case 10:
                                        messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                        break;
                                }
                                messagefile.AddComponents(bottone25);
                            }
                            else if (nBott <= 15)
                            {
                                messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                switch (nBott)
                                {
                                    case 11:
                                        messagefile.AddComponents(bottone11);
                                        break;
                                    case 12:
                                        messagefile.AddComponents(bottone11, bottone12);
                                        break;
                                    case 13:
                                        messagefile.AddComponents(bottone11, bottone12, bottone13);
                                        break;
                                    case 14:
                                        messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14);
                                        break;
                                    case 15:
                                        messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                        break;
                                }
                                messagefile.AddComponents(bottone25);
                            }
                            else if (nBott <= 20)
                            {
                                messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                switch (nBott)
                                {
                                    case 16:
                                        messagefile.AddComponents(bottone16);
                                        break;
                                    case 17:
                                        messagefile.AddComponents(bottone16, bottone17);
                                        break;
                                    case 18:
                                        messagefile.AddComponents(bottone16, bottone17, bottone18);
                                        break;
                                    case 19:
                                        messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19);
                                        break;
                                    case 20:
                                        messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19, bottone20);
                                        break;
                                }
                                messagefile.AddComponents(bottone25);
                            }
                            else if (nBott <= 24)
                            {
                                messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19, bottone20);
                                switch (nBott)
                                {
                                    case 21:
                                        messagefile.AddComponents(bottone21, bottone25);
                                        break;
                                    case 22:
                                        messagefile.AddComponents(bottone21, bottone22, bottone25);
                                        break;
                                    case 23:
                                        messagefile.AddComponents(bottone21, bottone22, bottone23, bottone25);
                                        break;
                                    case 24:
                                        messagefile.AddComponents(bottone21, bottone22, bottone23, bottone24, bottone25);
                                        break;

                                }
                            }
                            #endregion



                            //   await ctx.RespondAsync(messagefile);

                            await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddFile(stream).AddComponents(messagefile.Components));

                            stream.Close();
                        }

                        System.IO.File.Delete(path + args.Guild.Id + ".png");
                        //    await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DSharpPlus.Entities.DiscordInteractionResponseBuilder().WithContent($"{args.Interaction.Data.CustomId} has been pressed"));
                    }
                }
                #endregion
            }
            else if (args.Interaction.Data.CustomId == "openParallelo")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 90);

                var q = new AllSlashCommands();


                string[] imagePaths = { "", "", "", "", "", "", "", "" };
                string imagePath = $"{args.Guild.Id}.png";


                var bottone1 = new DiscordButtonComponent(q.GetButtonColor(userRune, 0, "parallelo"), "1", q.GetButtonName4(userRune, 0));
                var bottone2 = new DiscordButtonComponent(q.GetButtonColor(userRune, 1, "parallelo"), "2", q.GetButtonName4(userRune, 1));
                var bottone3 = new DiscordButtonComponent(q.GetButtonColor(userRune, 2, "parallelo"), "3", q.GetButtonName4(userRune, 2));
                var bottone4 = new DiscordButtonComponent(q.GetButtonColor(userRune, 3, "parallelo"), "4", q.GetButtonName4(userRune, 3));
                var bottone5 = new DiscordButtonComponent(q.GetButtonColor(userRune, 4, "parallelo"), "5", q.GetButtonName4(userRune, 4));
                var bottone6 = new DiscordButtonComponent(q.GetButtonColor(userRune, 5, "parallelo"), "6", q.GetButtonName4(userRune, 5));
                var bottone7 = new DiscordButtonComponent(q.GetButtonColor(userRune, 6, "parallelo"), "7", q.GetButtonName4(userRune, 6));
                var bottone8 = new DiscordButtonComponent(q.GetButtonColor(userRune, 7, "parallelo"), "8", q.GetButtonName4(userRune, 7));

                string uno = "";
                string due = "";
                if (userRune.data[70] == 1)
                {
                    uno = "Modifica grandezza Sigillo Parallelo";
                    due = "Risolvi il Sigillo Parallelo";
                } 
                else
                {
                    uno = "Modifica grandezza primo Sigillo Parallelo";
                    due = "Risolvi il primo Sigillo Parallelo";
                }

                var editSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "editsigilloparallelo", uno);
                var closeParal = new DiscordButtonComponent(ButtonStyle.Secondary, "closeParallelo", due);
                var openParal2 = new DiscordButtonComponent(ButtonStyle.Secondary, "secondoParallelo", "Apri un secondo Sigillo Parallelo");



                var random = new Random();

                for (int i = 0; i < 8; i++)
                {
                    if (userRune.data[i + 73] != -1)
                    {
                        imagePaths[i] = (userRune.data[i + 73] + 1).ToString();
                    }
                    else
                    {
                        switch (random.Next(0, 2))
                        {
                            case 0:
                                imagePaths[i] = "01";
                                break;
                            case 1:
                                imagePaths[i] = "02";
                                break;
                            case 2:
                                imagePaths[i] = "03";
                                break;
                        }


                    }
                }



                var imageToSend = new ImagesManager();
                imageToSend.ImageStuff(args.Guild.Id, path, imagePaths, userRune.data[72], "parallelo");

                string lollo = "";
                if (userRune.data[70] == 1)
                {
                    lollo = "Sigillo Parallelo";
                }
                else
                {
                    lollo = "Primo Sigillo Parallelo";
                }

                if (System.IO.File.Exists(path + imagePath))
                {
                    using (var stream = new FileStream(path + imagePath, FileMode.Open))
                    {
                        DiscordMessageBuilder messagefile = new DiscordMessageBuilder()
                        .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)

                         
                         .WithTitle(lollo))


                        .AddFile(stream);
                        #region suffering2 //////////////////////////////////////////////////////////////////////////////////////////////
                        switch (userRune.data[71])
                        {
                            case 4:
                                switch (userRune.data[72])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        messagefile.AddComponents(bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        messagefile.AddComponents(bottone3, bottone4);
                                        break;

                                }
                                break;
                            case 5:
                            case 6:
                                switch (userRune.data[72])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4);
                                        break;
                                    case 5:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4, bottone5);
                                        break;
                                    case 6:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4, bottone5, bottone6);
                                        break;

                                }
                                break;
                            case 7:
                            case 8:
                                switch (userRune.data[72])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        break;
                                    case 5:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5);
                                        break;
                                    case 6:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6);
                                        break;
                                    case 7:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6, bottone7);
                                        break;
                                    case 8:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6, bottone7, bottone8);
                                        break;

                                }
                                break;

                        }

                     
                        if (userRune.data[70] == 1)
                            messagefile.AddComponents(editSigillo, closeParal, openParal2);
                        else
                            messagefile.AddComponents(editSigillo, closeParal);
                        #endregion

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddFile(stream).AddComponents(messagefile.Components));

                        stream.Close();
                    }

                    System.IO.File.Delete(path + args.Guild.Id + ".png");


                }







            }
            else if (args.Interaction.Data.CustomId == "closeParallelo")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 91);

                var embedo = new DiscordEmbedBuilder();
                if (userRune.data[70] == 1)
                embedo.Title = "Il Sigillo Parallelo è stato risolto";
                if (userRune.data[70] == 3)
                    embedo.Title = "Il primo Sigillo Parallelo è stato risolto";

                embedo.Color = DiscordColor.Azure;

                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

            }
            else if (args.Interaction.Data.CustomId == "secondoParallelo")
            {

                var userRune = new RuneSystem(0, args.Guild.Id, 92);

                var q = new AllSlashCommands();


                string[] imagePaths = { "", "", "", "", "", "", "", "" };
                string imagePath = $"{args.Guild.Id}.png";


                var bottone1 = new DiscordButtonComponent(q.GetButtonColor(userRune, 0, "parallelo2"), "1", q.GetButtonName6(userRune, 0));
                var bottone2 = new DiscordButtonComponent(q.GetButtonColor(userRune, 1, "parallelo2"), "2", q.GetButtonName6(userRune, 1));
                var bottone3 = new DiscordButtonComponent(q.GetButtonColor(userRune, 2, "parallelo2"), "3", q.GetButtonName6(userRune, 2));
                var bottone4 = new DiscordButtonComponent(q.GetButtonColor(userRune, 3, "parallelo2"), "4", q.GetButtonName6(userRune, 3));
                var bottone5 = new DiscordButtonComponent(q.GetButtonColor(userRune, 4, "parallelo2"), "5", q.GetButtonName6(userRune, 4));
                var bottone6 = new DiscordButtonComponent(q.GetButtonColor(userRune, 5, "parallelo2"), "6", q.GetButtonName6(userRune, 5));
                var bottone7 = new DiscordButtonComponent(q.GetButtonColor(userRune, 6, "parallelo2"), "7", q.GetButtonName6(userRune, 6));
                var bottone8 = new DiscordButtonComponent(q.GetButtonColor(userRune, 7, "parallelo2"), "8", q.GetButtonName6(userRune, 7));

                var editSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "editsigilloparallelo2", "Modifica grandezza secondo Sigillo Parallelo");
                var closeParal = new DiscordButtonComponent(ButtonStyle.Secondary, "closeParallelo2", "Risolvi il secondo Sigillo Parallelo");



                var random = new Random();

                for (int i = 0; i < 8; i++)
                {
                    if (userRune.data[i + 83] != -1)
                    {
                        imagePaths[i] = (userRune.data[i + 83] + 1).ToString();
                    }
                    else
                    {
                        switch (random.Next(0, 2))
                        {
                            case 0:
                                imagePaths[i] = "01";
                                break;
                            case 1:
                                imagePaths[i] = "02";
                                break;
                            case 2:
                                imagePaths[i] = "03";
                                break;
                        }


                    }
                }



                var imageToSend = new ImagesManager();
                imageToSend.ImageStuff(args.Guild.Id, path, imagePaths, userRune.data[82], "parallelo2");



                if (System.IO.File.Exists(path + imagePath))
                {
                    using (var stream = new FileStream(path + imagePath, FileMode.Open))
                    {
                        DiscordMessageBuilder messagefile = new DiscordMessageBuilder()
                        .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("Secondo Sigillo Parallelo"))
                        .AddFile(stream);
                        #region suffering2 //////////////////////////////////////////////////////////////////////////////////////////////
                        switch (userRune.data[81])
                        {
                            case 4:
                                switch (userRune.data[82])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        messagefile.AddComponents(bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        messagefile.AddComponents(bottone3, bottone4);
                                        break;

                                }
                                break;
                            case 5:
                            case 6:
                                switch (userRune.data[82])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4);
                                        break;
                                    case 5:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4, bottone5);
                                        break;
                                    case 6:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        messagefile.AddComponents(bottone4, bottone5, bottone6);
                                        break;

                                }
                                break;
                            case 7:
                            case 8:
                                switch (userRune.data[82])
                                {
                                    case 1:
                                        messagefile.AddComponents(bottone1);
                                        break;
                                    case 2:
                                        messagefile.AddComponents(bottone1, bottone2);
                                        break;
                                    case 3:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3);
                                        break;
                                    case 4:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        break;
                                    case 5:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5);
                                        break;
                                    case 6:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6);
                                        break;
                                    case 7:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6, bottone7);
                                        break;
                                    case 8:
                                        messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                        messagefile.AddComponents(bottone5, bottone6, bottone7, bottone8);
                                        break;

                                }
                                break;

                        }
                        messagefile.AddComponents(editSigillo, closeParal);
                        #endregion

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddFile(stream).AddComponents(messagefile.Components));

                        stream.Close();
                    }

                    System.IO.File.Delete(path + args.Guild.Id + ".png");


                }





            }
            else if (args.Interaction.Data.CustomId == "closeParallelo2")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 93);

                var embedo = new DiscordEmbedBuilder();
                embedo.Title = "Il secondo Sigillo Parallelo è stato risolto";
                embedo.Color = DiscordColor.Azure;

                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

            }
            else if (args.Interaction.Data.CustomId == "clearsigillo")
            {
                var userRune = new RuneSystem(0, args.Guild.Id, 50);
                var embedo = new DiscordEmbedBuilder();
                embedo.Title = "Il Sigillo è stato risolto";
                embedo.Color = DiscordColor.Green;

                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

            }
            else if (args.Interaction.Data.CustomId == "toEstratte")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 1)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 4, "sacchetto");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata estratta!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));


                }
            }
            else if (args.Interaction.Data.CustomId == "toVoid")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 1)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 60, "sacchetto");


                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata rimossa dal gioco per il prossimo tiro!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }

            }
            else if (args.Interaction.Data.CustomId == "toSacchetto")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 3)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 5, "sigilloFato");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata rimessa nel sacchetto!";
                    embedo.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }
                else if (userRuneQQ.data[68] == 2)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 5, "sigillo");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata rimessa nel sacchetto";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }


                else if (userRuneQQ.data[68] == 4)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 5, "parallelo");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata rimessa nel sacchetto";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }
                else if (userRuneQQ.data[68] == 5)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 5, "parallelo2");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata rimessa nel sacchetto";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }

            }
            else if (args.Interaction.Data.CustomId == "toSigillo")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 3)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 6, "sigilloFato");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo!";
                    embedo.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }
                else if (userRuneQQ.data[68] == 0)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 6, "estratte");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata messa nel Sigillo!";
                    embedo.Color = DiscordColor.Azure;
                    DiscordMessageBuilder postADD = new DiscordMessageBuilder();
                    var ri = new DiscordButtonComponent(ButtonStyle.Primary, "rimescola", "Rimescola rune nel sacchetto");
                    var re = new DiscordButtonComponent(ButtonStyle.Primary, "reopen", "Metti un'altra runa in un Sigillo");
                    postADD.AddComponents(ri, re);
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo).AddComponents(postADD.Components));
                }
                else if (userRuneQQ.data[68] == 4)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 6, "parallelo");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
                else if (userRuneQQ.data[68] == 5)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 6, "parallelo2");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }

            }
            else if (args.Interaction.Data.CustomId == "toSigilloFato")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 2)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 7, "sigillo");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo del Fato!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
                else if (userRuneQQ.data[68] == 0)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 7, "estratte");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata messa nel Sigillo del Fato!";
                    embedo.Color = DiscordColor.Azure;
                    DiscordMessageBuilder postADD = new DiscordMessageBuilder();
                    var ri = new DiscordButtonComponent(ButtonStyle.Primary, "rimescola", "Rimescola rune nel sacchetto");
                    var re = new DiscordButtonComponent(ButtonStyle.Primary, "reopen", "Metti un'altra runa in un Sigillo");
                    postADD.AddComponents(ri, re);
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo).AddComponents(postADD.Components));
                }
                else if (userRuneQQ.data[68] == 4)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 7, "parallelo");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo del Fato!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
                else if (userRuneQQ.data[68] == 5)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 7, "parallelo2");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel Sigillo del Fato!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }

            }
            else if (args.Interaction.Data.CustomId == "toSigilloParallelo")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 2)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 25, "sigillo");

                    var embedo = new DiscordEmbedBuilder();
                    if (userRuneQQ.data[70] == 1)
                    embedo.Title = $"la runa è stata spostata nel Sigillo Parallelo!";
                    if (userRuneQQ.data[70] == 3)
                        embedo.Title = $"la runa è stata spostata nel primo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
                else if (userRuneQQ.data[68] == 0)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 25, "estratte");
                    var embedo = new DiscordEmbedBuilder();
                    if (userRuneQQ.data[70] == 1)
                        embedo.Title = $"la runa è stata messa nel Sigillo Parallelo!";
                    if (userRuneQQ.data[70] == 3)
                        embedo.Title = $"la runa è stata messa nel primo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    DiscordMessageBuilder postADD = new DiscordMessageBuilder();
                    var ri = new DiscordButtonComponent(ButtonStyle.Primary, "rimescola", "Rimescola rune nel sacchetto");
                    var re = new DiscordButtonComponent(ButtonStyle.Primary, "reopen", "Metti un'altra runa in un Sigillo");
                    postADD.AddComponents(ri, re);
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo).AddComponents(postADD.Components));
                }
                else if (userRuneQQ.data[68] == 3)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 25, "sigilloFato");

                    var embedo = new DiscordEmbedBuilder();
                    if (userRuneQQ.data[70] == 1)
                        embedo.Title = $"la runa è stata spostata nel Sigillo Parallelo!";
                    if (userRuneQQ.data[70] == 3)
                        embedo.Title = $"la runa è stata spostata nel primo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }
                else if (userRuneQQ.data[68] == 5)
                {

                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 25, "parallelo2");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel primo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }

            }
            else if (args.Interaction.Data.CustomId == "toSigilloParallelo2")
            {
                var userRuneQQ = new RuneSystem(0, args.Guild.Id, 69);

                if (userRuneQQ.data[68] == 2)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 26, "sigillo");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel secondo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
                else if (userRuneQQ.data[68] == 0)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 26, "estratte");
                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata messa nel secondo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    DiscordMessageBuilder postADD = new DiscordMessageBuilder();
                    var ri = new DiscordButtonComponent(ButtonStyle.Primary, "rimescola", "Rimescola rune nel sacchetto");
                    var re = new DiscordButtonComponent(ButtonStyle.Primary, "reopen", "Metti un'altra runa in un Sigillo");
                    postADD.AddComponents(ri, re);
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo).AddComponents(postADD.Components));
                }
                else if (userRuneQQ.data[68] == 3)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 26, "sigilloFato");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel secondo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Red;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
                }
                else if (userRuneQQ.data[68] == 4)
                {
                    userRuneQQ = new RuneSystem(0, args.Guild.Id, 26, "parallelo");

                    var embedo = new DiscordEmbedBuilder();
                    embedo.Title = $"la runa è stata spostata nel secondo Sigillo Parallelo!";
                    embedo.Color = DiscordColor.Azure;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));

                }
            }
            else if (args.Interaction.Data.CustomId == "editsigillo")
            {

                DiscordMessageBuilder messagefileSigillo = new DiscordMessageBuilder();


                var s2 = new DiscordButtonComponent(ButtonStyle.Primary, "s2", "2");
                var s3 = new DiscordButtonComponent(ButtonStyle.Primary, "s3", "3");
                var s4 = new DiscordButtonComponent(ButtonStyle.Primary, "s4", "4");
                var s5 = new DiscordButtonComponent(ButtonStyle.Primary, "s5", "5");
                var s6 = new DiscordButtonComponent(ButtonStyle.Primary, "s6", "6");
                var s7 = new DiscordButtonComponent(ButtonStyle.Primary, "s7", "7");
                var s8 = new DiscordButtonComponent(ButtonStyle.Primary, "s8", "8");

                messagefileSigillo.AddComponents(s2, s3, s4, s5);
                messagefileSigillo.AddComponents(s6, s7, s8);

                var embed9 = new DiscordEmbedBuilder();

                embed9.Title = "Seleziona la dimensione del Sigillo";
                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddComponents(messagefileSigillo.Components));

                //   await args.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder().AddComponents(messagefileSigillo.Components).AddEmbed(embed9));


            }
            else if (args.Interaction.Data.CustomId == "editsigillofato")
            {

                DiscordMessageBuilder messagefileSigillo = new DiscordMessageBuilder();


                var s4 = new DiscordButtonComponent(ButtonStyle.Primary, "sf4", "4");
                var s5 = new DiscordButtonComponent(ButtonStyle.Primary, "sf5", "5");
                var s6 = new DiscordButtonComponent(ButtonStyle.Primary, "sf6", "6");
                var s7 = new DiscordButtonComponent(ButtonStyle.Primary, "sf7", "7");
                var s8 = new DiscordButtonComponent(ButtonStyle.Primary, "sf8", "8");

                messagefileSigillo.AddComponents(s4, s5, s6);
                messagefileSigillo.AddComponents(s7, s8);

                var embed9 = new DiscordEmbedBuilder();

                embed9.Title = "Seleziona la dimensione del Sigillo del Fato";
                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddComponents(messagefileSigillo.Components));

                //   await args.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder().AddComponents(messagefileSigillo.Components).AddEmbed(embed9));


            }
            else if (args.Interaction.Data.CustomId == "editsigilloparallelo")
            {

                DiscordMessageBuilder messagefileSigillo = new DiscordMessageBuilder();

                var userRune = new RuneSystem(0, args.Guild.Id, 69);

                var p2 = new DiscordButtonComponent(ButtonStyle.Primary, "p2", "2");
                var p3 = new DiscordButtonComponent(ButtonStyle.Primary, "p3", "3");
                var p4 = new DiscordButtonComponent(ButtonStyle.Primary, "p4", "4");
                var p5 = new DiscordButtonComponent(ButtonStyle.Primary, "p5", "5");
                var p6 = new DiscordButtonComponent(ButtonStyle.Primary, "p6", "6");
                var p7 = new DiscordButtonComponent(ButtonStyle.Primary, "p7", "7");
                var p8 = new DiscordButtonComponent(ButtonStyle.Primary, "p8", "8");

                messagefileSigillo.AddComponents(p2, p3, p4, p5);
                messagefileSigillo.AddComponents(p6, p7, p8);

                var embed9 = new DiscordEmbedBuilder();

                embed9.Title = "Seleziona la dimensione del Sigillo Parallelo";


                if (userRune.data[70] == 1)
                    embed9.Title = $"Seleziona la dimensione del Sigillo Parallelo";
                if (userRune.data[70] == 3)
                    embed9.Title = $"Seleziona la dimensione del primo Sigillo Parallelo";


                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddComponents(messagefileSigillo.Components));

                //   await args.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder().AddComponents(messagefileSigillo.Components).AddEmbed(embed9));




            }
            else if (args.Interaction.Data.CustomId == "editsigilloparallelo2")
            {

                DiscordMessageBuilder messagefileSigillo = new DiscordMessageBuilder();



                var p22 = new DiscordButtonComponent(ButtonStyle.Primary, "p22", "2");
                var p23 = new DiscordButtonComponent(ButtonStyle.Primary, "p23", "3");
                var p24 = new DiscordButtonComponent(ButtonStyle.Primary, "p24", "4");
                var p25 = new DiscordButtonComponent(ButtonStyle.Primary, "p25", "5");
                var p26 = new DiscordButtonComponent(ButtonStyle.Primary, "p26", "6");
                var p27 = new DiscordButtonComponent(ButtonStyle.Primary, "p27", "7");
                var p28 = new DiscordButtonComponent(ButtonStyle.Primary, "p28", "8");

                messagefileSigillo.AddComponents(p22, p23, p24, p25);
                messagefileSigillo.AddComponents(p26, p27, p28);

                var embed9 = new DiscordEmbedBuilder();

                embed9.Title = "Seleziona la dimensione del secondo Sigillo Parallelo";
                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddComponents(messagefileSigillo.Components));

                //   await args.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder().AddComponents(messagefileSigillo.Components).AddEmbed(embed9));




            }
            else if (args.Interaction.Data.CustomId == "clear")
            {
                Console.Clear();
                var embedo = new DiscordEmbedBuilder();
                embedo.Title = ":3";
                embedo.Color = DiscordColor.Purple;

                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embedo));
            }
            if (int.TryParse(args.Interaction.Data.CustomId, out int result))
            {
                if (args.Interaction.Data.CustomId == "25")
                {
                    var userRune = new RuneSystem(0, args.Channel.Guild.Id, 1);
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.Title = "Rune rimesse nel sacchetto";
                    embed2.Color = DiscordColor.Blue;
                    await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed2));
                }
                else if (int.Parse(args.Interaction.Data.CustomId) <= 25 && int.Parse(args.Interaction.Data.CustomId) > 0 || args.Interaction.Data.CustomId == "reopen")
                {
                    var userRune = new RuneSystem(int.Parse(args.Interaction.Data.CustomId), args.Guild.Id, 10);
                    int buttonPressed = int.Parse(args.Interaction.Data.CustomId) - 1;

                    if (userRune.data[68] == 2) // a schermo è stampato il sigillo
                    {

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        //  var toSacchetto = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", "Rimetti nel sacchetto");
                        var toSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", $"Rimescola nel sacchetto");
                        var toSigilloFato = new DiscordButtonComponent(ButtonStyle.Danger, "toSigilloFato", $"Sposta nel Sigillo del Fato ({userRune.data[67]}/{userRune.data[65]} )");


                        string uno = "";
                        if (userRune.data[70] == 1)
                        {
                            uno = $"Sposta nel Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }
                        else
                        {
                            uno = $"Sposta nel primo Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }


                        var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo", uno);
                        var toSigilloFatottt = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo2", $"Sposta nel secondo Sigillo Parallelo ({userRune.data[82]}/{userRune.data[81]} )");

                        messagefile2.AddComponents(toSigillo, toSigilloFato);
                        Console.Write("1\n");
                        if (userRune.data[70] == 1)
                        {
                            Console.Write("2\n");
                            messagefile2.AddComponents(toSigilloFatott);
                        }
                        else if (userRune.data[70] == 3)
                        {
                            Console.Write("3\n");
                            messagefile2.AddComponents(toSigilloFatott, toSigilloFatottt);
                        }
                        Console.Write("4\n");
                        var embed = new DiscordEmbedBuilder();
                        embed.Title = $"{userRune.descrizioniRune[userRune.data[userRune.data[69] + 48 - 1]]}";
                        if (userRune.data[buttonPressed + 48] < 8)
                        {
                            embed.Color = DiscordColor.Green;
                        }
                        else if (userRune.data[buttonPressed + 48] < 16)
                        {
                            embed.Color = DiscordColor.Blue;
                        }
                        else
                        {
                            embed.Color = DiscordColor.Red;
                        }

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed).AddComponents(messagefile2.Components));


                    }
                    else if (userRune.data[68] == 3)// a schermo è stampato il sigillo fato
                    {

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        //  var toSacchetto = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", "Rimetti nel sacchetto");
                        var toSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", $"Rimescola nel sacchetto");
                        var toSigilloFato = new DiscordButtonComponent(ButtonStyle.Primary, "toSigillo", $"Sposta nel Sigillo ({userRune.data[66]}/{userRune.data[64]} )");

                        string uno = "";
                        if (userRune.data[70] == 1)
                        {
                            uno = $"Sposta nel Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }
                        else
                        {
                            uno = $"Sposta nel primo Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }


                        var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo", uno);
                        var toSigilloFatottt = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo2", $"Sposta nel secondo Sigillo Parallelo ({userRune.data[82]}/{userRune.data[81]} )");

                        messagefile2.AddComponents(toSigillo, toSigilloFato);
                        if (userRune.data[70] == 1)
                        {
                            messagefile2.AddComponents(toSigilloFatott);
                        }
                        else if (userRune.data[70] == 3)
                        {
                            messagefile2.AddComponents(toSigilloFatott, toSigilloFatottt);
                        }
                      


                        var embed = new DiscordEmbedBuilder();

                        embed.Title = $"{userRune.descrizioniRune[userRune.data[userRune.data[69] + 56 - 1]]}";
                        if (userRune.data[buttonPressed + 56] < 8)
                        {
                            embed.Color = DiscordColor.Green;
                        }
                        else if (userRune.data[buttonPressed + 56] < 16)
                        {
                            embed.Color = DiscordColor.Blue;
                        }
                        else
                        {
                            embed.Color = DiscordColor.Red;
                        }

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed).AddComponents(messagefile2.Components));





                    }
                    else if (userRune.data[68] == 4)// a schermo è stampato il sigillo parallelo
                    {

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        //  var toSacchetto = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", "Rimetti nel sacchetto");
                        var toSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", $"Rimescola nel sacchetto");
                        var toSigilloFato = new DiscordButtonComponent(ButtonStyle.Primary, "toSigillo", $"Sposta nel Sigillo ({userRune.data[66]}/{userRune.data[64]} )");
                        var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Danger, "toSigilloFato", $"Sposta nel Sigillo del Fato ({userRune.data[67]}/{userRune.data[65]} )");
                        var toSigilloFatottt = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo2", $"Sposta nel secondo Sigillo Parallelo ({userRune.data[82]}/{userRune.data[81]} )");



                        messagefile2.AddComponents(toSigillo, toSigilloFato, toSigilloFatott);
                        if (userRune.data[70] == 3)
                            messagefile2.AddComponents(toSigilloFatottt);

                        var embed = new DiscordEmbedBuilder();

                        Console.Write("------------ " + int.Parse(args.Interaction.Data.CustomId));
                        embed.Title = $"{userRune.descrizioniRune[userRune.data[userRune.data[69] + 73 - 1]]}";
                        if (userRune.data[buttonPressed + 73] < 8)
                        {
                            embed.Color = DiscordColor.Green;
                        }
                        else if (userRune.data[buttonPressed + 73] < 16)
                        {
                            embed.Color = DiscordColor.Blue;
                        }
                        else
                        {
                            embed.Color = DiscordColor.Red;
                        }

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed).AddComponents(messagefile2.Components));





                    }
                    else if (userRune.data[68] == 5)// a schermo è stampato il sigillo parallelo 2
                    {

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        //  var toSacchetto = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", "Rimetti nel sacchetto");
                        var toSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", $"Rimescola nel sacchetto");
                        var toSigilloFato = new DiscordButtonComponent(ButtonStyle.Primary, "toSigillo", $"Sposta nel Sigillo ({userRune.data[66]}/{userRune.data[64]} )");
                        var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Danger, "toSigilloFato", $"Sposta nel Sigillo del Fato ({userRune.data[67]}/{userRune.data[65]} )");
                        var toSigilloFatottololo = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo", $"Sposta nel primo Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )");



                        messagefile2.AddComponents(toSigillo, toSigilloFato, toSigilloFatott);
                        messagefile2.AddComponents(toSigilloFatottololo);

                        var embed = new DiscordEmbedBuilder();

                        embed.Title = $"{userRune.descrizioniRune[userRune.data[userRune.data[69] + 83 - 1]]}";
                        if (userRune.data[buttonPressed + 73] < 8)
                        {
                            embed.Color = DiscordColor.Green;
                        }
                        else if (userRune.data[buttonPressed + 73] < 16)
                        {
                            embed.Color = DiscordColor.Blue;
                        }
                        else
                        {
                            embed.Color = DiscordColor.Red;
                        }

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed).AddComponents(messagefile2.Components));





                    }
                    else if (userRune.data[68] == 1)// a schermo è stampato il sacchetto
                    {

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        var rimuovi = new DiscordButtonComponent(ButtonStyle.Secondary, "toVoid", "Rimuovi dal sacchetto");
                        var estrai = new DiscordButtonComponent(ButtonStyle.Secondary, "toEstratte", "Estrai");

                        messagefile2.AddComponents(rimuovi, estrai);

                        var embed = new DiscordEmbedBuilder();


                        int q = 0;
                        for (int i = 0; i < 24; i++)
                        {
                            if (userRune.data[i] == 0)
                            {
                                if (q == buttonPressed)
                                {
                                    embed.Title = $"{userRune.descrizioniRune[i]}";
                                    if (i < 8)
                                    {
                                        embed.Color = DiscordColor.Green;
                                    }
                                    else if (i < 16)
                                    {
                                        embed.Color = DiscordColor.Blue;
                                    }
                                    else
                                    {
                                        embed.Color = DiscordColor.Red;
                                    }
                                    userRune = new RuneSystem(i, args.Guild.Id, 10);
                                    i = 50;
                                }
                                q++;
                            }
                            
                        }

                       

                        await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddEmbed(embed).AddComponents(messagefile2.Components));

                        



                    }
                    else if (userRune.data[userRune.data[24 + buttonPressed]] == 3) // la runa cliccata è coperta
                    {
                        userRune = new RuneSystem(userRune.data[24 + buttonPressed], args.Guild.Id, 3);
                        refresh = true;
                    }
                    else
                    {

                        #region stampa immagine senza bottoni ////////////////////////////////////////////////////////////////////////////////////

                        var q = new AllCommands();
                      
                        string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                        string imagePath = $"{args.Guild.Id}.png";
                        int nBott = 0;

                        for (int i = 0; i < 24; i++)
                        {
                            if (userRune.data[24 + i] != -1)
                            {
                                nBott++;
                            }
                            else
                            {
                                i = 50;
                            }
                        }
                        var random = new Random();
                        for (int i = 0; i < 24; i++)
                        {
                            if (userRune.data[i + 24] != -1)
                            {
                                if (userRune.data[userRune.data[i + 24]] == 2)
                                {
                                    imagePaths[i] = (userRune.data[i + 24] + 1).ToString();
                                }
                                else if (userRune.data[userRune.data[i + 24]] == 3)
                                {
                                    switch (random.Next(0, 3))
                                    {
                                        case 0:
                                            imagePaths[i] = "01";
                                            break;
                                        case 1:
                                            imagePaths[i] = "02";
                                            break;
                                        case 2:
                                            imagePaths[i] = "03";
                                            break;
                                    }
                                }
                            }
                            else
                                i = 25;
                        }
                        var imageToSend = new ImagesManager();
                        imageToSend.ImageStuff(args.Guild.Id, path, imagePaths, nBott);
                        if (System.IO.File.Exists(path + imagePath))
                        {
                            using (var stream = new FileStream(path + imagePath, FileMode.Open))
                            {
                                DiscordMessageBuilder messagefile = new DiscordMessageBuilder();
                                /*    .AddEmbed(new DiscordEmbedBuilder()
                                     .WithColor(DiscordColor.Purple)
                                     .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                                //.AddFile(stream);


                                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddFile(stream).AddComponents(messagefile.Components));

                                stream.Close();
                            }

                            System.IO.File.Delete(path + args.Guild.Id + ".png");

                        }



                        #endregion

                        DiscordMessageBuilder messagefile2 = new DiscordMessageBuilder();

                        //  var toSacchetto = new DiscordButtonComponent(ButtonStyle.Secondary, "toSacchetto", "Rimetti nel sacchetto");
                        var toSigillo = new DiscordButtonComponent(ButtonStyle.Success, "toSigillo", $"Metti nel Sigillo ({userRune.data[66]}/{userRune.data[64]} )");
                        var toSigilloFato = new DiscordButtonComponent(ButtonStyle.Danger, "toSigilloFato", $"Metti nel Sigillo del Fato ({userRune.data[67]}/{userRune.data[65]} )");
                        //    var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo", $"Sposta nel Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )");

                        string uno = "";
                        if (userRune.data[70] == 1)
                        {
                            uno = $"Sposta nel Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }
                        else
                        {
                            uno = $"Sposta nel primo Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]} )";
                        }

                        var toSigilloFatott = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo", uno);
                        var toSigilloFatottt = new DiscordButtonComponent(ButtonStyle.Success, "toSigilloParallelo2", $"Sposta nel secondo Sigillo Parallelo ({userRune.data[82]}/{userRune.data[81]} )");


                        var another = new DiscordButtonComponent(ButtonStyle.Secondary, "reopen", $"Torna alle rune tirate");


                        messagefile2.AddComponents(toSigillo, toSigilloFato);
                        if (userRune.data[70] == 1)
                        {
                            messagefile2.AddComponents(toSigilloFatott);
                        }
                        else if (userRune.data[70] == 3)
                        {
                            messagefile2.AddComponents(toSigilloFatott, toSigilloFatottt);
                        }

                        messagefile2.AddComponents(another);



                        var embed = new DiscordEmbedBuilder();

                        embed.Title = $"{userRune.descrizioniRune[userRune.data[buttonPressed + 24]]}";
                        if (userRune.data[buttonPressed + 24] < 8)
                        {
                            embed.Color = DiscordColor.Green;
                        }
                        else if (userRune.data[buttonPressed + 24] < 16)
                        {
                            embed.Color = DiscordColor.Blue;
                        }
                        else
                        {
                            embed.Color = DiscordColor.Red;
                        }

                        await args.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder().AddComponents(messagefile2.Components).AddEmbed(embed));


                    }


                    #region refresh block /////////////////////////////////////////////////////////////////////////////////////
                    if (refresh)
                    {
                        var q = new AllSlashCommands();
                     
                        string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                        string imagePath = $"{args.Guild.Id}.png";
                        int nBott = 0;


                        for (int i = 0; i < 24; i++)
                        {
                            if (userRune.data[24 + i] != -1)
                            {
                                nBott++;
                            }
                            else
                            {
                                i = 50;
                            }
                        }

                        #region pain ///////////////////////////////////////////////////////////////////////////////////////////////
                        var bottone1 = new DiscordButtonComponent(q.GetButtonColor(userRune, 0), "1", q.GetButtonName(userRune, 0));
                        var bottone2 = new DiscordButtonComponent(q.GetButtonColor(userRune, 1), "2", q.GetButtonName(userRune, 1));
                        var bottone3 = new DiscordButtonComponent(q.GetButtonColor(userRune, 2), "3", q.GetButtonName(userRune, 2));
                        var bottone4 = new DiscordButtonComponent(q.GetButtonColor(userRune, 3), "4", q.GetButtonName(userRune, 3));
                        var bottone5 = new DiscordButtonComponent(q.GetButtonColor(userRune, 4), "5", q.GetButtonName(userRune, 4));
                        var bottone6 = new DiscordButtonComponent(q.GetButtonColor(userRune, 5), "6", q.GetButtonName(userRune, 5));
                        var bottone7 = new DiscordButtonComponent(q.GetButtonColor(userRune, 6), "7", q.GetButtonName(userRune, 6));
                        var bottone8 = new DiscordButtonComponent(q.GetButtonColor(userRune, 7), "8", q.GetButtonName(userRune, 7));
                        var bottone9 = new DiscordButtonComponent(q.GetButtonColor(userRune, 8), "9", q.GetButtonName(userRune, 8));
                        var bottone10 = new DiscordButtonComponent(q.GetButtonColor(userRune, 9), "10", q.GetButtonName(userRune, 9));
                        var bottone11 = new DiscordButtonComponent(q.GetButtonColor(userRune, 10), "11", q.GetButtonName(userRune, 10));
                        var bottone12 = new DiscordButtonComponent(q.GetButtonColor(userRune, 11), "12", q.GetButtonName(userRune, 11));
                        var bottone13 = new DiscordButtonComponent(q.GetButtonColor(userRune, 12), "13", q.GetButtonName(userRune, 12));
                        var bottone14 = new DiscordButtonComponent(q.GetButtonColor(userRune, 13), "14", q.GetButtonName(userRune, 13));
                        var bottone15 = new DiscordButtonComponent(q.GetButtonColor(userRune, 14), "15", q.GetButtonName(userRune, 14));
                        var bottone16 = new DiscordButtonComponent(q.GetButtonColor(userRune, 15), "16", q.GetButtonName(userRune, 15));
                        var bottone17 = new DiscordButtonComponent(q.GetButtonColor(userRune, 16), "17", q.GetButtonName(userRune, 16));
                        var bottone18 = new DiscordButtonComponent(q.GetButtonColor(userRune, 17), "18", q.GetButtonName(userRune, 17));
                        var bottone19 = new DiscordButtonComponent(q.GetButtonColor(userRune, 18), "19", q.GetButtonName(userRune, 18));
                        var bottone20 = new DiscordButtonComponent(q.GetButtonColor(userRune, 19), "20", q.GetButtonName(userRune, 19));
                        var bottone21 = new DiscordButtonComponent(q.GetButtonColor(userRune, 20), "21", q.GetButtonName(userRune, 20));
                        var bottone22 = new DiscordButtonComponent(q.GetButtonColor(userRune, 21), "22", q.GetButtonName(userRune, 21));
                        var bottone23 = new DiscordButtonComponent(q.GetButtonColor(userRune, 22), "23", q.GetButtonName(userRune, 22));
                        var bottone24 = new DiscordButtonComponent(q.GetButtonColor(userRune, 23), "24", q.GetButtonName(userRune, 23));
                        var bottone25 = new DiscordButtonComponent(ButtonStyle.Secondary, "25", "Rimescola nel sacchetto");
                        #endregion
                        var random = new Random();
                        for (int i = 0; i < 24; i++)
                        {
                            if (userRune.data[i + 24] != -1)
                            {
                                if (userRune.data[userRune.data[i + 24]] == 2)
                                {
                                    imagePaths[i] = (userRune.data[i + 24] + 1).ToString();
                                }
                                else if (userRune.data[userRune.data[i + 24]] == 3)
                                {
                                    switch (random.Next(0, 3))
                                    {
                                        case 0:
                                            imagePaths[i] = "01";
                                            break;
                                        case 1:
                                            imagePaths[i] = "02";
                                            break;
                                        case 2:
                                            imagePaths[i] = "03";
                                            break;
                                    }
                                }
                            }
                            else
                                i = 25;
                        }
                        var imageToSend = new ImagesManager();
                        imageToSend.ImageStuff(args.Guild.Id, path, imagePaths, nBott);
                        if (System.IO.File.Exists(path + imagePath))
                        {
                            using (var stream = new FileStream(path + imagePath, FileMode.Open))
                            {
                                DiscordMessageBuilder messagefile = new DiscordMessageBuilder();
                                /*    .AddEmbed(new DiscordEmbedBuilder()
                                     .WithColor(DiscordColor.Purple)
                                     .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                                //.AddFile(stream);


                                #region suffering ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////      
                                if (nBott <= 5)
                                {
                                    switch (nBott)
                                    {
                                        case 1:
                                            messagefile.AddComponents(bottone1);
                                            break;
                                        case 2:
                                            messagefile.AddComponents(bottone1, bottone2);
                                            break;
                                        case 3:
                                            messagefile.AddComponents(bottone1, bottone2, bottone3);
                                            break;
                                        case 4:
                                            messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4);
                                            break;
                                        case 5:
                                            messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                            break;
                                    }
                                    messagefile.AddComponents(bottone25);
                                }
                                else if (nBott <= 10)
                                {
                                    messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                    switch (nBott)
                                    {
                                        case 6:
                                            messagefile.AddComponents(bottone6);
                                            break;
                                        case 7:
                                            messagefile.AddComponents(bottone6, bottone7);
                                            break;
                                        case 8:
                                            messagefile.AddComponents(bottone6, bottone7, bottone8);
                                            break;
                                        case 9:
                                            messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9);
                                            break;
                                        case 10:
                                            messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                            break;
                                    }
                                    messagefile.AddComponents(bottone25);
                                }
                                else if (nBott <= 15)
                                {
                                    messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                    messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                    switch (nBott)
                                    {
                                        case 11:
                                            messagefile.AddComponents(bottone11);
                                            break;
                                        case 12:
                                            messagefile.AddComponents(bottone11, bottone12);
                                            break;
                                        case 13:
                                            messagefile.AddComponents(bottone11, bottone12, bottone13);
                                            break;
                                        case 14:
                                            messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14);
                                            break;
                                        case 15:
                                            messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                            break;
                                    }
                                    messagefile.AddComponents(bottone25);
                                }
                                else if (nBott <= 20)
                                {
                                    messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                    messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                    messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                    switch (nBott)
                                    {
                                        case 16:
                                            messagefile.AddComponents(bottone16);
                                            break;
                                        case 17:
                                            messagefile.AddComponents(bottone16, bottone17);
                                            break;
                                        case 18:
                                            messagefile.AddComponents(bottone16, bottone17, bottone18);
                                            break;
                                        case 19:
                                            messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19);
                                            break;
                                        case 20:
                                            messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19, bottone20);
                                            break;
                                    }
                                    messagefile.AddComponents(bottone25);
                                }
                                else if (nBott <= 24)
                                {
                                    messagefile.AddComponents(bottone1, bottone2, bottone3, bottone4, bottone5);
                                    messagefile.AddComponents(bottone6, bottone7, bottone8, bottone9, bottone10);
                                    messagefile.AddComponents(bottone11, bottone12, bottone13, bottone14, bottone15);
                                    messagefile.AddComponents(bottone16, bottone17, bottone18, bottone19, bottone20);
                                    switch (nBott)
                                    {
                                        case 21:
                                            messagefile.AddComponents(bottone21, bottone25);
                                            break;
                                        case 22:
                                            messagefile.AddComponents(bottone21, bottone22, bottone25);
                                            break;
                                        case 23:
                                            messagefile.AddComponents(bottone21, bottone22, bottone23, bottone25);
                                            break;
                                        case 24:
                                            messagefile.AddComponents(bottone21, bottone22, bottone23, bottone24, bottone25);
                                            break;

                                    }
                                }
                                #endregion



                                //   await ctx.RespondAsync(messagefile);

                                await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder().AddFile(stream).AddComponents(messagefile.Components));

                                stream.Close();
                            }

                            System.IO.File.Delete(path + args.Guild.Id + ".png");
                            //    await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DSharpPlus.Entities.DiscordInteractionResponseBuilder().WithContent($"{args.Interaction.Data.CustomId} has been pressed"));
                        }
                    }
                    #endregion
                }
            }
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            if (pc == "tester")
            {
                Console.WriteLine("|| " + DateTime.Now.ToString("h:mm:ss tt") + " tester è online");
            }
            else if (pc == "server")
            {
                Console.WriteLine("|| " + DateTime.Now.ToString("h:mm:ss tt") + " server è online");
            }


            return Task.CompletedTask;
        }
    }
}
