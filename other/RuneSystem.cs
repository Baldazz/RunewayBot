using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using RunewayBot.config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Data;
using System.Text.RegularExpressions;

namespace RunewayBot.other
{


    public class RuneSystem
    {
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////
        //   private static string pc = "server";
        private static string pc = "tester";
        /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// /////////////////////// ///////////////////////




        public string[] nomiRune = { "ᚠ Fehu", "ᚢ Uruz", "ᚦ Thurisaz", "ᚨ Ansuz", "ᚱ Raido", "ᚲ Kenaz", "ᚷ Gebo", "ᚹ Wunjo", // CORPO
                                     "ᚺ Hagalaz", "ᚾ Nauthiz", "ᛁ  Isa", "ᛃ Jera", "ᛇ Eihwaz", "ᛈ Pertho", "ᛉ Algiz", "ᛋ Sowelu",  // MENTE
                                     "ᛏ Tiwaz", "ᛒ Berkana", "ᛖ Ehwaz", "ᛗ Mannaz", "ᛚ Laguz", "ᛜ Ingwaz", "ᛞ Dagaz", "ᛟ Othala" };  // ANIMA  

        public string[] descrizioniRune = { 
            "ᚠ Fehu: Fortuna, Successo.\r\nBlocco: Gelosia, Invidia.",
            "ᚢ Uruz: Coraggio, Forza.\r\nBlocco: Ferocia, Aggressività",
            "ᚦ Thurisaz: Resistenza, Protezione.\r\nBlocco: Fragilità, Confusione.",
            "ᚨ Ansuz: Guarigione, Saggezza.\r\nBlocco: Inganno, Egoismo.",
            "ᚱ Raido: Viaggio, Ricerca.\r\nBlocco: Rallentamento, Rinuncia.",
            "ᚲ Kenaz: Comprensione, Rivelazione.\r\nBlocco: Superficialità, Arroganza.",
            "ᚷ Gebo: Amicizia, Condivisione.\r\nBlocco: Conflitto, Richiesta.",
            "ᚹ Wunjo: Speranza, Armonia.\r\nBlocco: Solitudine, Pessimismo.",
            "ᚺ Hagalaz: Liberazione, Ricostruzione.\r\nBlocco: Interruzione, Arresto.",
            "ᚾ Nauthiz: Resistenza, Determinazione.\r\nBlocco: Distacco, Allontanamento.",
            "ᛁ  Isa: Riflessione, Lucidità.\r\nBlocco: Separazione, Mancanza.",
            "ᛃ Jera: Pazienza, Controllo.\r\nBlocco: Il Destino, il Cosmo.",
            "ᛇ Eihwaz: Capacità di difesa, Intelligenza.\r\nBlocco: Problema imminente.",
            "ᛈ Pertho: Gioia, Destino.\r\nBlocco: Tristezza, Illusione.",
            "ᛉ Algiz: Risveglio, Riuscita.\r\nBlocco: Vulnerabilità, Pericolo.",
            "ᛋ Sowelu: Potere, Consapevolezza.\r\nBlocco: Potere avverso.",
            "ᛏ Tiwaz: Valore, Vittoria.\r\nBlocco: Disonestà, Sconfitta.",
            "ᛒ Berkana: Amore, Desiderio.\r\nBlocco: Immaturità, Abbandono.",
            "ᛖ Ehwaz: Miglioramento, Cooperazione.\r\nBlocco: Fretta, Disarmonia.",
            "ᛗ Mannaz: Unione, Umanità.\r\nBlocco: Inibizione, Attesa.",
            "ᛚ Laguz: Conoscenza, Apprendimento.\r\nBlocco: Errore, Falsa intuizione.",
            "ᛜ Ingwaz: Calore, Sollievo, Ecologia.\r\nBlocco: Eccesso, Impulsività.",
            "ᛞ Dagaz: Nuovo Inizio, Crescita.\r\nBlocco: Frustrazione, Stazionarietà.",
            "ᛟ Othala: Famiglia, Possesso.\r\nBlocco: Limite, Avidità." };


