using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Textový.editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pole = new string[3];
            pole[0] = "create new file";
            pole[1] = "find file";
            pole[2] = "delete file";

            int result = DecisionMaker(3, pole, ConsoleColor.White, ConsoleColor.Blue);

            if (result == 0)
            {
                CreateNewFile();
            }
            if (result == 1)
            {
                FindFile();
            }
            if (result == 2)
            {
                DeleteFile();
            }
        }
        static void CreateNewFile()
        {
        Opak:
            Console.WriteLine("   [Napište název souboru: ]");
            Console.WriteLine("");
            string soubor = Console.ReadLine() + ".txt";

            if (soubor == "menu.txt" || soubor == "exit.txt" || soubor == "write.txt" || soubor == "read.txt")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("  [Jméno souboru nelzepoužít!]");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                goto Opak;
            }
            else
            {
                File.WriteAllText(soubor, "");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" [Nový soubor vytvořen!]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("");

            }

            Console.WriteLine("");
            string[] mm = new string[4] { "Přečtení souboru", "Změna souboru", "Zpět do menu", "Ukončení" };
            
            Findmenu:
            prostePotrebny1(soubor, DecisionMaker(4, mm, ConsoleColor.White, ConsoleColor.Blue));
            Console.ReadKey(); goto Findmenu;
        }

        static void FindFile()
        {
        Soubor:
            Console.WriteLine("   [Napište název souboru: ]");
            Console.WriteLine("");

            string soubor = Console.ReadLine() + ".txt";

            if (soubor == "menu.txt")
            {
                prostePotrebny();
            }
            if (!File.Exists(soubor)) //pokud soubor neexistuje, pošle člověka zpět
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(" [Soubor Nexistuje]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                goto Soubor;
            }
            Findmenu:
            Console.WriteLine("");
            string[] mm = new string[4] { "Přečtení souboru", "Změna souboru", "Zpět do menu", "Ukončení" };
            /*
            Console.WriteLine("[ (read)  přečtení souboru ]");
            Console.WriteLine("[ (write) pro změnu souboru ]");
            Console.WriteLine("[ (menu) pro vrácení na menu ]");
            Console.WriteLine("[ (exit) pro ukončení ]");
            Console.WriteLine("");*/

            prostePotrebny1(soubor, DecisionMaker(4, mm, ConsoleColor.White, ConsoleColor.Blue));
            Console.ReadKey();goto Findmenu;
        }

        private static void DeleteFile()
        {
        Soubor:
            Console.WriteLine("   [ Napiste nazev souboru ]");
            Console.WriteLine("");

            string soubor = Console.ReadLine() + ".txt";

            if (soubor == "menu.txt")
            {
                prostePotrebny();
            }

            if (!File.Exists(soubor)) //pokud soubor neexistuje, pošle člověka zpět
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [Soubor Nexistuje]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                goto Soubor;
            }
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(soubor)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(soubor));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine(" [ soubor byl smazán ]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }
            }

            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            Console.WriteLine("");
            string[] mm = new string[4] { "Přečtení souboru", "Změna souboru", "Zpět do menu", "Ukončení" };
            
            Findmenu:
            prostePotrebny1(soubor, DecisionMaker(4, mm, ConsoleColor.White, ConsoleColor.Blue));
            Console.ReadKey(); goto Findmenu;
        }
        private static void prostePotrebny()
        {
            string[] pole = new string[3];
            pole[0] = "new file";
            pole[1] = "find file";
            pole[2] = "delete file";
            int result = DecisionMaker(3, pole, ConsoleColor.White, ConsoleColor.Blue);

            if (result == 0)
            {
                CreateNewFile();
            }

            if (result == 1)
            {
                FindFile();
            }

            if (result == 2)
            {
                DeleteFile();
            }
        }

        private static void prostePotrebny1(string soubor, int decision)
        {
            
                if (decision == 0)
                {
                    Console.WriteLine("");
                    Console.Write(" :  "); PrecteniSlozky(soubor);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                if (decision == 1)
                {
                    Console.WriteLine("");
                    Console.Write(""); ZapisDoSložky(soubor);
                    Console.WriteLine("");
                }
                if (decision == 2)

                {
                    string[] pole = new string[3];
                    pole[0] = "new file";
                    pole[1] = "find file";
                    pole[2] = "delete file";
                    int result = DecisionMaker(3, pole, ConsoleColor.White, ConsoleColor.Blue);

                    if (result == 0)
                    {
                        CreateNewFile();
                    }

                    if (result == 1)
                    {
                        FindFile();
                    }

                    if (result == 2)
                    {
                        DeleteFile();
                    }
                }

                if (decision == 3)
                {
                    Environment.Exit(0);
                }
            
        }



        static void PrecteniSlozky(string soubor)
        {
            if (File.Exists(soubor))
            {
                string obsah = File.ReadAllText(soubor);
                Console.Write("");
                Console.Write(obsah);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [soubor neexistuje!]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void ZapisDoSložky(string soubor)
        {
            if (File.Exists(soubor))
            {
                Console.WriteLine("   [Vložte text, který chcete zapsat :]");
                string novytext = Console.ReadLine();
                File.WriteAllText(soubor, novytext);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine(" [Soubor upraven]");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine(" [soubor neexistuje!]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static int DecisionMaker(int decisionNum, string[] decisions, ConsoleColor mainColor, ConsoleColor highlightColor)
        {
            int currentDecision = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("                                                                                                                        ");
                Console.WriteLine("    [][][][]                              [][][]              []                                 ");
                Console.WriteLine("       []      []               []        []           []           []                               ");
                Console.WriteLine("       []    [][][]   []  []    []        [][][]     [][]     []    []     [][]     []                 ");
                Console.WriteLine("       []    []         []    [][][]      []       []  []     []  [][][]  []  []   [][]                   ");
                Console.WriteLine("       []     [][]    []  []    []        [][][]    [][] []   []    []     [][]     []                ");
                Console.WriteLine("");

                for (int i = 0; i < decisionNum; i++)
                {
                    if (currentDecision == i)
                    {
                        Console.ForegroundColor = highlightColor;
                        Console.Write("> ");
                    }
                    else { Console.Write("  "); }
                    Console.WriteLine(decisions[i]);
                    Console.WriteLine("");
                    Console.ForegroundColor = mainColor;
                }
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow && currentDecision < decisionNum - 1)
                {
                    currentDecision++;
                }
                else if (input.Key == ConsoleKey.UpArrow && currentDecision > 0)
                {
                    currentDecision--;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    return currentDecision;
                }
            }
        }

    }
}

