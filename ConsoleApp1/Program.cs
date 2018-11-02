using System;
using System.Threading;


namespace herofabric
{

    public class ThreadWork
    {
        public static void DoWork()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working thread...");
                Thread.Sleep(100);
            }
        }
    }

    public class ThreadTest
    {
        public static void Main1()
        {
            Thread thread1 = new Thread(ThreadWork.DoWork);
            thread1.Start();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("     AUBERGE DES HEROS       ");
            Console.WriteLine("     choisissez action       ");
            Console.WriteLine("1) Créer nouvel héro ");
            Console.WriteLine("2) Supprimer héro existant ");
            Console.WriteLine("3) Afficher liste des héros");
            Console.WriteLine("4) Entrainer héro ");
            Console.WriteLine("5) lancer duel entre héros ");



            string mavar = Console.ReadLine();
            Console.WriteLine(mavar);

            Thread thread1 = new Thread(ThreadWork.DoWork);
            thread1.Start();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }

            Thread.Sleep(2000);
            Console.WriteLine("dowork");
        }
    }
}  
