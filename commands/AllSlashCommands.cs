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
using DSharpPlus.SlashCommands;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.Eventing.Reader;

namespace RunewayBot.SlashCommands
{

    public class AllSlashCommands : ApplicationCommandModule
    {
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////
        //    private static string pc = "server";
        private static string pc = "tester";
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////


        [SlashCommand("reset", "Resetta lo stato di tutte le rune, comprese quelle nei sigilli")]
        public async Task Reset(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(1, ctx.Channel.Guild.Id, 1);
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Tutte le rune rimesse nel sacchetto"));
        }


        [SlashCommand("estratte", "Mostra le rune gia estratte")]
        public async Task Estrazione(InteractionContext ctx)
        {

            await ctx.DeferAsync();

            var quantita = 0;


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
            

            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 69);

            int nrune = 0;
            for (int i = 0; i < 24; i++)
            {
                if (userRune.data[i] == 0)
                {
                    nrune++;
                }
            }
            if (quantita > nrune)
            {

                await ctx.Channel.SendMessageAsync($"Mi dispiace ma nel sacchetto ci sono solo {nrune} rune :(");

            }
            else
            {
                userRune = new RuneSystem((int)quantita, ctx.Channel.Guild.Id, 0);


                string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                string imagePath = $"{ctx.Guild.Id}.png";

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
                var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0), "1", GetButtonName(userRune, 0));
                var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1), "2", GetButtonName(userRune, 1));
                var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2), "3", GetButtonName(userRune, 2));
                var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3), "4", GetButtonName(userRune, 3));
                var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4), "5", GetButtonName(userRune, 4));
                var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5), "6", GetButtonName(userRune, 5));
                var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6), "7", GetButtonName(userRune, 6));
                var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7), "8", GetButtonName(userRune, 7));
                var bottone9 = new DiscordButtonComponent(GetButtonColor(userRune, 8), "9", GetButtonName(userRune, 8));
                var bottone10 = new DiscordButtonComponent(GetButtonColor(userRune, 9), "10", GetButtonName(userRune, 9));
                var bottone11 = new DiscordButtonComponent(GetButtonColor(userRune, 10), "11", GetButtonName(userRune, 10));
                var bottone12 = new DiscordButtonComponent(GetButtonColor(userRune, 11), "12", GetButtonName(userRune, 11));
                var bottone13 = new DiscordButtonComponent(GetButtonColor(userRune, 12), "13", GetButtonName(userRune, 12));
                var bottone14 = new DiscordButtonComponent(GetButtonColor(userRune, 13), "14", GetButtonName(userRune, 13));
                var bottone15 = new DiscordButtonComponent(GetButtonColor(userRune, 14), "15", GetButtonName(userRune, 14));
                var bottone16 = new DiscordButtonComponent(GetButtonColor(userRune, 15), "16", GetButtonName(userRune, 15));
                var bottone17 = new DiscordButtonComponent(GetButtonColor(userRune, 16), "17", GetButtonName(userRune, 16));
                var bottone18 = new DiscordButtonComponent(GetButtonColor(userRune, 17), "18", GetButtonName(userRune, 17));
                var bottone19 = new DiscordButtonComponent(GetButtonColor(userRune, 18), "19", GetButtonName(userRune, 18));
                var bottone20 = new DiscordButtonComponent(GetButtonColor(userRune, 19), "20", GetButtonName(userRune, 19));
                var bottone21 = new DiscordButtonComponent(GetButtonColor(userRune, 20), "21", GetButtonName(userRune, 20));
                var bottone22 = new DiscordButtonComponent(GetButtonColor(userRune, 21), "22", GetButtonName(userRune, 21));
                var bottone23 = new DiscordButtonComponent(GetButtonColor(userRune, 22), "23", GetButtonName(userRune, 22));
                var bottone24 = new DiscordButtonComponent(GetButtonColor(userRune, 23), "24", GetButtonName(userRune, 23));
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
                imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, nBott);
                // Check if the file exists to prevent IOException
                if (System.IO.File.Exists(path + imagePath))
                {
                    using (var stream = new FileStream(path + imagePath, FileMode.Open))
                    {
                        DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                        /* .AddEmbed(new DiscordEmbedBuilder()
                           .WithColor(DiscordColor.Purple)
                           .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                        .AddFile(stream);
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
                            if (nBott >= 1)
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
                        await ctx.EditResponseAsync(messagefile);
                        stream.Close();
                    }

                    System.IO.File.Delete(path + ctx.Guild.Id + ".png");
                }

            }
        }



        [SlashCommand("tira", "Tira delle rune")]
        public async Task Estrazione(InteractionContext ctx, [Option("numero", "numero di rune da tirare")] long quantita)
        {

            await ctx.DeferAsync();
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


            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 69);

            int nrune = 0;
            for (int i = 0; i < 24; i++)
            {
                if (userRune.data[i] == 0)
                {
                    nrune++;
                }
            }
            if (quantita > nrune)
            {

                await ctx.Channel.SendMessageAsync($"Mi dispiace ma nel sacchetto ci sono solo {nrune} rune :(");

            }
            else
            {
                userRune = new RuneSystem((int)quantita, ctx.Channel.Guild.Id, 0);


                string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                string imagePath = $"{ctx.Guild.Id}.png";

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
                var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0), "1", GetButtonName(userRune, 0));
                var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1), "2", GetButtonName(userRune, 1));
                var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2), "3", GetButtonName(userRune, 2));
                var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3), "4", GetButtonName(userRune, 3));
                var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4), "5", GetButtonName(userRune, 4));
                var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5), "6", GetButtonName(userRune, 5));
                var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6), "7", GetButtonName(userRune, 6));
                var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7), "8", GetButtonName(userRune, 7));
                var bottone9 = new DiscordButtonComponent(GetButtonColor(userRune, 8), "9", GetButtonName(userRune, 8));
                var bottone10 = new DiscordButtonComponent(GetButtonColor(userRune, 9), "10", GetButtonName(userRune, 9));
                var bottone11 = new DiscordButtonComponent(GetButtonColor(userRune, 10), "11", GetButtonName(userRune, 10));
                var bottone12 = new DiscordButtonComponent(GetButtonColor(userRune, 11), "12", GetButtonName(userRune, 11));
                var bottone13 = new DiscordButtonComponent(GetButtonColor(userRune, 12), "13", GetButtonName(userRune, 12));
                var bottone14 = new DiscordButtonComponent(GetButtonColor(userRune, 13), "14", GetButtonName(userRune, 13));
                var bottone15 = new DiscordButtonComponent(GetButtonColor(userRune, 14), "15", GetButtonName(userRune, 14));
                var bottone16 = new DiscordButtonComponent(GetButtonColor(userRune, 15), "16", GetButtonName(userRune, 15));
                var bottone17 = new DiscordButtonComponent(GetButtonColor(userRune, 16), "17", GetButtonName(userRune, 16));
                var bottone18 = new DiscordButtonComponent(GetButtonColor(userRune, 17), "18", GetButtonName(userRune, 17));
                var bottone19 = new DiscordButtonComponent(GetButtonColor(userRune, 18), "19", GetButtonName(userRune, 18));
                var bottone20 = new DiscordButtonComponent(GetButtonColor(userRune, 19), "20", GetButtonName(userRune, 19));
                var bottone21 = new DiscordButtonComponent(GetButtonColor(userRune, 20), "21", GetButtonName(userRune, 20));
                var bottone22 = new DiscordButtonComponent(GetButtonColor(userRune, 21), "22", GetButtonName(userRune, 21));
                var bottone23 = new DiscordButtonComponent(GetButtonColor(userRune, 22), "23", GetButtonName(userRune, 22));
                var bottone24 = new DiscordButtonComponent(GetButtonColor(userRune, 23), "24", GetButtonName(userRune, 23));
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
                imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, nBott);
                // Check if the file exists to prevent IOException
                if (System.IO.File.Exists(path + imagePath))
                {
                    using (var stream = new FileStream(path + imagePath, FileMode.Open))
                    {
                        DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                       /*    .AddEmbed(new DiscordEmbedBuilder()
                            .WithColor(DiscordColor.Purple)
                            .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                       .AddFile(stream);
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
                            if (nBott >= 1)
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
                        await ctx.EditResponseAsync(messagefile);
                        stream.Close();
                    }

                    System.IO.File.Delete(path + ctx.Guild.Id + ".png");


                }


                
            }
        }






        [SlashCommand("sigillo", "Mostra il sigillo")]
        public async Task Sigillo1(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 80);


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

            string[] imagePaths = { "", "", "", "", "", "", "", ""};
            string imagePath = $"{ctx.Guild.Id}.png";


            var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0, "sigillo"), "1", GetButtonName2(userRune, 0));
            var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1, "sigillo"), "2", GetButtonName2(userRune, 1));
            var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2, "sigillo"), "3", GetButtonName2(userRune, 2));
            var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3, "sigillo"), "4", GetButtonName2(userRune, 3));
            var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4, "sigillo"), "5", GetButtonName2(userRune, 4));
            var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5, "sigillo"), "6", GetButtonName2(userRune, 5));
            var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6, "sigillo"), "7", GetButtonName2(userRune, 6));
            var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7, "sigillo"), "8", GetButtonName2(userRune, 7));
            
            var editSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "editsigillo", "Modifica grandezza Sigillo");
            var clearSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "clearsigillo", "Risolvi il Sigillo");


            var random = new Random();

            for (int i = 0; i < 8; i++)
            {
                if (userRune.data[i + 48] != -1)
                {
                    imagePaths[i] = (userRune.data[i + 48] + 1).ToString();
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
            imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, userRune.data[66], "sigillo");


            if (System.IO.File.Exists(path + imagePath))
            {
                using (var stream = new FileStream(path + imagePath, FileMode.Open))
                {
                    DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                           .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("Sigillo"))
                    .AddFile(stream);
#region suffering2 //////////////////////////////////////////////////////////////////////////////////////////////
                    switch (userRune.data[64])
                    {
                        case 2:

                            switch (userRune.data[66])
                            {
                                case 1:
                                    messagefile.AddComponents(bottone1);
                                    break;
                                case 2:
                                    messagefile.AddComponents(bottone1, bottone2);
                                    break;

                            }
                            break;
                        case 3:
                        case 4:
                            switch (userRune.data[66])
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
                            switch (userRune.data[66])
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
                            switch (userRune.data[66])
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
                    if (userRune.data[66] != 0)
                        messagefile.AddComponents(editSigillo, clearSigillo);
                    else
                        messagefile.AddComponents(editSigillo);

                    #endregion

                    await ctx.EditResponseAsync(messagefile);
                    stream.Close();
                }

                System.IO.File.Delete(path + ctx.Guild.Id + ".png");


            }

        }


        [SlashCommand("sigilloFato", "Mostra il sigillo del fato")]
        public async Task SigilloFato(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 81);
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

            string[] imagePaths = { "", "", "", "", "", "", "", "" };
            string imagePath = $"{ctx.Guild.Id}.png";


            var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0, "sigilloFato"), "1", GetButtonName3(userRune, 0));
            var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1, "sigilloFato"), "2", GetButtonName3(userRune, 1));
            var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2, "sigilloFato"), "3", GetButtonName3(userRune, 2));
            var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3, "sigilloFato"), "4", GetButtonName3(userRune, 3));
            var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4, "sigilloFato"), "5", GetButtonName3(userRune, 4));
            var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5, "sigilloFato"), "6", GetButtonName3(userRune, 5));
            var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6, "sigilloFato"), "7", GetButtonName3(userRune, 6));
            var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7, "sigilloFato"), "8", GetButtonName3(userRune, 7));

            var editSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "editsigillofato", "Modifica grandezza Sigillo del Fato");


            var random = new Random();

            for (int i = 0; i < 8; i++)
            {
                if (userRune.data[i + 56] != -1)
                {
                    imagePaths[i] = (userRune.data[i + 56] + 1).ToString();
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
            imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, userRune.data[67], "sigilloFato");


            if (System.IO.File.Exists(path + imagePath))
            {
                using (var stream = new FileStream(path + imagePath, FileMode.Open))
                {
                    DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                   .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("Sigillo del Fato"))
                    .AddFile(stream);
                    #region suffering2 //////////////////////////////////////////////////////////////////////////////////////////////
                    switch (userRune.data[65])
                    {
                        case 4:
                            switch (userRune.data[67])
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
                            switch (userRune.data[67])
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
                            switch (userRune.data[67])
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
                    messagefile.AddComponents(editSigillo);
                    #endregion
                    await ctx.EditResponseAsync(messagefile);
                    stream.Close();
                }

                System.IO.File.Delete(path + ctx.Guild.Id + ".png");


            }

        }

        [SlashCommand("sigilliParalleli", "Mostra i sigilli paralleli")]
        public async Task Parallelo(InteractionContext ctx)
        {
            await ctx.DeferAsync();
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

            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 82);

            if (userRune.data[70] == 0)
            {
                var bottone0 = new DiscordButtonComponent(ButtonStyle.Primary, "openParallelo", "Apri");
                var embedo = new DiscordEmbedBuilder();
                embedo.Title = $"Vuoi aprire un Sigillo Parallelo?";
                embedo.Color = DiscordColor.Red;
                DiscordWebhookBuilder messagefileM = new DiscordWebhookBuilder()
                   .AddComponents(bottone0)
                   .AddEmbed(embedo);
                await ctx.EditResponseAsync(messagefileM);
            }
            if (userRune.data[70] == 1)
            {
                string[] imagePaths = { "", "", "", "", "", "", "", "" };
                string imagePath = $"{ctx.Guild.Id}.png";


                var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0, "parallelo"), "1", GetButtonName4(userRune, 0));
                var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1, "parallelo"), "2", GetButtonName4(userRune, 1));
                var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2, "parallelo"), "3", GetButtonName4(userRune, 2));
                var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3, "parallelo"), "4", GetButtonName4(userRune, 3));
                var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4, "parallelo"), "5", GetButtonName4(userRune, 4));
                var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5, "parallelo"), "6", GetButtonName4(userRune, 5));
                var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6, "parallelo"), "7", GetButtonName4(userRune, 6));
                var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7, "parallelo"), "8", GetButtonName4(userRune, 7));




                var editSigillo = new DiscordButtonComponent(ButtonStyle.Secondary, "editsigilloparallelo", "Modifica grandezza Sigillo Parallelo");
                var closeParal = new DiscordButtonComponent(ButtonStyle.Secondary, "closeParallelo", "Risolvi il Sigillo Parallelo");



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
                imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, userRune.data[72], "parallelo");



                if (System.IO.File.Exists(path + imagePath))
                {
                    using (var stream = new FileStream(path + imagePath, FileMode.Open))
                    {
                        DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                       .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("Sigillo Parallelo"))
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
                        messagefile.AddComponents(editSigillo, closeParal, openParal2);
                        #endregion
                        await ctx.EditResponseAsync(messagefile);
                        stream.Close();
                    }

                    System.IO.File.Delete(path + ctx.Guild.Id + ".png");


                }
            
            }
            if (userRune.data[70] == 3)
            {
                var apriParall1 = new DiscordButtonComponent(ButtonStyle.Secondary, "openParallelo", $"Primo Sigillo Parallelo ({userRune.data[72]}/{userRune.data[71]})");
                var apriParall2 = new DiscordButtonComponent(ButtonStyle.Secondary, "secondoParallelo", $"Secondo Sigillo Parallelo ({userRune.data[82]}/{userRune.data[81]})");

                DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                     .AddEmbed(new DiscordEmbedBuilder()
                       .WithColor(DiscordColor.Purple)
                       .WithTitle("Quale Sigillo Parallelo vuoi visualizzare?"));

              
                messagefile.AddComponents(apriParall1, apriParall2);
                await ctx.EditResponseAsync(messagefile);
            }
        }



        [SlashCommand("sacchetto", "Mostra il contenuto del sacchetto")]
        public async Task Sacchetto(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 83);


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


            string[] imagePaths = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string imagePath = $"{ctx.Guild.Id}.png";

            int nBott = 0;
            for (int i = 0; i < 24; i++)
            {
                if (userRune.data[i] == 0)
                {

                    nBott++;
                }
            }

           
            #region pain ///////////////////////////////////////////////////////////////////////////////////////////////
            var bottone1 = new DiscordButtonComponent(GetButtonColor(userRune, 0, "sacchetto"), "1", GetButtonName5(userRune, 0));
            var bottone2 = new DiscordButtonComponent(GetButtonColor(userRune, 1, "sacchetto"), "2", GetButtonName5(userRune, 1));
            var bottone3 = new DiscordButtonComponent(GetButtonColor(userRune, 2, "sacchetto"), "3", GetButtonName5(userRune, 2));
            var bottone4 = new DiscordButtonComponent(GetButtonColor(userRune, 3, "sacchetto"), "4", GetButtonName5(userRune, 3));
            var bottone5 = new DiscordButtonComponent(GetButtonColor(userRune, 4, "sacchetto"), "5", GetButtonName5(userRune, 4));
            var bottone6 = new DiscordButtonComponent(GetButtonColor(userRune, 5, "sacchetto"), "6", GetButtonName5(userRune, 5));
            var bottone7 = new DiscordButtonComponent(GetButtonColor(userRune, 6, "sacchetto"), "7", GetButtonName5(userRune, 6));
            var bottone8 = new DiscordButtonComponent(GetButtonColor(userRune, 7, "sacchetto"), "8", GetButtonName5(userRune, 7));
            var bottone9 = new DiscordButtonComponent(GetButtonColor(userRune, 8, "sacchetto"), "9", GetButtonName5(userRune, 8));
            var bottone10 = new DiscordButtonComponent(GetButtonColor(userRune, 9, "sacchetto"), "10", GetButtonName5(userRune, 9));
            var bottone11 = new DiscordButtonComponent(GetButtonColor(userRune, 10, "sacchetto"), "11", GetButtonName5(userRune, 10));
            var bottone12 = new DiscordButtonComponent(GetButtonColor(userRune, 11, "sacchetto"), "12", GetButtonName5(userRune, 11));
            var bottone13 = new DiscordButtonComponent(GetButtonColor(userRune, 12, "sacchetto"), "13", GetButtonName5(userRune, 12));
            var bottone14 = new DiscordButtonComponent(GetButtonColor(userRune, 13, "sacchetto"), "14", GetButtonName5(userRune, 13));
            var bottone15 = new DiscordButtonComponent(GetButtonColor(userRune, 14, "sacchetto"), "15", GetButtonName5(userRune, 14));
            var bottone16 = new DiscordButtonComponent(GetButtonColor(userRune, 15, "sacchetto"), "16", GetButtonName5(userRune, 15));
            var bottone17 = new DiscordButtonComponent(GetButtonColor(userRune, 16, "sacchetto"), "17", GetButtonName5(userRune, 16));
            var bottone18 = new DiscordButtonComponent(GetButtonColor(userRune, 17, "sacchetto"), "18", GetButtonName5(userRune, 17));
            var bottone19 = new DiscordButtonComponent(GetButtonColor(userRune, 18, "sacchetto"), "19", GetButtonName5(userRune, 18));
            var bottone20 = new DiscordButtonComponent(GetButtonColor(userRune, 19, "sacchetto"), "20", GetButtonName5(userRune, 19));
            var bottone21 = new DiscordButtonComponent(GetButtonColor(userRune, 20, "sacchetto"), "21", GetButtonName5(userRune, 20));
            var bottone22 = new DiscordButtonComponent(GetButtonColor(userRune, 21, "sacchetto"), "22", GetButtonName5(userRune, 21));
            var bottone23 = new DiscordButtonComponent(GetButtonColor(userRune, 22, "sacchetto"), "23", GetButtonName5(userRune, 22));
            var bottone24 = new DiscordButtonComponent(GetButtonColor(userRune, 23, "sacchetto"), "24", GetButtonName5(userRune, 23));
            //      var bottone25 = new DiscordButtonComponent(ButtonStyle.Secondary, "25", "Rimescola nel sacchetto");
            #endregion
            namecount = 0;
           
                int q = 0;

            for (int i = 0; i < 24; i++)
            {

                if (userRune.data[i] == 0)
                {
                    imagePaths[q] = (i + 1).ToString();
                    q++;
                }
                
            }
        

            var imageToSend = new ImagesManager();
            imageToSend.ImageStuff(ctx.Guild.Id, path, imagePaths, nBott);
            // Check if the file exists to prevent IOException
            if (System.IO.File.Exists(path + imagePath))
            {
                using (var stream = new FileStream(path + imagePath, FileMode.Open))
                {
                    DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
                   /*    .AddEmbed(new DiscordEmbedBuilder()
                        .WithColor(DiscordColor.Purple)
                        .WithTitle(larghezza. ToString() + " / " + altezza.ToString()))*/
                   .AddFile(stream);
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
                     //   if (nBott >= 1)
                     //       messagefile.AddComponents(bottone25);
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
                     //   messagefile.AddComponents(bottone25);
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
                      //  messagefile.AddComponents(bottone25);
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
                     //   messagefile.AddComponents(bottone25);
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
                                messagefile.AddComponents(bottone21);
                                break;
                            case 22:
                                messagefile.AddComponents(bottone21, bottone22);
                                break;
                            case 23:
                                messagefile.AddComponents(bottone21, bottone22, bottone23);
                                break;
                            case 24:
                                messagefile.AddComponents(bottone21, bottone22, bottone23, bottone24);
                                break;

                        }
                    }
                    #endregion
                    await ctx.EditResponseAsync(messagefile);
                    stream.Close();
                }

                System.IO.File.Delete(path + ctx.Guild.Id + ".png");


            }

        }


        [SlashCommand("rimescola", "Rimescola le rune estratte nel sacchetto")]
        public async Task TotalReset(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 1);
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Rune estratte rimesse nel sacchetto"));

        }




        [SlashCommand("divinazione", "Estrai una runa casuale per la Divinazione runica")]
        public async Task Divinazione(InteractionContext ctx)
        {
            await ctx.DeferAsync();
            var userRune = new RuneSystem(0, ctx.Channel.Guild.Id, 69);

            var random = new Random();

            int runaIndex = random.Next(0, 24);

           


            var embed = new DiscordEmbedBuilder();
            embed.Title = $"{userRune.descrizioniRune[runaIndex]}";
            if (runaIndex < 8)
            {
                embed.Color = DiscordColor.Green;
            }
            else if (runaIndex < 16)
            {
                embed.Color = DiscordColor.Blue;
            }
            else
            {
                embed.Color = DiscordColor.Red;
            }

            //  await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));



            string path = "";
            if (pc == "tester")
                path = "C:\\Users\\Io\\Desktop\\RunewayBot\\ImageFolder\\";

            if (pc == "server")
                path = "\\root\\Desktop\\BEANBOT\\RunewayBot\\ImageFolder\\";

            using (var stream = new FileStream(path + (runaIndex+1).ToString() + ".png", FileMode.Open))
            {
                DiscordWebhookBuilder messagefile = new DiscordWebhookBuilder()
               .AddFile(stream)
               .AddEmbed(embed);
                await ctx.EditResponseAsync(messagefile);
                stream.Close();

            }




        }











        [SlashCommand("social", "Link ai social")]
        public async Task Socials(InteractionContext ctx)
        {
            await ctx.DeferAsync();

            var q = new DiscordLinkButtonComponent("https://manaprojectstudio.com/store/product/runeway-starter/", "Compra qui lo Starter!");
            var w = new DiscordLinkButtonComponent("https://www.instagram.com/runeway_ttrpg/", "Seguici su Instagram!");
            var jj = new DiscordWebhookBuilder()
            .AddComponents(q, w)
             .AddEmbed(new DiscordEmbedBuilder()
                         .WithColor(DiscordColor.Purple)
                         .WithTitle("Se volete la vostra versione fisica dello Starter di Runeway, o anche solo supportarci con un follow sui social, potete farlo qui! OvO")
                         );

            await ctx.EditResponseAsync(jj);
            //await ctx.Channel.SendMessageAsync(jj);
        }



        // nomi bottoni per le rune estratte
        public string GetButtonName(RuneSystem userRune, int val)
        {
            if (userRune.data[val + 24] != -1)
            {
                if (userRune.data[userRune.data[val + 24]] == 2)
                {
                    return userRune.nomiRune[userRune.data[val + 24]];
                }
                else
                {
                    return "Capovolta";
                }
            }
            else
            {
                return "-";
            }
        }
        // nomi bottoni per le rune nel sigillo
        public string GetButtonName2(RuneSystem userRune, int val)
        {
            if (userRune.data[val + 48] != -1)
            {

                return userRune.nomiRune[userRune.data[val + 48]];

            }
            else
            {
                return "-";
            }
        }
        // nomi bottoni per le rune nel sigillo del fato
        public string GetButtonName3(RuneSystem userRune, int val)
        {
            if (userRune.data[val + 56] != -1)
            {

                return userRune.nomiRune[userRune.data[val + 56]];

            }
            else
            {
                return "-";
            }
        }
        // nomi bottoni per le rune nel sigillo parallelo
        public string GetButtonName4(RuneSystem userRune, int val)
        {
            if (userRune.data[val + 73] != -1)
            {

                return userRune.nomiRune[userRune.data[val + 73]];

            }
            else
            {
                return "-";
            }
        }
        // nomi bottoni per le rune nel sacchetto
        int namecount = 0;
        public string GetButtonName5(RuneSystem userRune, int val)
        {
            string j = "-";
            for (int i = namecount; i < 24; i++)
            {
                if (userRune.data[i] == 0)
                {
                    namecount = i + 1;
                    j= userRune.nomiRune[i];
                    i = 30;
                }
            }
            return j;
        }
        // nomi bottoni per le rune nel sigillo parallelo 2
        public string GetButtonName6(RuneSystem userRune, int val)
        {
            if (userRune.data[val + 83] != -1)
            {

                return userRune.nomiRune[userRune.data[val + 83]];

            }
            else
            {
                return "-";
            }
        }
        public ButtonStyle GetButtonColor(RuneSystem userRune, int val, string what = "")
        {
            if (what == "")
            {
                if (userRune.data[val + 24] != -1)
                {
                    if (userRune.data[userRune.data[val + 24]] == 2)
                    {
                        if (userRune.data[val + 24] < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (userRune.data[val + 24] < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }
                    }
                    else
                    {
                        return ButtonStyle.Secondary;
                    }
                }
                else
                {
                    return ButtonStyle.Secondary;
                }
            }
            else
            {
                switch (what)
                {
                    case "sigillo":

                        if (userRune.data[val + 48] < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (userRune.data[val + 48] < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }
                    case "sigilloFato":

                        if (userRune.data[val + 56] < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (userRune.data[val + 56] < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }
                    case "parallelo":

                        if (userRune.data[val + 73] < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (userRune.data[val + 73] < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }
                    case "parallelo2":

                        if (userRune.data[val + 83] < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (userRune.data[val + 83] < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }
                    case "sacchetto":

                        if (namecount < 8)
                        {
                            return ButtonStyle.Success;
                        }
                        else if (namecount < 16)
                        {
                            return ButtonStyle.Primary;
                        }
                        else
                        {
                            return ButtonStyle.Danger;
                        }

                }
                return ButtonStyle.Secondary;
            }
        }

    }
}
