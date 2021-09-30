// Carl-Henrik Lundin, Sam Saeedi Lavasani, Vidar Fröberg Tinell
using System;

namespace GroupAssignment1
{
    public enum GrapeVariants
    {
        CabernetSauvignon, PinotNoir, Corvina, Shiraz, Merlot, Chablis,
        Riesling, Tempranillo
    }
    public enum GrapeRegions
    {
        Bordeaux, Burgundy, Veneto, Piedmonte, RiberaDelDuero,
        NapaValley, Puglia, Pfalz
    }
    public struct Wine
    {
        public int? Year;                   // null = undefined
        public string Name;
        public GrapeVariants Grape;
        public GrapeRegions Region;

        /// <summary>
        /// Creates a string representing the content of the Wine struct
        /// </summary>
        /// <returns>string that can be printed out using Console.WriteLine</returns>
        public string StringToPrint()
        {
            return $"Wine {Year} {Name} is made of {Grape} from {Region}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            const int maxNrBottles = 4;
            Wine[] myCellar = new Wine[maxNrBottles];

            Console.WriteLine($"My cellar can have maximum {maxNrBottles} bottles");

            Wine wine1 = new Wine { Year = 2000, Name = "Château Lafite Rothschild", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.Bordeaux };
            bool bOK = InsertWine(myCellar, wine1);

            Wine wine2 = new Wine { Year = 2010, Name = "Domaine de la Romanée-Conti", Grape = GrapeVariants.PinotNoir, Region = GrapeRegions.Burgundy };
            bOK = InsertWine(myCellar, wine2);

            Wine wine3 = new Wine { Year = 2005, Name = "Giuseppe Quintarelli Amarone", Grape = GrapeVariants.Corvina, Region = GrapeRegions.Veneto };
            bOK = InsertWine(myCellar, wine3);

            Wine wine4 = new Wine { Year = 2008, Name = "Sierra Cantabria", Grape = GrapeVariants.Tempranillo, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine4);

            Wine wine5 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine5);

            Console.WriteLine();
            PrintWines(myCellar);
            Console.WriteLine();
            SearchWines(myCellar);
            Console.WriteLine();
            PrintWines(myCellar);

            Console.WriteLine();
            Console.WriteLine("Do you want to add another wine (Yes or No)?");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input.ToLower() == "yes")
            {
                Wine wine6 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
                bOK = InsertWine(myCellar, wine6);
                Console.WriteLine();
                PrintWines(myCellar);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Inserts a wine into myCellar at first available position
        /// </summary>
        /// <param name="myCellar"></param>
        /// <param name="wine"></param>
        /// <returns>true - if insertion was possible, otherwise false</returns>
        private static bool InsertWine(Wine[] myCellar, Wine wine)
        {
            string couldNotString = "";
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (myCellar[i].Year == null) { myCellar[i] = wine; Console.WriteLine($"Added to my cellar:  {myCellar[i].StringToPrint()} "); return true; }
                else couldNotString = $"Could NOT add to my cellar: {myCellar[i].StringToPrint()}";
            }
            Console.WriteLine(couldNotString);
            return false;
        }

        /// <summary>
        /// Print out all the wines in myCellar
        /// </summary>
        /// <param name="myCellar"></param>
        private static void PrintWines(Wine[] myCellar)
        {
            Console.WriteLine($"My cellar has {NrOfBottles(myCellar)} wines");
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (myCellar[i].Year != null) Console.WriteLine($"{i + 1}: { myCellar[i].StringToPrint()}");
                else Console.WriteLine($"{i + 1}: ");
            }

        }


        private static bool SearchWines(Wine[] myCellar)
        {
            Console.Write("What wine are you looking for? ");
            string searchName = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (myCellar[i].Name.ToLower().Contains(searchName.ToLower()))
                {
                    searchName = myCellar[i].Name;
                    Console.WriteLine($"\"{searchName}\" is found in position number {i + 1}!");
                    Console.WriteLine("Do you want to delete this wine (Yes or No)?");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "yes") DeleteWine(myCellar, i);
                    return true;
                }
            }
            Console.WriteLine($"{searchName} is not found in the cellar!");
            return false;
        }

        /// <summary>
        /// Delete a wine in MyCellar by giving the variable Year
        /// value null. 
        /// </summary>
        /// <param name="myCellar"></param>
        /// <param number="i"></param>
        /// <returns>Returns "true" if the method is successful</returns>
        private static bool DeleteWine(Wine[] myCellar, int i)
        {
            bool deleteBool = false;
            myCellar[i].Year = null;
            deleteBool = true;
            return deleteBool;
        }


        /// <summary>
        /// Counts the number of bottles in myCellar. That is all items
        /// where Year is not null 
        /// </summary>
        /// <param name="myCellar"></param>
        /// <returns>Number of bottles in myCellar</returns>
        private static int NrOfBottles(Wine[] myCellar)
        {
            int numberBottles = 0;
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (myCellar[i].Year != null) numberBottles++;

            }
            return numberBottles;
        }

    }
}