        //  0 = nel sacchetto || 1 = rimossa dal sacchetto  ||  2 = estratta scoperta || 3 = estratta coperta  ||  4 = nel sigillo ||  5 = nel sigillo fato  ||  6 = nel sigillo parallelo ||  7 = nel sigillo parallelo 2
        public int[] data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   //  0 - 23  STATO RUNE
                             -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,   // 24 - 47  ESTRATTE
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 48 - 55  SIGILLO
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 56 - 63  S FATO
                             8, 8,                                                                      // 64 - 65  GRANDEZZA SIGILLI
                             0, 0,                                                                      // 66 - 67  N RUNE NEI SIGILLI
                             0,// 0-estrat||1-sacchet||2-sigil||3-fato||4-paral||5-paral 2              // 68       COSA è STAMPATO AL MOMENTO A SCHERMO
                             0,                                                                         // 69       RUNA SELEZIONATA A SCHERMO
                             0,                                                                         // 70       1 = PARALLELO 1 APERTO / 2 = PARALLELO 2 APERTO / 3 = PARALLELI APERTI
                             8, 0,                                                                      // 71 - 72  GRANDEZZA PARALLELO 1 E N RUNE NEL PARALLELO 1
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 73 - 80  RUNE NEL PARALLELO 1
                             8, 0,                                                                      // 81 - 82  GRANDEZZA PARALLELO 2 E N RUNE NEL PARALLELO 2
                             -1,-1,-1,-1,-1,-1,-1,-1                                                    // 83 - 90  RUNE NEL PARALLELO 2
        };
        int[] clean =       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,   //  0 - 23  STATO RUNE
                             -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,   // 24 - 47  ESTRATTE
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 48 - 55  SIGILLO
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 56 - 63  S FATO
                             8, 8,                                                                      // 64 - 65  GRANDEZZA SIGILLI
                             0, 0,                                                                      // 66 - 67  N RUNE NEI SIGILLI
                             0,     // 0-estratte || 1-sacchetto || 2-sigillo || 3-fato || 4-parallelo  // 68       COSA è STAMPATO AL MOMENTO A SCHERMO
                             0,                                                                         // 69       RUNA SELEZIONATA A SCHERMO
                             0,                                                                         // 70       1 = PARALLELO 1 APERTO / 2 = PARALLELO 2 APERTO / 3 = PARALLELI APERTI
                             8, 0,                                                                      // 71 - 72  GRANDEZZA PARALLELO 1 E N RUNE NEL PARALLELO 1
                             -1,-1,-1,-1,-1,-1,-1,-1,                                                   // 73 - 80  RUNE NEL PARALLELO 1
                             8, 0,                                                                      // 81 - 82  GRANDEZZA PARALLELO 2 E N RUNE NEL PARALLELO 2
                             -1,-1,-1,-1,-1,-1,-1,-1                                                    // 83 - 90  RUNE NEL PARALLELO 2
        };

        int nSave = 91;

        public ulong nome;
        public RuneSystem(int quantita, ulong name, int comando = 0, string from = "")
        {

            nome = name;
            data = Load();

            switch (comando)
            {
                // apri parallelo 1
                case 90:
                    if (data[70] == 0)
                        data[70] = 1;
                    data[68] = 4;
                    Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha aperto un sigillo parallelo\n");
                    break;
                    
                // chiudi parallelo 1
                case 91:
                    if (data[70] == 1)
                    {
                        data[70] = 0;

                        for (int i = 0; i < 24; i++)
                        {
                            if (data[i] == 6)
                                data[i] = 0;
                        }
                        for (int i = 73; i < 80; i++)
                        {
                            data[i] = -1;
                        }

                        data[71] = 8;
                        data[72] = 0;
                    }
                    else if (data[70] == 3)
                    {
                        data[70] = 1;

                        for (int i = 0; i < 24; i++)
                        {
                            if (data[i] == 7)
                                data[i] = 6;
                        }
                        for (int i = 73; i < 80; i++)
                        {
                            data[i] = data[i+10];
                        }
                        for (int i = 83; i < 90; i++)
                        {
                            data[i] = -1;
                        }

                        data[71] = data[81];
                        data[72] = data[82];
                        data[81] = 8;
                        data[82] = 0;


                    }

                    Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha chiuso un sigillo parallelo\n");
                    break;

                // apri parallelo 2
                case 92:
                    if (data[70] == 1)
                        data[70] = 3;
                    data[68] = 5;
                    Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha aperto un sigillo parallelo 2\n");
                    break;

                // chiudi parallelo 2
                case 93:
                    data[70] = 1;

                    for (int i = 0; i < 24; i++)
                    {
                        if (data[i] == 7)
                            data[i] = 0;
                    }
                    for (int i = 83; i < 90; i++)
                    {
                        data[i] = -1;
                    }

                    data[81] = 8;
                    data[82] = 0;

                    Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha chiuso un sigillo parallelo 2\n");
                    break;

                // a schermo è stampato il sigillo
                case 80:   
                    data[68] = 2;
                    break;

                // a schermo è stampato il sigillo del fato
                case 81:
                    data[68] = 3;
                    break;

                // a schermo è stampato il sigillo parallelo
                case 82:
                    data[68] = 4;
                    break;

                // a schermo è stampato sacchetto
                case 83:
                    data[68] = 1;
                    break; 

                // clear sigillo
                case 50:

                    for (int i = 0; i < 24; i++)
                    {
                        if (data[i] == 4)
                            data[i] = 0;
                    }
                    for (int i = 48; i < 55; i++)
                    {
                        data[i] = -1;
                    }
                    data[66] = 0;
                    Console.Write(DateTime.Now.ToString("h:mm:ss tt") + "|| " + nome + " ha risolto un sigillo");
                    break;

                // determina runa selezionata
                case 10:  
                    data[69] = quantita;
                    break;

                // grandezza sigillo parallelo
                case 11:

                    if (quantita < data[72])
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data[data[i + 73 + data[71]]] = 0;
                            data[i + 73 + data[71]] = -1;
                            data[72]--;
                        }
                    }
                    data[71] = quantita;
                    break;

                // grandezza sigillo parallelo 2
                case 12:

                    if (quantita < data[82])
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data[data[i + 83 + data[81]]] = 0;
                            data[i + 83 + data[81]] = -1;
                            data[82]--;
                        }
                    }
                    data[81] = quantita;
                    break;

                // grandezza sigillo
                case 9:  

                    if (quantita < data[66])
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data[data[i + 48 + data[64]]] = 0;
                            data[i + 48 + data[64]] = -1;
                            data[66]--;
                        }
                    }
                    data[64] = quantita;
                    break;

                // grandezza sigillo fato
                case 8: 
                    if (quantita < data[67])
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data[data[i + 56 + data[65]]] = 0;
                            data[i + 56 + data[65]] = -1;
                            data[67]--;
                        }
                    }
                    data[65] = quantita;
                    break;

                // muovi runa[quantita] da from al SIGILLO PARALLELO
                case 25:
                    switch (from)
                    {
                        case "estratte":

                            if (data[72] < data[71])
                            {
                                data[data[data[69] + 24 - 1]] = 6;
                                data[data[72] + 73] = data[data[69] + 24 - 1];
                                data[data[69] + 24 - 1] = -1;

                                data[72]++;
                            }
                            break;

                        case "sigilloFato":
                            if (data[72] < data[71]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 56 - 1]] = 6;
                                data[data[72] + 73] = data[data[69] + 56 - 1];
                                data[data[69] + 56 - 1] = -1;
                                data[67]--;
                                data[72]++;
                            }
                            break;

                        case "sigillo":
                            if (data[72] < data[71]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 48 - 1]] = 6;
                                data[data[72] + 73] = data[data[69] + 48 - 1];
                                data[data[69] + 48 - 1] = -1;
                                data[66]--;
                                data[72]++;
                            }
                            break;
                        case "parallelo2":
                            if (data[72] < data[71]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 83 - 1]] = 6;
                                data[data[72] + 73] = data[data[69] + 83 - 1];
                                data[data[69] + 83 - 1] = -1;
                                data[82]--;
                                data[72]++;
                            }
                            break;

                    }
                    Sort(from);
                    break;

                // muovi runa[quantita] da from al SIGILLO PARALLELO 2
                case 26:
                    switch (from)
                    {
                        case "estratte":

                            if (data[82] < data[81])
                            {
                                data[data[data[69] + 24 - 1]] = 6;
                                data[data[82] + 83] = data[data[69] + 24 - 1];
                                data[data[69] + 24 - 1] = -1;

                                data[82]++;
                            }
                            break;

                        case "sigilloFato":
                            if (data[82] < data[81]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 56 - 1]] = 6;
                                data[data[82] + 83] = data[data[69] + 56 - 1];
                                data[data[69] + 56 - 1] = -1;
                                data[67]--;
                                data[82]++;
                            }
                            break;

                        case "sigillo":
                            if (data[82] < data[81]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 48 - 1]] = 6;
                                data[data[82] + 83] = data[data[69] + 48 - 1];
                                data[data[69] + 48 - 1] = -1;
                                data[66]--;
                                data[82]++;
                            }
                            break;

                        case "parallelo":
                            if (data[82] < data[81]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 73 - 1]] = 6;
                                data[data[82] + 83] = data[data[69] + 73 - 1];
                                data[data[69] + 73 - 1] = -1;
                                data[72]--;
                                data[82]++;
                            }
                            break;

                    }
                    Sort(from);
                    break;


                // muovi runa[quantita] da from al SIGILLO FATO
                case 7: 
                    switch (from)
                    {
                        case "estratte":

                            if (data[67] < data[65]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 24 - 1]] = 5; 
                                data[data[67] + 56] = data[data[69] + 24 - 1];  
                                data[data[69] + 24 - 1] = -1; 

                                data[67]++;
                            }
                            break;

                        case "sigillo":
                            if (data[67] < data[65]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 48 - 1]] = 5; 
                                data[data[67] + 56] = data[data[69] + 48 - 1];  
                                data[data[69] + 48 - 1] = -1;
                                data[66]--;
                                data[67]++;
                            }
                            break;

                        case "parallelo":
                            if (data[67] < data[65]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 73 - 1]] = 5;
                                data[data[67] + 56] = data[data[69] + 73 - 1];
                                data[data[69] + 73 - 1] = -1;
                                data[72]--;
                                data[67]++;
                            }
                            break;

                        case "parallelo2":
                            if (data[67] < data[65]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 83 - 1]] = 6;
                                data[data[67] + 56] = data[data[69] + 83 - 1];
                                data[data[69] + 83 - 1] = -1;
                                data[82]--;
                                data[67]++;
                            }
                            break;
                    }
                    Sort(from);
                    break;

                // muovi runa[quantita] da from al SIGILLO
                case 6: 
                    switch (from)
                    {
                        case "estratte":

                            if (data[66] < data[64])
                            {
                                data[data[data[69] + 24 - 1]] = 4;
                                data[data[66] + 48] = data[data[69] + 24 - 1];
                                data[data[69] + 24 - 1] = -1;

                                data[66]++;
                            }
                            break;

                        case "sigilloFato":
                            if (data[66] < data[64]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 56 - 1]] = 4;
                                data[data[66] + 48] = data[data[69] + 56 - 1];
                                data[data[69] + 56 - 1] = -1;
                                data[67]--;
                                data[66]++;
                            }
                            break;

                        case "parallelo":
                            if (data[66] < data[64]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 73 - 1]] = 4;
                                data[data[66] + 48] = data[data[69] + 73 - 1];
                                data[data[69] + 73 - 1] = -1;
                                data[72]--;
                                data[66]++;
                            }
                            break;

                        case "parallelo2":
                            if (data[66] < data[64]) // se le rune nel sigillo sono meno del sigillo massimo
                            {
                                data[data[data[69] + 83 - 1]] = 6;
                                data[data[66] + 48] = data[data[69] + 83 - 1];
                                data[data[69] + 83 - 1] = -1;
                                data[82]--;
                                data[66]++;
                            }
                            break;

                    }
                    Sort(from);
                    break;

                // muovi runa[quantita] da from al SACCHETTO
                case 5:
                    switch (from)
                    {
                        case "sigillo":

                            data[data[data[69] + 48 -1]] = 0;
                            data[data[69] + 48 -1] = -1;

                            data[66]--;
                            break;

                        case "sigilloFato":

                            data[data[data[69] + 56 - 1]] = 0;
                            data[data[69] + 56 - 1] = -1;

                            data[67]--;
                            break;

                        case "parallelo":

                            data[data[data[69] + 73 - 1]] = 0;
                            data[data[69] + 73 - 1] = -1;

                            data[72]--;
                            break;

                        case "parallelo2":

                            data[data[data[69] + 83 - 1]] = 0;
                            data[data[69] + 83 - 1] = -1;

                            data[82]--;
                            break;
                       
                    }
                    Sort(from);
                    break;

                // muovi runa[quantita] da from a  ESTRATTE
                case 4:
                    switch (from)
                    {
                        case "sacchetto":

                            data[data[69]] = 2;
                            for (int f = 0; f < 24; f++)
                            {
                                if (data[f + 24] == -1)
                                {
                                    data[f + 24] = data[69];
                                    f = 25;
                                }
                            }

                            break;
                    }
                    Sort(from);
                    break;

                // muovi runa[quantita] da from a  VOID
                case 60:
                    switch (from)
                    {
                        case "sacchetto":
                            data[data[69]] = 1;
                            break;
                    }
                    Sort(from);
                    break;

                // FLIPPA SINGOLA
                case 3: 
                    if (data[quantita] == 3)
                        data[quantita] = 2;
                    break;

                // FLIPPA TUTTO
                case 2: 
                    for (int i = 0; i < 24; i++)
                    {
                        if (data[i] == 3)
                            data[i] = 2;
                    }
                    break;

                // RESET
                case 1: 
                    Reset(quantita);
                    
                    break;

                // ESTRAZIONE BASE
                case 0: 
                    Estrazione(quantita);
                    for (int i = 0; i < 24; i++)
                    {
                        if (data[i] == 1)
                            data[i] = 0;
                    }
                    Console.Write(DateTime.Now.ToString("|| " + "h:mm:ss tt") + " " + nome +" ha tirato " + quantita + " rune\n");
                    break;
            }
            Save();
        }


        void Estrazione(int quantita)
        {
            data[68] = 0;

            for (int i = 0; i < quantita; i++)
            {

                for (int q = 0; q == 0;)
                {
                    var random = new Random();

                    int runaIndex = random.Next(0, 24);
                    if (data[runaIndex] == 0)
                    {
                        int versoIndex = random.Next(0, 2);
                        if (versoIndex == 0)
                        {
                            data[runaIndex] = 2;
                        }
                        else
                        {
                            data[runaIndex] = 3;
                        }


                        for (int f = 0; f < 24; f++)
                        {
                            if (data[f + 24] == -1)
                            {
                                data[f + 24] = runaIndex;
                                f = 25;
                            }
                        }

                        q = 1;
                    }

                }
            }

        }
        void Reset(int quantita)
        {
            if (quantita == 0) // rimette le rune nel sacchetto
            {
                Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha rimescolato\n");
                for (int i = 0; i < 24; i++)
                {
                    if (data[i] == 1 || data[i] == 2 || data[i] == 3)
                    data[i] = 0;
                }
                for (int i = 24; i < 48; i++)
                {
                    data[i] = -1;
                }
            }
            else // rimette tutte le rune nel sacchetto
            {
                Console.Write("|| " + DateTime.Now.ToString("h:mm:ss tt") + " " + nome + " ha resettato\n");
                for (int i = 0; i < nSave; i++)
                {
                    data[i] = clean[i];
                }
            }
        }
        void Sort(string from)
        {
            switch (from)
            {
                case "estratte":
                    for (int q = 24; q < 47; q++)
                    {
                        if (data[q] == -1)
                        {
                            if (data[q + 1] != -1)
                            {
                                data[q] = data[q + 1];
                                data[q + 1] = -1;
                            }

                        }
                    }
                    break;
                case "sigillo":
                    for (int q = 48; q < 55; q++)
                    {
                        if (data[q] == -1)
                        {
                            if (data[q + 1] != -1)
                            {
                                data[q] = data[q + 1];
                                data[q + 1] = -1;
                            }

                        }
                    }
                    break;
                case "sigilloFato":
                    for (int q = 56; q < 63; q++)
                    {
                        if (data[q] == -1)
                        {
                            if (data[q + 1] != -1)
                            {
                                data[q] = data[q + 1];
                                data[q + 1] = -1;
                            }

                        }
                    }
                    break;
                case "parallelo":
                    for (int q = 73; q < 80; q++)
                    {
                        if (data[q] == -1)
                        {
                            if (data[q + 1] != -1)
                            {
                                data[q] = data[q + 1];
                                data[q + 1] = -1;
                            }

                        }
                    }
                    break;
                case "parallelo2":
                    for (int q = 83; q < 90; q++)
                    {
                        if (data[q] == -1)
                        {
                            if (data[q + 1] != -1)
                            {
                                data[q] = data[q + 1];
                                data[q + 1] = -1;
                            }

                        }
                    }
                    break;
            }

        }
        int[] Load()
        {
            string filePath = "";
            if (pc == "tester")
            {
                 filePath = $@"C:\Users\Io\Desktop\RunewayBot\Database\{nome}.json";
            }
            else if (pc == "server")
            {
               
                filePath = $@"\root\Desktop\BEANBOT\RunewayBot\Database\{nome}.json";
             //   filePath = $@"C:\Users\matte\Desktop\BEANBOT\RunewayBot\Database\{nome}.json";
            }




            if (!File.Exists(filePath))
            {
                return data;
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<int[]>(json);

            }

        }
        void Save()
        {

            string filePath = "";
            if (pc == "tester")
            {
                filePath = $@"C:\Users\Io\Desktop\RunewayBot\Database\{nome}.json";
            }
            else if (pc == "server")
            {

                filePath = $@"\root\Desktop\BEANBOT\RunewayBot\Database\{nome}.json";
                //   filePath = $@"C:\Users\matte\Desktop\BEANBOT\RunewayBot\Database\{nome}.json";
            }

            var toSave = new String[nSave];
            for (int i = 0; i < nSave; i++)
            {
                toSave[i] = $"{data[i].ToString()}";
            }
            var json = JsonConvert.SerializeObject(toSave);


            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(json);
            }
        }
    }
}
