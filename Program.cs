using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Växelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
             //värden
            double totalt = 0;
            uint belopp;
            double ore = 0;
            uint avdrag;
            uint tillbaka;



            //låta användaren skriva in värdet på summan
            //gör så att ReadLine kan ta emot en double
            while (true)
            {

                try
                {
                    Console.Write("Ange totalsumma     :  ");

                    totalt = double.Parse(Console.ReadLine());

                    // om totalt är för litet
                    if ( totalt < 1)

                    //  kasta undantag
                    throw new Exception();

                    break;
                }

                catch
                {
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Totalsumman är för liten. köpet kunder inte genomföras.");
                    Console.ResetColor();
                }
            }
            //låta användaren skriva in värdet på beloppet
           
            while (true)
            {

                try
                { 
                    Console.Write("Ange erhållet belopp:  ");

                    belopp = uint.Parse(Console.ReadLine());

                    //om beloppet är mindre än totalt
                    if (belopp < totalt)

                        //kasta undantag
                        throw new Exception();

                    break;
                }
                    //när användaren använder bokstäver istället för siffror
                catch(FormatException){
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Erhållet belopp är felaktig.");
                    Console.ResetColor();
                }
                catch
                {
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erhållet belopp är för litet. Köpet kunde inte genomföras.");
                    Console.ResetColor();
                    return;
                }
            }

            
            //gör en ny rad
            Console.WriteLine();

            Console.WriteLine("KVITTO");

            Console.WriteLine("-------------------------------");

            //totala summan
            Console.WriteLine("Totalt        : {0,15:c}", totalt);

            //drar av ören
            avdrag = (uint)Math.Round(totalt);
            ore = avdrag - totalt;

            //visar öresavrundningen
            Console.WriteLine("Öresavrundning: {0,15:c}", ore);

            //räknar ut vad man ska betala

            //visar vad man ska betala med det nya värdet från totalt
            Console.WriteLine("Att betala    : {0,15:c0}", totalt);

            //visar Kontant
            Console.WriteLine("Kontant       : {0,15:c0}", belopp);

            //räknar ut växeln
            tillbaka = belopp - avdrag;

            //visar vad man ska ha i växel
            Console.WriteLine("Tillbaka      : {0,15:c0}", tillbaka);

            Console.WriteLine("-------------------------------");

            //gör en ny rad
            Console.WriteLine();

            //kolla hur många 500 lappar som kan komma in i växeln
            if (tillbaka / 500 >= 1)
            {
                Console.WriteLine("500-lappar    : " + tillbaka / 500);
                //tar bort antal 500 lappar från växeln och ger växeln ett nytt värde av det som finns kvar.
                tillbaka %= 500;
            }
            //kollar hur många 100 lappar som kan komma in i nya värdet
            if (tillbaka / 100 >= 1)
            {
                Console.WriteLine("100-lappar    : " + tillbaka / 100);
                //tar bort antal 100 lappar och ger växeln ett nytt värde.
                tillbaka %= 100;
            }
            //osv
            if (tillbaka / 50 >= 1)
            {
                Console.WriteLine("50-lappar    : " + tillbaka / 50);
                tillbaka %= 50;
            }

            if (tillbaka / 20 >= 1)
            {
                Console.WriteLine("20-lappar     : " + tillbaka / 20);
                tillbaka %= 20;
            }

            if (tillbaka / 5 >= 1)
            {
                Console.WriteLine("5-kronor      : " + tillbaka / 5);
                tillbaka %= 5;
            }

            if (tillbaka >= 1)
            {
                Console.WriteLine("1-kronor      : " + tillbaka);
            }
        }
    }
}
