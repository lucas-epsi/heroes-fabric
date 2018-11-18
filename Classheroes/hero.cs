using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Classheroes
{
    [Serializable()]
    public class heroes
    {
        public string auberge { get; set; }
        public string name { get; set; }
        public int niveau { get; set; }
        public int xp { get; set; }
        public int maxp { get; set; }
        public int PV { get; set; }
        public int maxPV { get; set; }
        public int force { get; set; }
        public int endurance { get; set; }
        public int agilité { get; set; }
        public bool vivant { get; set; }


        public heroes()
            {
            niveau = 1;
            xp = 0;
            maxp = 100;
            PV = 100;
            maxPV = 100;
            force = 10;
            endurance = 10;
            agilité = 10;
            vivant = true;
             }

        public void gainxp(int a)
        {
            xp += a;
            if (xp >= maxp)
            {
                this.levelup();
            }

            }


        public void levelup()
        {
           
            niveau++;
            Console.WriteLine(this.name + "a LEVEL UP !");
            Console.WriteLine("Niveau " + niveau + " atteint !");
            maxp += (int)maxp*20/100;
            maxPV += (int)maxPV * 15 / 100;
            if (vivant == true)
            {
                PV = maxPV;
            }

        }

         public int GetDegat()
        {
            int Degat;
            Random aleatoire = new Random();
            int entier = aleatoire.Next();
            int entre1et5 = aleatoire.Next(5);
            Degat = force + (force+entre1et5);

            return Degat;
        }

        public void Setdamage(int a)
        {       
         PV = PV - a +(endurance / 2);
            if (PV < 0)
            {
                PV = 0;
                Console.WriteLine(name + " a trépassé...");
                vivant = false;
            }
        }

    }
}





