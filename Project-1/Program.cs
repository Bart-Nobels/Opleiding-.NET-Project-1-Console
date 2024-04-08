namespace Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random mijnRandom = new Random();
            string[] arrNamenLeerlingen = new string[0];
            string[] arrOefeningNummer = { "één", "twee", "drie", "vier", "vijf" };
            string[] arrNamen;
            string[] arrPtnOptellen;
            string[] arrPtnAftrekken;
            string[] arrPtnMaal;
            string[] arrPtnDelen;
            string[] arrDatum;
            string[] arrTmp;
            bool appLeerlingRunning = true, menuOefeningen = true, menuInstellingen = true, running = true;
            bool appLeerkrachtRunning = true, appRunning = true, menuLeerlingBeheren = true;
            string antwoord, keuzeHoofdmenu, keuzeMenu, naam, naamProgramma, inlogLeerkracht, naamLeerling, strgegevens, strNaamVerwijderen, nieuweNaam, uitgelezenGegevens, antwoordVerwijderen;
            string inhoudLogfiles = "", inhoudLogfiles2 = "", resultaat = "", resultaat2 = "", resultaatNamen = "", resultaatNamen2 = "", strOpslaanNamen = "", verwijderenNaam = "";
            string strOptellenPerc = "/", strAftrekkenPerc = "/", strMaalPerc = "/", strDelenPerc = "/";
            double percentageOptellen = 0, percentageAftrekken = 0, percentageMaal = 0, percentageDelen = 0;
            int tellerAantalVragen = 0, tellerJuisteAntwoorden = 0;
            double totaalVragenOptellen = 0, totaalJuisteAntwOptellen = 0, totaalVragenAftrekken = 0, totaalJuisteAntwAftrekken = 0, totaalVragenMaal = 0, totaalJuisteAntwMaal = 0, totaalVragenDelen = 0, totaalJuisteAntwDelen = 0;
            int getal1, getal2, antwoordWiskunde, keuzeGetal, antwoordAantal, arrayGrootte, totaalVragen, tellerInlog = 0;
            int j, teller;
            int uitlijning = 30;
            int aantalVragen = 5;


            //Loop voor volledige app
            while (appRunning)
            {
                Console.WriteLine("Welkom bij RekenRookie! Maak je keuze:");
                Console.WriteLine();
                Console.WriteLine("1.   Leerling");
                Console.WriteLine("2.   Leerkracht");
                Console.WriteLine();
                antwoord = Console.ReadLine();
                Console.Clear();

                // Inlogscherm keuze 1: Leerling
                if (antwoord == "1")
                {
                    if (System.IO.File.Exists("namenLeerlingen2.txt"))
                    {
                        StreamReader leesobject = new StreamReader("namenLeerlingen2.txt");
                        while (!leesobject.EndOfStream)
                        {
                            strgegevens = leesobject.ReadLine();
                            inhoudLogfiles += strgegevens + Environment.NewLine;
                        }
                        leesobject.Close();
                        arrNamenLeerlingen = inhoudLogfiles.Split(';');
                        Array.Resize(ref arrNamenLeerlingen, arrNamenLeerlingen.Length - 1);
                    }
                    else
                    {
                        Console.WriteLine("Er werden nog geen accounts aangamaakt!");
                        Console.WriteLine("Gelieve contact op te nemen met je leerkracht om dit in orde te brengen.");
                        Console.ReadKey();
                        appRunning = false;
                        break;
                    }

                    while (appLeerlingRunning)
                    {
                        Console.WriteLine("Welkom bij RekenRookie!");
                        Console.WriteLine();
                        Console.Write("Geef uw voornaam en achternaam in (bv. Harry Potter): ");
                        naam = Console.ReadLine();
                        Console.Clear();
                        while ((!(naam.Contains(" "))) || (string.IsNullOrWhiteSpace(naam)) || (string.IsNullOrEmpty(naam)))
                        {
                            tellerInlog++;
                            if (tellerInlog == 3) 
                            {
                                Console.WriteLine("Je hebt te vaak proberen inloggen. De applicatie wordt afgesloten.");
                                Environment.Exit(0);
                            }
                            Console.WriteLine("De naam die je hebt ingegeven bestaat niet uit een aparte voornaam en achternaam.");
                            Console.Write("Geef uw voornaam en achternaam in (bv. Harry Potter): ");
                            naam = Console.ReadLine();
                            Console.Clear();
                        }
                        //Controle op naam
                        if (arrNamenLeerlingen.Contains(naam.ToUpper()) || naam == "Admin")
                        {
                            //Loop voor hoofdmenu
                            while (appLeerlingRunning)
                            {
                                Console.WriteLine($"Welkom {naam.ToUpper()} ! Maak je keuze:");
                                Console.WriteLine();
                                Console.WriteLine("1.   Oefeningen");
                                Console.WriteLine("2.   Instellingen");
                                Console.WriteLine("3.   Resultaten");
                                Console.WriteLine("4.   Afsluiten");
                                Console.WriteLine();
                                menuOefeningen = true;
                                menuInstellingen = true;
                                keuzeHoofdmenu = Console.ReadLine();
                                Console.Clear();

                                resultaat = naam.ToUpper().PadLeft(uitlijning) + strOptellenPerc.PadLeft(uitlijning) + strAftrekkenPerc.PadLeft(uitlijning) +
                                                               strMaalPerc.PadLeft(uitlijning) + strDelenPerc.PadLeft(uitlijning) + DateTime.Now.ToString("dd/MM/yyyy").PadLeft(uitlijning);

                                resultaat2 = naam.ToUpper() + ";" + strOptellenPerc + ";" + strAftrekkenPerc + ";" +
                                            strMaalPerc + ";" + strDelenPerc + ";" + DateTime.Now.ToString("dd/MM/yyyy") + ";";

                                //Switch voor keuze hoofdmenu
                                switch (keuzeHoofdmenu)
                                {
                                    // keuze 1 hoofdmenu: Oefeningen
                                    case "1":
                                        while (menuOefeningen)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("**** MENU OEFENINGEN ****");
                                            Console.WriteLine();
                                            Console.WriteLine("1.   Optellen");
                                            Console.WriteLine("2.   Aftrekken");
                                            Console.WriteLine("3.   Vermenigvuldigen");
                                            Console.WriteLine("4.   Delen");
                                            Console.WriteLine("5.   Hoofdmenu");
                                            Console.WriteLine();
                                            keuzeMenu = Console.ReadLine();
                                            Console.Clear();

                                            // switch voor keuze menu oefeningen
                                            switch (keuzeMenu)
                                            {
                                                // keuze 1 menu oefeningen: Optellen
                                                case "1":
                                                    tellerAantalVragen = 0;
                                                    tellerJuisteAntwoorden = 0;
                                                    while (tellerAantalVragen < aantalVragen)
                                                    {
                                                        getal1 = mijnRandom.Next(1, 11);
                                                        getal2 = mijnRandom.Next(1, 11);
                                                        Console.Write($"Oefening nummer {arrOefeningNummer[tellerAantalVragen]}:    {getal1} + {getal2} = ");
                                                        while (!(int.TryParse(Console.ReadLine(), out antwoordWiskunde)))
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal in aub:");
                                                        }
                                                        tellerAantalVragen++;
                                                        totaalVragenOptellen += 1;

                                                        if (antwoordWiskunde == (getal1 + getal2))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine($"Heel goed! {getal1} + {getal2} is inderdaad {antwoordWiskunde}.");
                                                            tellerJuisteAntwoorden++;
                                                            totaalJuisteAntwOptellen += 1;
                                                            Console.ReadKey();
                                                            Console.Clear();

                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine($"Jammer! {antwoordWiskunde} is niet juist.");
                                                            Console.WriteLine($"Het juiste antwoord is: {getal1} + {getal2} = {getal1 + getal2}.");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                        Console.Clear();
                                                    }
                                                    percentageOptellen = totaalJuisteAntwOptellen * 100 / totaalVragenOptellen;
                                                    strOptellenPerc = percentageOptellen.ToString("0.00");
                                                    Console.WriteLine($"Je had {tellerJuisteAntwoorden} van de {tellerAantalVragen} oefeningen juist!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;

                                                // keuze 2 menu oefeningen: Aftrekken
                                                case "2":
                                                    tellerAantalVragen = 0;
                                                    tellerJuisteAntwoorden = 0;
                                                    while (tellerAantalVragen < aantalVragen)
                                                    {
                                                        getal1 = mijnRandom.Next(1, 11);
                                                        getal2 = mijnRandom.Next(getal1, 21);
                                                        Console.Write($"Oefening nummer {arrOefeningNummer[tellerAantalVragen]}:    {getal2} - {getal1} = ");
                                                        while (!(int.TryParse(Console.ReadLine(), out antwoordWiskunde)))
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal in aub:");
                                                        }
                                                        tellerAantalVragen++;
                                                        totaalVragenAftrekken += 1;

                                                        if (antwoordWiskunde == (getal2 - getal1))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine($"Heel goed! {getal2} - {getal1} is inderdaad {antwoordWiskunde}.");
                                                            tellerJuisteAntwoorden++;
                                                            totaalJuisteAntwAftrekken += 1;
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine($"Jammer! {antwoordWiskunde} is niet juist.");
                                                            Console.WriteLine($"Het juiste antwoord is: {getal2} - {getal1} = {getal2 - getal1}.");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                        Console.Clear();

                                                    }
                                                    percentageAftrekken = totaalJuisteAntwAftrekken * 100 / totaalVragenAftrekken;
                                                    strAftrekkenPerc = percentageAftrekken.ToString("0.00");
                                                    Console.WriteLine($"Je had {tellerJuisteAntwoorden} van de {tellerAantalVragen} oefeningen juist!");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                // keuze 3 menu oefeningen: Vermenigvuldigen
                                                case "3":
                                                    tellerAantalVragen = 0;
                                                    tellerJuisteAntwoorden = 0;
                                                    running = true;
                                                    while (running)
                                                    {
                                                        Console.Write($"Geef een getal in waarmee je wil leren vermenigvuldigen (getal van 1 tem 10): ");
                                                        while (!(int.TryParse(Console.ReadLine(), out keuzeGetal)))
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal van 1 tem 10 aub:");
                                                        }
                                                        Console.Clear();
                                                        if (keuzeGetal <= 10 && keuzeGetal > 0)
                                                        {
                                                            while (tellerAantalVragen < aantalVragen)
                                                            {
                                                                getal2 = mijnRandom.Next(1, 11);
                                                                Console.Write($"Oefening nummer {arrOefeningNummer[tellerAantalVragen]}:     {keuzeGetal} x {getal2} = ");
                                                                while (!(int.TryParse(Console.ReadLine(), out antwoordWiskunde)))
                                                                {
                                                                    Console.WriteLine();
                                                                    Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal in aub:");
                                                                }
                                                                tellerAantalVragen++;
                                                                totaalVragenMaal += 1;

                                                                if (antwoordWiskunde == (keuzeGetal * getal2))
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine($"Heel goed! {keuzeGetal} x {getal2} is inderdaad {antwoordWiskunde}.");
                                                                    tellerJuisteAntwoorden++;
                                                                    totaalJuisteAntwMaal += 1;
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine($"Jammer! {antwoordWiskunde} is niet juist.");
                                                                    Console.WriteLine($"Het juiste antwoord is: {keuzeGetal} x {getal2} = {keuzeGetal * getal2}.");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                }
                                                                Console.Clear();
                                                            }
                                                            percentageMaal = totaalJuisteAntwMaal * 100 / totaalVragenMaal;
                                                            strMaalPerc = percentageMaal.ToString("0.00");
                                                            Console.WriteLine($"Je had {tellerJuisteAntwoorden} van de {tellerAantalVragen} oefeningen juist!");
                                                            Console.ReadKey();
                                                            running = false;
                                                            Console.Clear();
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine($"Het door jou gekozen getal is niet correct!");
                                                        }
                                                    }
                                                    break;
                                                // keuze 4 menu oefeningen: Delen
                                                case "4":
                                                    tellerAantalVragen = 0;
                                                    tellerJuisteAntwoorden = 0;
                                                    running = true;
                                                    while (running)
                                                    {
                                                        Console.Write($"Geef een getal in waarmee je wil leren delen (getal van 1 tem 10): ");
                                                        while (!(int.TryParse(Console.ReadLine(), out keuzeGetal)))
                                                        {
                                                            Console.WriteLine();
                                                            Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal van 1 tem 10 aub:");
                                                        }
                                                        Console.Clear();
                                                        if (keuzeGetal <= 10 && keuzeGetal > 0)
                                                        {
                                                            while (tellerAantalVragen < aantalVragen)
                                                            {
                                                                getal1 = (mijnRandom.Next(1, 11) * keuzeGetal);
                                                                Console.Write($"Oefening nummer {arrOefeningNummer[tellerAantalVragen]}:     {getal1} : {keuzeGetal} = ");
                                                                while (!(int.TryParse(Console.ReadLine(), out antwoordWiskunde)))
                                                                {
                                                                    Console.WriteLine();
                                                                    Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal in aub:");
                                                                }
                                                                tellerAantalVragen++;
                                                                totaalVragenDelen += 1;

                                                                if (antwoordWiskunde == (getal1 / keuzeGetal))
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine($"Heel goed! {getal1} : {keuzeGetal} is inderdaad {antwoordWiskunde}.");
                                                                    tellerJuisteAntwoorden++;
                                                                    totaalJuisteAntwDelen += 1;
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine($"Jammer! {antwoordWiskunde} is niet juist.");
                                                                    Console.WriteLine($"Het juiste antwoord is: {getal1} : {keuzeGetal} = {getal1 / keuzeGetal}.");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                }
                                                                Console.Clear();
                                                            }
                                                            percentageDelen = totaalJuisteAntwDelen * 100 / totaalVragenDelen;
                                                            strDelenPerc = percentageDelen.ToString("0.00");
                                                            Console.WriteLine($"Je had {tellerJuisteAntwoorden} van de {tellerAantalVragen} oefeningen juist!");
                                                            Console.ReadKey();
                                                            running = false;
                                                            Console.Clear();
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine($"Het door jou gekozen getal is niet correct!");
                                                        }
                                                    }
                                                    break;
                                                // keuze 5 menu oefeningen: Terug naar Hoofdmenu
                                                case "5":
                                                    menuOefeningen = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                                                    Console.WriteLine("Gelieve je keuze te maken door een getal van 1 tem 5 in te geven.");
                                                    Console.WriteLine();
                                                    break;
                                            }
                                        }
                                        break;
                                    // keuze 2 hoofdmenu: Instellingen
                                    case "2":
                                        while (menuInstellingen)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("**** MENU INSTELLINGEN ****");
                                            Console.WriteLine();
                                            Console.WriteLine("1.   Naam wijzigen");
                                            Console.WriteLine("2.   Hoofdmenu");
                                            Console.WriteLine();
                                            keuzeMenu = Console.ReadLine();
                                            Console.Clear();

                                            // switch menu instellingen
                                            switch (keuzeMenu)
                                            {
                                                // keuze 1 menu instellingen: Naam wijzigen
                                                case "1":
                                                    Console.WriteLine($"De naam waaronder je gekend staat in het programma is: {naam.ToUpper()} .");
                                                    Console.Write("Naar welke naam wil je dit aanpassen: ");
                                                    nieuweNaam = Console.ReadLine();
                                                    if (nieuweNaam.Contains(" ") && (!(string.IsNullOrWhiteSpace(nieuweNaam))) && (!(string.IsNullOrEmpty(nieuweNaam))))
                                                    {
                                                        arrNamenLeerlingen[Array.IndexOf(arrNamenLeerlingen, naam.ToUpper())] = nieuweNaam.ToUpper();  // handig om elementen te overschrijven in een array.
                                                        Console.Clear();
                                                        Console.WriteLine($"{naam.ToUpper()} werd aangepast naar {nieuweNaam.ToUpper()} !");
                                                        naam = nieuweNaam;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("De naam die je hebt ingegeven bestaat niet uit een aparte voornaam en achternaam.");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                // keuze 2 menu instellingen: terug naar Hoofdmenu
                                                case "2":
                                                    menuInstellingen = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                                                    Console.WriteLine("Gelieve je keuze te maken door 1 of 2 in te geven.");
                                                    Console.WriteLine();
                                                    break;
                                            }
                                        }
                                        break;
                                    // keuze 3 hoofdmenu: Resultaten
                                    case "3":
                                        Console.WriteLine($"Dit zijn je resultaten van deze sessie:");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Naam".PadLeft(uitlijning) + "Optellen (in %)".PadLeft(uitlijning) + "Aftrekken (in %)".PadLeft(uitlijning) + "Vermenigvuldigen (in %)".PadLeft(uitlijning) +
                                                                  "Delen (in %)".PadLeft(uitlijning) + "Datum".PadLeft(uitlijning) + Environment.NewLine + Environment.NewLine);
                                        Console.WriteLine(resultaat);
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    // keuze 4 hoofdmenu: Applicatie sluiten
                                    case "4":
                                        Console.WriteLine("Bent je zeker dat je de applicatie wil afsluiten? (ja/nee)");
                                        antwoord = Console.ReadLine();
                                        Console.Clear();

                                        while (antwoord.ToUpper() != "JA" && antwoord.ToUpper() != "NEE")
                                        {
                                            Console.WriteLine("Jou antwoord was niet ja of nee. Gelieve met ja of nee te antwoorden aub!");
                                            Console.WriteLine("Bent je zeker dat je de applicatie wil afsluiten? (ja/nee)");
                                            antwoord = Console.ReadLine();
                                            Console.Clear();
                                        }
                                        if (antwoord.ToUpper() == "JA")
                                        {
                                            totaalVragen = Convert.ToInt32(totaalVragenOptellen) + Convert.ToInt32(totaalVragenAftrekken) + Convert.ToInt32(totaalVragenMaal) + Convert.ToInt32(totaalVragenDelen);
                                            if (totaalVragen != 0)
                                            {
                                                if (System.IO.File.Exists($"{naam.ToUpper()}.txt"))
                                                {
                                                    StreamReader leesopbect = new StreamReader($"{naam.ToUpper()}.txt");
                                                    inhoudLogfiles = leesopbect.ReadToEnd();
                                                    leesopbect.Close();
                                                    StreamReader leesopbect2 = new StreamReader($"{naam.ToUpper()}2.txt");
                                                    inhoudLogfiles2 = leesopbect2.ReadToEnd();
                                                    leesopbect2.Close();

                                                    using (StreamWriter writer = new StreamWriter($"{naam.ToUpper()}.txt"))
                                                    {
                                                        writer.WriteLine(inhoudLogfiles /*+ Environment.NewLine*/ + resultaat /*+ Environment.NewLine*/);
                                                    }
                                                    using (StreamWriter writer = new StreamWriter($"{naam.ToUpper()}2.txt"))
                                                    {
                                                        writer.WriteLine(inhoudLogfiles2 /*+ Environment.NewLine*/ + resultaat2 /*+ Environment.NewLine*/);
                                                    }

                                                }
                                                else
                                                {
                                                    using (StreamWriter writer = new StreamWriter($"{naam.ToUpper()}.txt"))
                                                    {
                                                        writer.WriteLine(resultaat);
                                                    }
                                                    using (StreamWriter writer = new StreamWriter($"{naam.ToUpper()}2.txt"))
                                                    {
                                                        writer.WriteLine(resultaat2);
                                                    }
                                                }
                                            }
                                            for (int i = 0; i < arrNamenLeerlingen.Length; i++)
                                            {
                                                resultaatNamen += arrNamenLeerlingen[i] + Environment.NewLine;
                                            }
                                            using (StreamWriter writer = new StreamWriter("namenLeerlingen.txt"))
                                            {
                                                writer.WriteLine(resultaatNamen);
                                            }
                                            for (int i = 0; i < arrNamenLeerlingen.Length; i++)
                                            {
                                                resultaatNamen2 += arrNamenLeerlingen[i] + ";";
                                            }
                                            using (StreamWriter writer = new StreamWriter("namenLeerlingen2.txt"))
                                            {
                                                writer.WriteLine(resultaatNamen2);
                                            }
                                            Console.WriteLine($"Bedankt om RekenRookie te gebruiken!");
                                            Console.WriteLine("Tot de volgende keer!");
                                            Console.ReadKey();
                                            appLeerlingRunning = false;
                                            appRunning = false;
                                        }
                                        else if (antwoord.ToUpper() == "NEE")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    // default
                                    default:
                                        Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                                        Console.WriteLine("Gelieve je keuze te maken door een getal van 1 tem 4 in te geven.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                }
                            }
                        }
                        //Controle op naam
                        else
                        {
                            Console.WriteLine($"Er bestaat geen profiel op de naam die je hebt ingegeven: {naam} .");
                            Console.WriteLine($"Gelieve contact op te nemen met je leerkracht, zodat voor jou een profiel aangemaakt kan worden.");
                            Console.WriteLine();
                            Console.WriteLine("Wens je de applicatie te sluiten? (ja/nee)");
                            antwoord = Console.ReadLine();
                            Console.Clear();

                            if (antwoord.ToUpper() == "JA")
                            {
                                Console.WriteLine($"Bedankt om RekenRookie te gebruiken!");
                                Console.WriteLine("Tot de volgende keer!");
                                Console.ReadKey();
                                appRunning = false;
                            }
                            else if (antwoord.ToUpper() == "NEE")
                            {
                                Console.Clear();
                            }
                        }
                    }
                }
                // Inlogscherm keuze 2: Leerkracht
                else if (antwoord == "2")
                {
                    while (appLeerkrachtRunning)
                    {
                        Console.Write("Geef je wachtwoord in: ");
                        inlogLeerkracht = Console.ReadLine();
                        Console.Clear();
                        while (inlogLeerkracht != "Admin")
                        {
                            tellerInlog++;
                            if (tellerInlog == 3)
                            {
                                Console.WriteLine("Je hebt te vaak proberen inloggen. De applicatie wordt afgesloten.");
                                Environment.Exit(0);
                            }
                            Console.Clear();
                            Console.WriteLine("Het ingegeven wachtwoord is niet correct.");
                            Console.Write("Geef je wachtwoord in: ");
                            inlogLeerkracht = Console.ReadLine();
                            Console.Clear();
                        }
                        if (inlogLeerkracht == "Admin")
                        {
                            if (System.IO.File.Exists("namenLeerlingen2.txt"))
                            {
                                StreamReader leesobject = new StreamReader("namenLeerlingen2.txt");
                                while (!leesobject.EndOfStream)
                                {
                                    strgegevens = leesobject.ReadLine();
                                    inhoudLogfiles += strgegevens + Environment.NewLine;
                                }
                                leesobject.Close();
                                arrNamenLeerlingen = inhoudLogfiles.Split(';');
                                Array.Resize(ref arrNamenLeerlingen, arrNamenLeerlingen.Length - 1);
                            }
                            while (appLeerkrachtRunning)
                            {
                                Console.WriteLine($"Welkom! Maak je keuze:");
                                Console.WriteLine();
                                Console.WriteLine("1.   Leerlingen beheren");
                                Console.WriteLine("2.   Rapportering");
                                Console.WriteLine("3.   Afsluiten");
                                Console.WriteLine();
                                keuzeHoofdmenu = Console.ReadLine();
                                menuLeerlingBeheren = true;
                                Console.Clear();
                                switch (keuzeHoofdmenu)
                                {
                                    // keuze 1 hoofdmenu: Leerlingen beheren
                                    case "1":
                                        while (menuLeerlingBeheren)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("**** MENU LEERLINGEN BEHEREN ****");
                                            Console.WriteLine();
                                            Console.WriteLine("1.   Leerling Toevoegen");
                                            Console.WriteLine("2.   Naam Wijzigen");
                                            Console.WriteLine("3.   Leerling Verwijderen");
                                            Console.WriteLine("4.   Hoofdmenu");
                                            Console.WriteLine();
                                            keuzeMenu = Console.ReadLine();
                                            Console.Clear();

                                            switch (keuzeMenu)
                                            {
                                                // keuze 1 menu leerlingen beheren: Toevoegen
                                                case "1":
                                                    Console.WriteLine("Volgende leerlingen werden reeds toegevoegd:");
                                                    if (arrNamenLeerlingen.Length > 0)
                                                    {
                                                        foreach (string i in arrNamenLeerlingen)
                                                        {
                                                            Console.WriteLine(i);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("/");
                                                    }
                                                    Console.WriteLine();
                                                    Console.WriteLine("Hoeveel leerlingen wens je toe te voegen?:");
                                                    while (!(int.TryParse(Console.ReadLine(), out antwoordAantal)))
                                                    {
                                                        Console.WriteLine();
                                                        Console.WriteLine($"De opgegeven waarde is geen geheel getal. Geef een geheel getal in aub:");
                                                    }
                                                    Console.Clear();
                                                    if (antwoordAantal > 0)
                                                    {
                                                        arrayGrootte = arrNamenLeerlingen.Length;
                                                        Array.Resize(ref arrNamenLeerlingen, (arrNamenLeerlingen.Length + antwoordAantal));
                                                        for (int i = arrayGrootte; i < (arrNamenLeerlingen.Length); i++)
                                                        {
                                                            Console.WriteLine("Geef een voornaam en achternaam in aub. (bv. Harry Potter):");
                                                            naamLeerling = Console.ReadLine();
                                                            while ((!naamLeerling.Contains(" ")) || string.IsNullOrWhiteSpace(naamLeerling) || string.IsNullOrEmpty(naamLeerling))
                                                            {
                                                                Console.WriteLine("De naam die je hebt ingegeven bestaat niet uit een aparte voornaam en achternaam.");
                                                                Console.WriteLine("Geef een correcte voornaam en achternaam in aub. (bv. Harry Potter):");
                                                                naamLeerling = Console.ReadLine();
                                                            }
                                                            Console.WriteLine();
                                                            arrNamenLeerlingen[i] = naamLeerling.ToUpper();
                                                        }
                                                        Console.Clear();
                                                        Console.WriteLine("De leerling(en) werd(en) toegevoegd!");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Er worden geen leerlingen toegevoegd.");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                    break;
                                                // keuze 2 menu leerlingen beheren: Wijzigen
                                                case "2":
                                                    if (arrNamenLeerlingen.Length > 0)
                                                    {
                                                        Console.WriteLine("Voor welke leerling wens je de naam te wijzigen?:");
                                                        foreach (string i in arrNamenLeerlingen)
                                                        {
                                                            Console.WriteLine(i);
                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Geef 1 van de bovenvermelde namen in:");
                                                        naamProgramma = Console.ReadLine();
                                                        Console.WriteLine();
                                                        if (arrNamenLeerlingen.Contains(naamProgramma.ToUpper()))
                                                        {
                                                            Console.WriteLine("Naar welke naam wil je dit aanpassen:");
                                                            nieuweNaam = Console.ReadLine();
                                                            if (nieuweNaam.Contains(" ") && (!(string.IsNullOrWhiteSpace(nieuweNaam))) && (!(string.IsNullOrEmpty(nieuweNaam))))
                                                            {
                                                                arrNamenLeerlingen[Array.IndexOf(arrNamenLeerlingen, naamProgramma.ToUpper())] = nieuweNaam.ToUpper();
                                                                Console.Clear();
                                                                Console.WriteLine($"{naamProgramma.ToUpper()} werd aangepast naar {nieuweNaam.ToUpper()} !");
                                                                naam = nieuweNaam;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear ();
                                                                Console.WriteLine("De naam die je hebt ingegeven bestaat niet uit een aparte voornaam en achternaam.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear ();
                                                            Console.WriteLine("De naam die je ingegeven hebt is niet gekend in het programma!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Je moet eerst een leerling toevoegen alvorens je gegevens kan wijzigen.");
                                                    }
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                // keuze 3 menu leerlingen beheren: Verwijderen
                                                case "3":
                                                    if (arrNamenLeerlingen.Length > 0)
                                                    {
                                                        Console.WriteLine("Volgende leerlingen zijn gekend in het programma:");
                                                        foreach (string y in arrNamenLeerlingen)
                                                        {
                                                            Console.WriteLine(y);
                                                        }
                                                        for (int i = 0; i < arrNamenLeerlingen.Length; i++)
                                                        {
                                                            strOpslaanNamen += arrNamenLeerlingen[i] + ";";
                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Welke leerling wil je verwijderen?:");
                                                        verwijderenNaam = Console.ReadLine();
                                                        Console.Clear();
                                                        if (arrNamenLeerlingen.Contains(verwijderenNaam.ToUpper()))
                                                        {
                                                            Console.WriteLine($"Ben je zeker dat je {verwijderenNaam.ToUpper()} wil verwijderen? (ja/nee)");
                                                            antwoordVerwijderen = Console.ReadLine();
                                                            Console.Clear();
                                                            if (antwoordVerwijderen.ToUpper() == "JA")
                                                            {
                                                                strNaamVerwijderen = strOpslaanNamen.Replace($"{verwijderenNaam.ToUpper()};", "");
                                                                Console.WriteLine($"{verwijderenNaam.ToUpper()} werd verwijderd!");
                                                                arrNamenLeerlingen = strNaamVerwijderen.Split(';');
                                                                Array.Resize(ref arrNamenLeerlingen, arrNamenLeerlingen.Length - 1);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine($"{verwijderenNaam.ToUpper()} werd NIET verwijderd.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("De naam die je ingegeven hebt is niet gekend in het programma!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Je moet eerst een leerling toevoegen alvorens je een leerling kan verwijderen.");
                                                    }
                                                    strOpslaanNamen = "";
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    break;
                                                // keuze 4 menu leerlingen beheren: Hoofdmenu
                                                case "4":
                                                    menuLeerlingBeheren = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                                                    Console.WriteLine("Gelieve je keuze te maken door een getal van 1 tem 4 in te geven.");
                                                    Console.WriteLine();
                                                    break;
                                            }
                                        }
                                        break;
                                    // keuze 2 hoofdmenu: Rapportering
                                    case "2":
                                        if (arrNamenLeerlingen.Length > 0)
                                        {
                                            Console.WriteLine("Van welke leerling wens je een rapport te raadplegen:");
                                            foreach (string i in arrNamenLeerlingen)
                                            {
                                                Console.WriteLine(i);
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("Geef 1 van de bovenvermelde namen in:");
                                            naamLeerling = Console.ReadLine();
                                            Console.Clear();
                                            while ((!naamLeerling.Contains(" ")) || string.IsNullOrWhiteSpace(naamLeerling) || string.IsNullOrEmpty(naamLeerling))
                                            {
                                                Console.WriteLine("Van welke leerling wens je een rapport te raadplegen:");
                                                foreach (string i in arrNamenLeerlingen)
                                                {
                                                    Console.WriteLine(i);
                                                }
                                                Console.WriteLine();
                                                Console.WriteLine("De naam die je hebt ingegeven bestaat niet uit een aparte voornaam en achternaam.");
                                                Console.WriteLine("Geef een correcte voornaam en achternaam in aub. (bv. Harry Potter):");
                                                naamLeerling = Console.ReadLine();
                                                Console.Clear();
                                            }
                                            if (System.IO.File.Exists($"{naamLeerling.ToUpper()}2.txt"))
                                            {
                                                StreamReader leesobject = new StreamReader($"{naamLeerling.ToUpper()}2.txt");
                                                teller = 0;
                                                uitgelezenGegevens = "";
                                                while (!leesobject.EndOfStream)
                                                {
                                                    teller++;
                                                    uitgelezenGegevens += leesobject.ReadLine();
                                                }
                                                leesobject.Close();

                                                arrNamen = new string[teller];

                                                arrPtnOptellen = new string[teller];
                                                arrPtnAftrekken = new string[teller];
                                                arrPtnMaal = new string[teller];
                                                arrPtnDelen = new string[teller];
                                                arrDatum = new string[teller];
                                                arrTmp = new string[teller];
                                                arrTmp = uitgelezenGegevens.Split(';');
                                                j = 0;
                                                for (int i = 0; i < arrNamen.Length; i++)
                                                {
                                                    arrNamen[i] = arrTmp[j];
                                                    arrPtnOptellen[i] = arrTmp[j + 1];
                                                    arrPtnAftrekken[i] = arrTmp[j + 2];
                                                    arrPtnMaal[i] = arrTmp[j + 3];
                                                    arrPtnDelen[i] = arrTmp[j + 4];
                                                    arrDatum[i] = arrTmp[j + 5];
                                                    j += 6;
                                                }
                                                for (int i = 0; i < arrNamen.Length; i++)
                                                {
                                                    resultaat += arrNamen[i].PadLeft(uitlijning) + arrPtnOptellen[i].PadLeft(uitlijning) + arrPtnAftrekken[i].PadLeft(uitlijning) +
                                                               arrPtnMaal[i].PadLeft(uitlijning) + arrPtnDelen[i].PadLeft(uitlijning) + arrDatum[i].PadLeft(uitlijning) + Environment.NewLine;
                                                }
                                                Console.WriteLine("Naam".PadLeft(uitlijning) + "Optellen (in %)".PadLeft(uitlijning) + "Aftrekken (in %)".PadLeft(uitlijning) + "Vermenigvuldigen (in %)".PadLeft(uitlijning) +
                                                                  "Delen (in %)".PadLeft(uitlijning) + "Datum".PadLeft(uitlijning) + Environment.NewLine + Environment.NewLine);
                                                Console.WriteLine(resultaat);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Er is geen rapport beschikbaar voor deze leerling.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Je moet eerst een leerling toevoegen alvorens je een rapport kan raadplegen.");
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    // keuze 3 hoofdmenu: Afsluiten
                                    case "3":
                                        Console.WriteLine("Bent je zeker dat je de applicatie wil afsluiten? (ja/nee)");
                                        antwoord = Console.ReadLine();
                                        Console.Clear();

                                        while (antwoord.ToUpper() != "JA" && antwoord.ToUpper() != "NEE")
                                        {
                                            Console.WriteLine("Jou antwoord was niet ja of nee. Gelieve met ja of nee te antwoorden aub!");
                                            Console.WriteLine("Bent je zeker dat je de applicatie wil afsluiten? (ja/nee)");
                                            antwoord = Console.ReadLine();
                                            Console.Clear();
                                        }
                                        if (antwoord.ToUpper() == "JA")
                                        {
                                            Array.Sort(arrNamenLeerlingen);
                                            for (int i = 0; i < arrNamenLeerlingen.Length; i++)
                                            {
                                                resultaatNamen += arrNamenLeerlingen[i] + Environment.NewLine;
                                            }
                                            using (StreamWriter writer = new StreamWriter("namenLeerlingen.txt"))
                                            {
                                                writer.WriteLine(resultaatNamen);
                                            }
                                            for (int i = 0; i < arrNamenLeerlingen.Length; i++)
                                            {
                                                resultaatNamen2 += arrNamenLeerlingen[i] + ";";
                                            }
                                            using (StreamWriter writer = new StreamWriter("namenLeerlingen2.txt"))
                                            {
                                                writer.WriteLine(resultaatNamen2);
                                            }
                                            Console.WriteLine($"Bedankt om RekenRookie te gebruiken!");
                                            Console.WriteLine("Tot de volgende keer!");
                                            Console.ReadKey();
                                            appLeerkrachtRunning = false;
                                            appRunning = false;
                                        }
                                        else if (antwoord.ToUpper() == "NEE")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                                        Console.WriteLine("Gelieve je keuze te maken door een getal van 1 tem 3 in te geven.");
                                        Console.WriteLine();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Het ingegeven paswoord is niet correct.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("De keuze die je gemaakt hebt is niet correct!");
                    Console.WriteLine("Gelieve je keuze te maken door 1 of 2 in te geven.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}