using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using Classheroes;
using methods_system;

namespace herofabric
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            List<heroes> personnages = new List<heroes>();


            string actualpath = Directory.GetCurrentDirectory();
            Console.WriteLine(actualpath);
            if (File.Exists(actualpath + "/sauvegarde.sav"))
            {   
                Console.WriteLine("récupération Sauvegarde");
                XmlSerializer reader = new XmlSerializer(typeof(List<heroes>));
                StreamReader file = new StreamReader("sauvegarde.sav");
                personnages = (List<heroes>)reader.Deserialize(file);
                file.Close();
                Console.WriteLine("Sauvegarde récupérée");
            }
            int Choix = 0;
            // beginning of the loop for the iteration of the interface
            do
            {
                Console.WriteLine("     AUBERGE DES HEROS       ");
                Console.WriteLine("     choisissez action       ");
                Console.WriteLine("1) Créer nouvel héro ");
                Console.WriteLine("2) Supprimer héro existant ");
                Console.WriteLine("3) Afficher liste des héros");
                Console.WriteLine("4) Entrainer héro ");
                Console.WriteLine("5) lancer duel entre héros ");
                Console.WriteLine("6) Quitter Jeu \n");


                Thread.Sleep(1000);

                Console.WriteLine("Entrez Séléction : ");
                Choix = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (Choix)
                {
                    case 1:

                        string nom;
                        Console.WriteLine("Entrez nom nouveau héro : ");
                        nom = Console.ReadLine();
                        heroes newhero1 = new heroes();
                        newhero1.name = nom;

                        personnages.Add(newhero1);
                        methods.retourchariot();
                        
                        Console.WriteLine("nom héro : " + newhero1.name);
                        Console.WriteLine("Niveau héro : " + newhero1.niveau);
                        Console.WriteLine("XP héro : " + newhero1.xp);
                        Console.WriteLine("PV héro : " + newhero1.PV + "\n");

                        XmlSerializer serializer = new XmlSerializer(typeof(List<heroes>));
                        StreamWriter ecrivain = new StreamWriter("sauvegarde.sav");
                        serializer.Serialize(ecrivain, personnages);
                        ecrivain.Close();
                       
                        Thread.Sleep(1000);

                        break;

                    case 2:
                        Console.WriteLine("Liste des personnages créés : \n");
                        foreach(heroes cpt in personnages)
                        {
                            Console.WriteLine("nom : "+cpt.name);
                            Console.WriteLine("Niveau : "+cpt.niveau);
                            Console.WriteLine("XP : " + cpt.xp);
                            Console.WriteLine("PV : " + cpt.PV + "\n");
                        }
                        Thread.Sleep(3000);
                        break;
                        
                    case 3:
                        XMLwrite read = new XMLwrite();
                        read.ReadXML();
                        break;

                    case 4:

                        break;

                    case 5:
                        XmlSerializer serializer2 = new XmlSerializer(typeof(heroes));
                        StreamReader lecteur = new StreamReader("Test.xml");
                        heroes hero = (heroes)serializer2.Deserialize(lecteur);
                        lecteur.Close();

                        break;

    //end switch loop for menu selection
                }

                Console.Clear();
                //end do loop
            } while (Choix != 6);
            // end main declaration
        } 
        // end class programm
    }
}

