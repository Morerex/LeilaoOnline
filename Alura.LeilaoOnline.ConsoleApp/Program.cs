using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //LeilaoConVariosLances();

            //LeilaoComUmLance();

            Console.ReadKey();
        }



        private static void Verifica(double esperado,double obtido)
        {
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falha");
            }
        }


    }
}
