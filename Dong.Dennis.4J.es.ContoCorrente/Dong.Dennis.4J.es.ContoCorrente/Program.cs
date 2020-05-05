using System;

namespace Dong.Dennis._4J.es.ContoCorrente
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Inizializzazione e creazione della banca*/

            Console.Write("\nInserisci il nome della banca: ");
            string nomeBanca = Console.ReadLine();

            Console.Write("\nInserisci l'indirizzo della banca: ");
            string indirizzoBanca = Console.ReadLine();

            Console.WriteLine("\nBenvenuto cosa vuoi fare?:");
            Banca banca = new Banca(nomeBanca, indirizzoBanca); // Banca

            /*Inserimento dei dati dell'intestatario*/

            int selezione = Opzioni();
            while (selezione != 99)
            {
                switch (selezione)
                {
                    case 1:
                        ModificaBanca(banca);
                        break;
                    case 2:
                        InserisciIntestatario(banca);
                        break;
                    case 3:
                        ModificaIntestatario(banca);
                        break;
                    case 4:
                        StampaMovimenti(banca);
                        break;
                    case 5:
                        EseguiBonifico(banca);
                        break;
                    case 6:
                        EseguiVersamento(banca);
                        break;
                    case 7:
                        EseguiPrelievo(banca);
                        break;
                    case 8:
                        //Stampa Tutti gli intestatari presenti
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nElenco clienti della banca " + banca.Nome);
                        foreach (ContoCorrente _conto in banca.conti)
                        {
                            Console.WriteLine(_conto.Intestatario.Nome + " IBAN: " + _conto.Iban);
                        }
                        Console.WriteLine("Ritorna all'home in corso........");
                        break;
                    case 9:
                        //Stampa Il saldo di un conto se è presente
                        Console.WriteLine("Nome banca: " + banca.Nome + "\nIndirizzo banca: " + banca.Indirizzo);
                        Console.WriteLine("Ritorna all'home in corso........");
                        break;
                    case 10:
                        Console.Write("Inserire IBAN del conto da verficare: ");
                        string ibanVerficare = Console.ReadLine();
                        bool ibanTrovato = false;
                        foreach (ContoCorrente c in banca.conti)
                        {
                            if (c.Iban == ibanVerficare)
                            {
                                ibanTrovato = true;
                                Console.WriteLine("\n------------------------------\n");
                                Console.WriteLine("Il saldo del conto " + ibanVerficare + " è di: " + c.Saldo);
                            }
                        }
                        if (ibanTrovato == false)
                        {
                            Console.WriteLine("IBAN non trovato inserisci un iban adeguato");
                        }
                        Console.WriteLine("Ritorna all'home in corso........");
                        break;
                    case 11:
                        AggiungiConto(banca);
                        break;
                }
                selezione = Opzioni();
            }
            Console.WriteLine("\nGrazie per aver scelto la banca " + banca.Nome);
            Console.WriteLine("Per terminare il programma premere un qualunque tasto...");
            Console.ReadKey();
        }

        public static int Opzioni()
        {
            int selezione = 0;

            do
            {
                try
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("1 - Modifica info banca");
                    Console.WriteLine("2 - Inserisci nuovo intestatario");
                    Console.WriteLine("3 - Modififca intestatario presente");
                    Console.WriteLine("4 - Stampa movimenti");
                    Console.WriteLine("5 - Effettua bonifico");
                    Console.WriteLine("6 - Effettua versamento");
                    Console.WriteLine("7 - Effettua prelievo");
                    Console.WriteLine("8 - Stampa clienti presenti");
                    Console.WriteLine("9 - Stampa info banca");
                    Console.WriteLine("10 - Stampa saldo conto");
                    Console.WriteLine("11 - Aggiungi nuovo conto a intestatario");
                    Console.WriteLine("\n99 - Esci");
                    Console.WriteLine("\n------------------------------\n");
                    Console.Write("Scelta : ");
                    selezione = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Errore di inserimento riprova");
                    selezione = 0;
                }

            } while (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 4 && selezione != 5 && selezione != 6 && selezione != 7 && selezione != 8 && selezione != 9 && selezione != 10 && selezione != 11 && selezione != 99);

            return selezione;
        }

        public static void ModificaBanca(Banca banca)
        {
            string selezione = "";
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Vuoi cambiare Il nome?:");
            Console.WriteLine("Risposta:");
            selezione = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\n------------------------------\n");
            if (selezione == "si" || selezione == "sì")
            {
                Console.Write("Inserisci il nuovo nome: ");
                banca.Nome = Console.ReadLine();
                Console.WriteLine("Nome modificato con sucesso");
                Console.WriteLine("\n------------------------------\n");
            }
            else
            {
                if (selezione == "no")
                {
                    Console.WriteLine("Vuoi Cambiare L'indirizzo?:");
                    Console.WriteLine("Risposta:");
                    selezione = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\n------------------------------\n");
                    if (selezione == "si" || selezione == "sì")
                    {
                        Console.Write("Inserisci indirizzo: ");
                        banca.Indirizzo = Console.ReadLine();
                        Console.WriteLine("Indirizzo modificato con successo");
                        Console.WriteLine("\n------------------------------\n");
                    }

                }
                Console.WriteLine("Ritorna all'home in corso........");

            }
        }

        public static void InserisciIntestatario(Banca banca)
        {
            Random iban_casuale = new Random();
            string nome, cf, telefono, mail, indirizzo;
            DateTime dataNascita = new DateTime();

            Console.WriteLine("\n------------------------------\n");
            Console.Write("Inserisci il nome: ");
            nome = Convert.ToString(Console.ReadLine());

            Console.Write("\nInserisci il codice fiscale: ");
            cf = Convert.ToString(Console.ReadLine());

            Console.Write("\nInserisci il numero di telefono: ");
            telefono = Convert.ToString(Console.ReadLine());

            Console.Write("\nInserisci la mail: ");
            mail = Convert.ToString(Console.ReadLine());

            Console.Write("\nInserisci l'indirizzo: ");
            indirizzo = Convert.ToString(Console.ReadLine());

            bool errore = true;
            while (errore == true)
            {
                try
                {
                    string[] data;

                    Console.Write("\nInserisci data di nascita (anno/mese/giorno): ");
                    data = Convert.ToString(Console.ReadLine()).Split('/');

                    dataNascita = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                    errore = false;
                }
                catch
                {
                    errore = true;
                    Console.WriteLine("\nErrore nell'inserimento dei dati riprova a mettere la data di nascita adeguata");
                }
            }

            Intestatario intestatario = new Intestatario(nome, cf, telefono, mail, indirizzo, dataNascita);
            Console.WriteLine("Intestatario inserito con successo");
            banca.AddCliente(intestatario);
            string risp;
            do
            {
                Console.Write("\nVuoi creare un conto online? (si/no) ");
                Console.WriteLine("\nRisposta:");
                risp = Console.ReadLine();

                if (risp == "si" || risp == "sì")
                {
                    Console.WriteLine("\nCreazione conto online...");
                    ContoCorrente contoOnline = new ContoOnline(intestatario, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca, 2500);
                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                }
                else if (risp == "no")
                {
                    Console.WriteLine("\nCreazione del conto...");

                    ContoCorrente conto = new ContoCorrente(intestatario, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca);
                    banca.AddConto(conto);

                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                }
                else
                {
                    Console.WriteLine("\nErrore, valore inserito non valido riprova\n");
                }

            } while (risp != "si" && risp != "sì" && risp != "no");
            Console.WriteLine("Ritorna all'home in corso........");

        }

        public static void ModificaIntestatario(Banca banca)
        {
            string iban = "", nome, cf, telefono, mail, indirizzo;
            DateTime dataNascita = new DateTime();
            Intestatario intestatario = new Intestatario("", "", "", "", "", DateTime.Now);

            //Prima di modificare l'intestatario si cerca prima l'iban inserito se è tra quelli all'interno della lista iban
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Inserisci IBAN del cliente da modificare: ");
            string ibanIntestatario = Console.ReadLine();

            foreach (ContoCorrente i in banca.conti)
            {
                if (i.Iban == ibanIntestatario)
                {
                    iban = i.Iban;
                    intestatario = i.Intestatario;
                }
            }

            if (iban == "")
            {
                Console.WriteLine("\nIl cliente non è presente nella lista metti un iban adeguato");
            }
            else
            {
                Console.WriteLine("Inserire dati cliente...\n");
                Console.Write("Inserisci nome: ");
                nome = Convert.ToString(Console.ReadLine());

                Console.Write("\nInserisci codice fiscale: ");
                cf = Convert.ToString(Console.ReadLine());

                Console.Write("\nInserisci numero di telefono: ");
                telefono = Convert.ToString(Console.ReadLine());

                Console.WriteLine("\nInserisci mail: ");
                mail = Convert.ToString(Console.ReadLine());

                Console.Write("\nInserisci indirizzo: ");
                indirizzo = Convert.ToString(Console.ReadLine());

                bool errore = true;
                while (errore == true)
                {
                    try
                    {
                        string[] data;

                        Console.Write("\nInserisci data di nascita (anno/mese/giorno): ");
                        data = Convert.ToString(Console.ReadLine()).Split('/');

                        dataNascita = new DateTime(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                        errore = false;
                    }
                    catch
                    {
                        errore = true;
                        Console.WriteLine("\nErrore nell'inserimento dei dati riprova");
                    }
                }

                intestatario.Nome = nome;
                intestatario.Cf = cf;
                intestatario.Indirizzo = indirizzo;
                intestatario.Mail = mail;
                intestatario.Telefono = telefono;
                intestatario.DataNascita = dataNascita;
            }
            Console.WriteLine("Intestatario modificato correttamente\n");
            Console.WriteLine("Ritorna all'home in corso........");
        }

        public static void StampaMovimenti(Banca banca)
        {
            int selezione = 0;

            while (selezione != 99)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("1 - Stampa movimenti di un dato giorno");
                        Console.WriteLine("2 - Stampa movimenti di un dato cliente");
                        Console.WriteLine("3 - Stampa movimenti di un dato cliente in un dato giorno");
                        Console.WriteLine("\n99 - Indietro\n");
                        Console.Write("Scelta : ");
                        selezione = int.Parse(Console.ReadLine());
                        if (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99)
                        {
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine("Errore nell'inserimento dei dati riprova");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("Errore nell'inserimento dei dati riprova");
                        selezione = 0;
                    }

                } while (selezione != 1 && selezione != 2 && selezione != 3 && selezione != 99);

                switch (selezione)
                {
                    case 1:
                        DateTime data = new DateTime();
                        bool errore = true;
                        while (errore == true)
                        {
                            try
                            {
                                string[] data1;

                                Console.WriteLine("\n------------------------------");
                                Console.Write("Inserisci data (anno/mese/giorno): ");
                                data1 = Convert.ToString(Console.ReadLine()).Split('/');

                                data = new DateTime(int.Parse(data1[0]), int.Parse(data1[1]), int.Parse(data1[2]));
                                errore = false;
                            }
                            catch
                            {
                                errore = true;
                                Console.WriteLine("\n------------------------------");
                                Console.WriteLine("Errore nell'inserimento dei dati riprova");
                            }
                        }

                        Console.WriteLine(banca.GetMovimento(data));
                        break;

                    case 2:
                        string iban;
                        bool trovato = false;
                        //Prima di stampare il movimento dell'intestatario si cerca l'iban inserito da utente se è presente nella lista iban
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban = Console.ReadLine();
                        Intestatario intestatario = new Intestatario("", "", "", "", "", DateTime.Now);
                        foreach (ContoCorrente i in banca.conti)
                        {
                            if (i.Iban == iban)
                            {
                                intestatario = i.Intestatario;
                                trovato = true;
                            }
                        }

                        if (trovato == true)
                        {
                            Console.WriteLine(banca.GetMovimento(intestatario));
                        }
                        else
                        {
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine("Cliente non trovato inserisci un iban che sia presente nella lista");
                        }
                        break;

                    case 3:
                        DateTime data2 = new DateTime();
                        bool errore2 = true;
                        while (errore2 == true)
                        {
                            try
                            {
                                string[] sdata;

                                Console.WriteLine("\n------------------------------");
                                Console.Write("Inserisci data (anno/mese/giorno): ");
                                sdata = Console.ReadLine().ToString().Split('/');

                                data = new DateTime(int.Parse(sdata[0]), int.Parse(sdata[1]), int.Parse(sdata[2]));
                                errore2 = false;
                            }
                            catch
                            {
                                errore2 = true;
                                Console.WriteLine("\n------------------------------");
                                Console.WriteLine("Errore nell'inserimento dei dati");
                            }
                        }

                        string iban2;
                        bool trovato2 = false;
                        Console.WriteLine("\n------------------------------");
                        Console.WriteLine("Inserire IBAN del cliente da cercare: ");
                        iban2 = Console.ReadLine();
                        Intestatario intestatario2 = new Intestatario("", "", "", "", "", DateTime.Now);
                        //Stesso procedimento precedente
                        foreach (ContoCorrente i in banca.conti)
                        {
                            if (i.Iban == iban2)
                            {
                                intestatario2 = i.Intestatario;
                                trovato2 = true;
                            }
                        }

                        if (trovato2 == true)
                        {
                            Console.WriteLine(banca.GetMovimento(data2, intestatario2));
                        }
                        else
                        {
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine("Cliente non trovato inserisci un iban adeguato");
                        }
                        break;
                }
            }
        }

        public static void EseguiBonifico(Banca banca)
        {
            bool trovato = false;

            Console.WriteLine("\n------------------------------\n");
            Console.Write("Inserire IBAN mittente: ");
            string ibanMittente = Console.ReadLine();
            //Cerca l'iban Mittente se è presente nella lista iban
            foreach (ContoCorrente c in banca.conti)
            {
                if (c.Iban == ibanMittente)
                {
                    trovato = true;
                }
            }

            if (trovato == true)
            {
                trovato = false;
                Console.WriteLine("\n------------------------------");
                Console.Write("Inserire IBAN destinatario: ");
                string ibanDestinatario = Console.ReadLine().ToString();
                //Cerca l'iban Destinatario se è presente nella lista iban
                foreach (ContoCorrente c in banca.conti)
                {
                    if (c.Iban == ibanDestinatario)
                    {
                        trovato = true;
                    }
                }
                if (trovato == true)
                {
                    Bonifico bonifico = new Bonifico(banca, ibanMittente, ibanDestinatario);
                    double importo = 0;
                    do
                    {
                        Console.WriteLine("\n------------------------------");
                        Console.Write("Inserire importo bonifico: ");
                        importo = double.Parse(Console.ReadLine());

                    } while (importo < 0);
                    bonifico.EffettuaBonifico(importo);
                    Console.WriteLine("\nBonifico dal valore di " + importo + " euro effettuato all'ora " + DateTime.Now);
                }
                else
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("IBAN destinatario non trovato");
                    Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                    Console.WriteLine("\nRisposta:");
                    string risp = Console.ReadLine();

                    if (risp == "si" || risp == "sì")
                    {
                        InserisciIntestatario(banca);
                    }
                }
            }
            else
            {
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("IBAN mittente non trovato");
                Console.Write("\nVuoi Creare un nuovo conto corrente? (si/no) ");
                Console.WriteLine("\nRisposta:");
                string risp = Console.ReadLine();

                if (risp == "si" || risp == "sì")
                {
                    InserisciIntestatario(banca);
                }
            }
            Console.WriteLine("Ritorna all'home in corso........");

        }

        public static void EseguiVersamento(Banca banca)
        {
            string iban;
            double importo;

            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Inserire IBAN conto: ");
            iban = Convert.ToString(Console.ReadLine());

            ContoCorrente conto = banca.getConto(iban);

            Console.WriteLine("\nInserire importo versamento: ");
            importo = double.Parse(Console.ReadLine());

            conto.IncrementaSaldo(importo);
            Console.WriteLine("\nVersamento di " + importo + " euro effettuato");
            Console.WriteLine("Ritorna all'home in corso........");
        }

        public static void EseguiPrelievo(Banca banca)
        {
            string iban;
            double importo;

            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Inserire IBAN conto: ");
            iban = Convert.ToString(Console.ReadLine());

            ContoCorrente conto = banca.getConto(iban);

            Console.WriteLine("\nInserire importo prelievo: ");
            importo = double.Parse(Console.ReadLine());

            string risultatoPrelievo = conto.Preleva(importo);

            if (risultatoPrelievo != "Hai prelevato con successo")
            {
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("Errore il tuo saldo è minore del prelievo richiesto devi versare un importo prima di prelevare");
            }
            else
            {
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("Prelievo di " + importo + " euro effettuato con successo");
            }
            Console.WriteLine("Ritorna all'home in corso........");
        }

        public static void AggiungiConto(Banca banca)
        {
            bool trovato = false;
            Random iban_casuale = new Random();

            Console.WriteLine("\n------------------------------\n");
            Console.Write("Inserire codice fiscale cliente: ");
            Intestatario cliente = new Intestatario("", "", "", "", "", DateTime.Now);
            string cf = Console.ReadLine();
            //Prima di creare un'altro conto intestato ad una persona si controlla il Cf se nella lista Cf sia presente quello inserito da utente
            foreach (Intestatario c in banca.clienti)
            {
                if (c.Cf == cf)
                {
                    trovato = true;
                    cliente = c;
                }
            }

            if (trovato == true)
            {
                string risposta = "";
                do
                {
                    Console.WriteLine("\n------------------------------");
                    Console.WriteLine("Vuoi aggiungere un conto online? (si/no)");
                    Console.WriteLine("\nRisposta:");
                    risposta = Console.ReadLine();
                    if (risposta != "si" && risposta != "sì" && risposta != "no")
                    {
                        Console.WriteLine("\nErrore nell'inserimento dati");
                    }
                } while (risposta != "si" && risposta != "sì" && risposta != "no");

                if (risposta == "no")
                {
                    Console.WriteLine("Creazione del conto...");
                    ContoCorrente conto = new ContoCorrente(cliente, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca);
                    banca.AddConto(conto);
                    cliente.AddConto(conto);

                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100 e con iban: " + conto.Iban + "\n\n");
                }
                else
                {
                    Console.WriteLine("Creazione conto online...");
                    ContoCorrente contoOnline = new ContoOnline(cliente, 100, "IT39" + iban_casuale.Next(10000, 1000000), banca, 2500);
                    Console.WriteLine("Conto corrente creato con numero massimo di movimenti pari a 100, un prelievo massimo di 2500 e con iban: " + contoOnline.Iban + "\n\n");
                }
            }
            else
            {
                string risposta = "";

                Console.WriteLine("\n------------------------------");
                Console.WriteLine("Cliente non trovato, vuoi inserirlo? (si/no)");
                Console.WriteLine("\nRisposta:");
                risposta = Console.ReadLine();

                if (risposta == "si" || risposta == "sì")
                {
                    InserisciIntestatario(banca);
                }
            }
            Console.WriteLine("Ritorna all'home in corso........");
        }
    }
    
}
