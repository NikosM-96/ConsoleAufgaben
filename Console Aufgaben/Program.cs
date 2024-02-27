using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Console_Aufgaben
{
    internal class Program
    {

        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Choose program:");
                Console.WriteLine("1: ConsoleRechner");
                Console.WriteLine("2: ConsoleMehrwertsteuer");
                Console.WriteLine("3: ConsoleWährungen");
                Console.WriteLine("4: ConsoleKfzKennzeichen");
                Console.WriteLine("5: ConsoleVolumen");
                Console.WriteLine("6: ConsoleUmrechnungPs");
                Console.WriteLine("7: ConsolePunkteBilanz");
                Console.WriteLine("8: ConsoleSchaltjahr");
                Console.WriteLine("9: ConsoleZufallSumme");
                Console.WriteLine("10: consoleBunteZufallsZahlen");
                Console.WriteLine("11: ConsoleZahlenraten");
                Console.WriteLine("Type exit to close the app");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ConsoleRechner();
                        break;
                    case "2":
                        ConsoleMehrwertsteuer();
                        break;
                    case "3":
                        ConsoleCurrecny();
                        break;
                    case "4":
                        ConsoleKfzKennzeichen();
                        break;
                    case "5":
                        ConsoleVolumen();
                        break;
                    case "6":
                        ConsoleUmrechnungPS();
                        break;
                    case "7":
                        ConsolePunkteBilanz();
                        break;
                    case "8":
                        ConsoleSchaltjahr();
                        break;
                    case "9":
                        ConsoleZufallSumme();
                        break;
                    case "10":
                        consoleBunteZufallsZahlen();
                        break;
                    case "11":
                        ConsoleZahlenraten();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong number");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ConsoleRechner()
        {
            Console.WriteLine("1: ConsoleRechner");
            Console.WriteLine();

            string[] allowedOpeartors = ["+", "-", "*", "/",];

            Console.Write("Bitte geben Sie die erste Zahl ein: ");
            string strN1 = Console.ReadLine();

            string strOperator = null;
            while (!allowedOpeartors.Contains(strOperator))
            {
                Console.Write("Bitte geben Sie die Rechenart ein: ");
                strOperator = Console.ReadLine();
            }

            Console.Write("Bitte geben Sie die zweite Zahl ein: ");
            string strN2 = Console.ReadLine();

            double n1 = Convert.ToDouble(strN1);
            double n2 = Convert.ToDouble(strN2);

            double result = 0;

            switch (strOperator)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "*":
                    result = n1 * n2;
                    break;
                case "/":
                    result = n1 / n2;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Das Egebnis lautet: {n1} {strOperator} {n2} = {result}");

            Close(ConsoleRechner);

        }

        static void ConsoleMehrwertsteuer()
        {

            Console.WriteLine("ConsoleMehrwertsteuer");
            Console.WriteLine();

            string[] allowedMwst = ["0", "7", "16", "19"];

            Console.Write("Bitte Netto-Betrag eingeben: ");
            string strNetto = Console.ReadLine();

            string strSatz = "";

            while (!allowedMwst.Contains(strSatz))
            {
                Console.Write("Bitte Mehrwertsteuer-Satz eingeben (0, 7, 16, 19): ");
                strSatz = Console.ReadLine();
            }

            double dNetto = Convert.ToDouble(strNetto);
            double dSatz = Convert.ToDouble(strSatz);

            double dMwst = Math.Round((dNetto * dSatz / 100), 4);
            double dMwstGerundet = Math.Round(dMwst, 2);

            double dBrutto = Math.Round((dNetto + dMwstGerundet), 2);

            Console.WriteLine($"Rechnerisch ergibt sich bei {strSatz}%: {dMwst}");
            Console.WriteLine();

            Console.WriteLine($"Die Mehrwertsteuer beträgt: {dMwstGerundet}");
            Console.WriteLine($"Der Brutto-Betrag lautet: {dBrutto}");

            Close(ConsoleMehrwertsteuer);

        }

        static void ConsoleCurrecny()
        {

            Console.WriteLine("ConsoleWährungen");
            Console.WriteLine();

            Dictionary<string, double> currency = new()
            {
                { "eur", 1 },
                { "usd", 1.08 },
                { "chf", 0.95 },
                { "gbp", 0.85 },
                { "jpy", 162.80 },
                { "cny", 7.79 },
                { "dkk", 7.45 },
                { "nok", 11.42 },
                { "sek", 11.18 }

            };

            string[] allowedCurrency = currency.Keys.Select(key => key.ToUpper()).ToArray();
            string allowedCurrencyString = string.Join(", ", allowedCurrency);

            Console.WriteLine($"Vorhandene Währungen: {allowedCurrencyString}");
            Console.WriteLine();

            Console.Write("Geben Sie den Betrag in Euro ein: ");
            string strEuro = Console.ReadLine();

            string strCurrency = "";
            while (!currency.ContainsKey(strCurrency))
            {
                Console.Write("Geben Sie die Ziel-Währung ein: ");
                strCurrency = Console.ReadLine().ToLower();
            }


            double euro = Convert.ToDouble(strEuro);
            double rate = currency[strCurrency];

            double result = Math.Round((euro * rate), 2);

            Console.WriteLine($"{euro:N2} EUR entsprechen {result:N2} {strCurrency.ToUpper()}");

            Close(ConsoleCurrecny);

        }

        static void ConsoleKfzKennzeichen()
        {

            Console.WriteLine("ConsoleKfzKennzeichen");
            Console.WriteLine();

            Dictionary<string, string> city = new()
            {
                { "pf", "Pforzheim" },
                { "s", "Stuttgart" },
                { "ka", "Karlsruhe" }
            };

            string[] cityList = city.Keys.Select(key => key.ToUpper()).ToArray();


            string strCity = "";
            while (!city.ContainsKey(strCity))
            {
                Console.Write("Bitte geben Sie das Kennzeichen ein: ");
                strCity = Console.ReadLine().ToLower();
            }

            string cityName = city[strCity];

            Console.WriteLine();

            Console.WriteLine($"Die zugehörige Stadt (Landkreis) lautet: {cityName}");

            Close(ConsoleKfzKennzeichen);

        }

        static void ConsoleVolumen()
        {

            Console.WriteLine("Volumen berechnen");
            Console.WriteLine();

            Console.Write("Bitte Länge eingeben: ");
            string strLength = Console.ReadLine();
            Console.Write("Bitte Breite eingeben: ");
            string strWidth = Console.ReadLine();
            Console.Write("Bitte Höhe eingeben: ");
            string strHeight = Console.ReadLine();

            double length = Convert.ToDouble(strLength);
            double width = Convert.ToDouble(strWidth);
            double height = Convert.ToDouble(strHeight);



            double result = length * width * height;

            Console.WriteLine("Das Volumen beträgt: " + result);

            Close(ConsoleVolumen);

        }

        static void ConsoleUmrechnungPS()
        {
            Console.WriteLine("ConsoleUmrechnungPs");
            Console.WriteLine();

            Console.Write("Biite geben Sie die Leistung in PS ein: ");
            string strLeistung = Console.ReadLine();

            double dPs = Convert.ToDouble(strLeistung);
            double dKW = dPs * 0.74;
            dKW = Math.Round(dKW, 1);

            Console.WriteLine("Die Leistung in KW lautet: " + dKW.ToString("N1"));

            Close(ConsoleUmrechnungPS);
        }

        static void ConsolePunkteBilanz()
        {
            Console.WriteLine("ConsolePunkteBilanz");
            Console.WriteLine();

            Console.Write("Bitte geben Sie den Tore des Verein 1 ein: ");
            string club1Goals = Console.ReadLine();

            Console.Write("Bitte geben Sie den Tore des Verein 2 ein: ");
            string club2Goals = Console.ReadLine();

            int intClub1Goals = Convert.ToInt32(club1Goals);
            int intClub2Goals = Convert.ToInt32(club2Goals);

            int club1Points = 0;
            int club2Points = 0;

            string winner = "";

            if (intClub1Goals > intClub2Goals)
            {
                club1Points += 3;
                winner = "Verein 1";
            }
            else if (intClub1Goals < intClub2Goals)
            {
                club2Points += 3;
                winner = "Verein 2";
            }

            Console.WriteLine($"Verein 1 erhält {club1Points} Punkte");
            Console.WriteLine($"Verein 2 erhält {club2Points} Punkte");
            Console.WriteLine($"{winner} hat gewonnen");

            Close(ConsolePunkteBilanz);


        }

        static void ConsoleSchaltjahr()
        {
            Console.WriteLine("ConsoleSchaltjahr");
            Console.WriteLine();

            string strYear = "";
            string regexPattern = @"^\d+$";

            while (!Regex.IsMatch(strYear, regexPattern))
            {
                Console.Write("Bitte Jahreszahl eingeben: ");
                strYear = Console.ReadLine();
            }



            int intYear = Convert.ToInt32(strYear);

            bool isYearLeap = (intYear % 4 == 0) && (intYear % 100 != 0 || intYear % 400 == 0);

            if (isYearLeap)
            {
                Console.WriteLine($"{strYear} ist ein Schaltjahr");
            }
            else
            {
                Console.WriteLine($"{strYear} ist kein Schaltjahr");
            }

            Close(ConsoleSchaltjahr);
        }

        static void ConsoleZufallSumme()
        {
            Console.WriteLine("ConsoleZufallSumme");
            Console.WriteLine();

            Random r = new Random();

            int numberAmount = 50;

            double sum = 0;

            for (int i = 0; i < numberAmount; i++)
            {
                int nRandom = r.Next(100);
                Console.Write(nRandom + " ");
                sum += nRandom;
            }

            Console.WriteLine();
            Console.WriteLine();

            double average = sum / numberAmount;

            Console.WriteLine($"Die Summe beträgt: {sum}");
            Console.WriteLine($"Der Mittelwert beträgt: {average}");

            Close(ConsoleZufallSumme);
        }

        static void consoleBunteZufallsZahlen()
        {
            Console.WriteLine("consoleBunteZufallsZahlen");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Gray;

            Random r = new Random();

            int numberAmount = 500;

            for (int i = 0; i < numberAmount; i++)
            {
                int nRandom = r.Next(1000);

                string strRandom = nRandom.ToString().PadLeft(4);

                if (nRandom % 11 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (nRandom % 9 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (nRandom % 7 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (nRandom % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (nRandom % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (nRandom % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(strRandom);
            }


            Console.ResetColor();
            Console.WriteLine();

            Close(consoleBunteZufallsZahlen);
        }

        static void ConsoleZahlenraten()
        {
            Console.WriteLine("ConsoleZahlenraten");
            Console.WriteLine();

            Random r = new Random();

            int nRandom = r.Next(1, 7);
            string strNumber = "";

            Console.WriteLine("Es wurde eine Zufallszahl (1..6) erzeught: *");
            Console.Write("Erraten Sie die Zahl: ");

            strNumber = Console.ReadLine();
            int number = Convert.ToInt32(strNumber);

            while (number != nRandom)
            {
                if (nRandom > number)
                {
                    Console.WriteLine();
                    Console.WriteLine("Leider nicht, die Zufallszahl ist größer als eingegebene Zahl");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Leider nicht, die Zufallszahl ist kleiner als eingegebene Zahl");
                }
                Console.Write("Erraten Sie die Zahl: ");
                strNumber = Console.ReadLine();
                number = Convert.ToInt32(strNumber);
            }

            Console.WriteLine();
            Console.WriteLine("Gratulation, Sie haben die richtige Zahl geraten!");

            Close(ConsoleZahlenraten);


        }

        static void Close(Action method)
        {
            string strEnde = "";

            while (strEnde != "j" && strEnde != "n")
            {
                Console.WriteLine();
                Console.Write("Programm beenden (j/n) ? ");
                strEnde = Console.ReadLine().ToLower();

                if (strEnde == "j")
                {
                    return;
                }
                else if (strEnde == "n")
                {
                    Console.WriteLine();
                    method();
                }
            }
        }

    }
}
