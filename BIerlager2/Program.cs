namespace BIerlager2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReloadDbWithTestDates();
            Console.WriteLine("Wilkommen zu Bierlager!\n");
            Console.WriteLine(
                "1 - Bier anzeigen" +
                "\n2 - Bier hinzufügen" +
                "\n3 - Bierkiste hinzufügen" +
                "\n3 - DB neu ausfühlen" +
                "\n0 - Das Programm schliessen");

            var selectedAction = "";
            do
            {
                selectedAction = Console.ReadLine();

                switch (selectedAction)
                {
                    case "1":
                        ReadFromDb();
                        break;
                    case "2":
                        AddFlasche();
                        break;
                    case "3":
                        AddKiste();
                        break;
                    case "4":
                        ReloadDbWithTestDates();
                        break;
                    case "0":
                        Console.WriteLine("Program Ende");
                        break;
                    default:
                        Console.WriteLine("Drücken Sie die Eingabetaste und versuchen Sie es erneut oder drücken Sie 0 zum Schließen!");
                        break;
                }

            } while (selectedAction != "0");
        }

        private static void AddKiste()
        {
            Console.WriteLine("Name...");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                name = "No name Bier";

            Console.WriteLine("Volumen...");
            var volumen = 0;
            if (int.TryParse(Console.ReadLine(), out int volumenNumber))
            {
                if (volumenNumber <= 20)
                {
                    volumen = volumenNumber;

                    Console.WriteLine("Raum...");
                    var raum = 0;
                    if (int.TryParse(Console.ReadLine(), out int raumNumber))
                        raum = raumNumber;

                    Console.WriteLine("Regal...");
                    var regal = 0;
                    if (int.TryParse(Console.ReadLine(), out int regalNumber))
                        regal = regalNumber;

                    Kiste kiste = new()
                    {
                        Raum = raum,
                        Regal = regal
                    };

                    List<Flasche> flaschen = new();

                    for (int i = 0; i < volumen; i++)
                    {
                        Flasche flasche = new()
                        {
                            Name = name,
                            GenommenAm = DateTime.Now.Date,
                            KisteId = kiste.GetCount(),
                            Raum = raum,
                            Regal = regal
                        };

                        flaschen.Add(flasche);
                        BierContext bierContext = new();
                        bierContext.AddBierFromContext(flasche);
                        bierContext.SaveChanges();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Max 20 Flaschen pro Kiste");
                }
            }
            
        }

        //private static void AddKiste()
        //{
        //    Console.WriteLine("Volumen...");
        //    var volumen = 0;
        //    if (int.TryParse(Console.ReadLine(), out int volumenNumber))
        //        volumen = volumenNumber;

        //    Console.WriteLine("Raum...");
        //    var raum = 0;
        //    if(int.TryParse(Console.ReadLine(), out int raumNumber))
        //        raum = raumNumber;

        //    Console.WriteLine("Regal...");
        //    var regal = 0;
        //    if (int.TryParse(Console.ReadLine(), out int regalNumber))
        //        regal = regalNumber;

        //    Kiste kiste = new()
        //    {
        //        Raum = raum,
        //        Regal = regal
        //    };


        //    Kiste kisteContext = new();
        //    kisteContext.AddBierFromContext(kiste);
        //    bierContext.SaveChanges();
        //}
        private static void AddFlasche()
        {
            Console.WriteLine("Name...");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                name = "No name Bier";

            Console.WriteLine("Raum...");
            var raum = 0;
            if(int.TryParse(Console.ReadLine(), out int raumNumber))
                raum = raumNumber;

            Console.WriteLine("Regal...");
            var regal = 0;
            if (int.TryParse(Console.ReadLine(), out int regalNumber))
                regal = regalNumber;

            Flasche flasche = new()
            {
                Name = name,
                GenommenAm = DateTime.Now.Date,
                KisteId = 0,
                Raum = raum,
                Regal = regal
            };

            BierContext bierContext = new();
            bierContext.AddBierFromContext(flasche);
            bierContext.SaveChanges();
        }
        private static void ReadFromDb()
        {
            var dbContext = new BierContext();

            foreach (var item in dbContext.Flasche)
            {
                Console.WriteLine("Die Flasche - " + item.Name + " - wurde am " + item.GenommenAm + " in die Bierkiste Nummer: " + item.KisteId + " auf Regal " + item.Regal + " Raumnummer " + item.Raum + " gestellt\n");
            }
        }
        private static void ReloadDbWithTestDates()
        {
            using (var context = new BierContext())
            {
                var flasheList = new List<Flasche>();

                Flasche flasche = new()
                {
                    Name = "Fässla",
                    GenommenAm = DateTime.Now,
                    KisteId = 1,
                    Raum = 1,
                    Regal = 2
                };

                Flasche flasche2 = new()
                {
                    Name = "HB",
                    GenommenAm = DateTime.Now.Date,
                    KisteId = 2,
                    Raum = 1,
                    Regal = 2
                };

                Flasche flasche3 = new()
                {
                    Name = "Hölzlein",
                    GenommenAm = DateTime.Now.Date,
                    KisteId = 2,
                    Raum = 1,
                    Regal = 2
                };

                Flasche flasche4 = new()
                {
                    Name = "Tücher",
                    GenommenAm = DateTime.Now.Date,
                    KisteId = 2,
                    Raum = 1,
                    Regal = 2
                };

                Flasche flasche5 = new()
                {
                    Name = "Baireuther",
                    GenommenAm = DateTime.Now.Date,
                    KisteId = 2,
                    Raum = 1,
                    Regal = 2
                };

                BierContext bierContext = new();
                bierContext.AddBierFromContext(flasche);
                bierContext.AddBierFromContext(flasche2);
                bierContext.AddBierFromContext(flasche3);
                bierContext.AddBierFromContext(flasche4);
                bierContext.AddBierFromContext(flasche5);
                bierContext.SaveChanges();
            }
        }
    }
}