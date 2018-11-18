using Classheroes;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;

namespace methods_system
{
    public class methods
    {

        public static string retourchariot()
        {
            string X = Environment.NewLine;
            return X;
        }

        public static int calculxp(heroes hero1)
        {

            int exp = hero1.maxp/hero1.niveau;
            return exp;

        }

        public static void Duel(heroes hero1, heroes hero2)
        {
            int cpt = 0;
            while (hero1.PV > 0 && hero2.PV > 0)
            {
                if ( cpt % 2 == 1) {
                        int attaque1 = hero1.GetDegat();
                        Console.WriteLine(hero1.name + " inflige " + attaque1 + " dégats \n");
                        hero2.Setdamage(attaque1);

                        Console.WriteLine(hero2.name + " : " + hero2.PV + " PV restants");
                        Console.WriteLine();
                        Console.ReadKey();

                    } else {
                        int attaque2 = hero2.GetDegat();
                        Console.WriteLine(hero2.name + " inflige " + attaque2 + " dégats \n");
                        hero1.Setdamage(attaque2);

                        Console.WriteLine(hero1.name + " : " + hero1.PV + " PV restants");
                        Console.WriteLine();
                       
                        Console.ReadKey();
                    }
                cpt++;
            }
         
            if (hero2.vivant==true)
            {
                Console.WriteLine(" \n Le vainqueur est " + hero2.name);
                hero2.xp +=calculxp(hero1);
                while (hero2.xp >= hero2.maxp)
                    {
                    hero2.xp = hero2.xp - hero2.maxp;
                    hero2.levelup();
                    
                }
                hero2.PV = hero2.maxPV;
            } else
            {
                Console.WriteLine(" \n Le vainqueur est " + hero1.name);
                hero1.xp =calculxp(hero2);
                while (hero1.xp >= hero1.maxp)
                {
                    hero1.xp -= hero1.maxp;
                    hero1.levelup();

                }
                hero1.PV = hero1.maxPV;
            }

            Console.ReadKey();

        }

    }
}

