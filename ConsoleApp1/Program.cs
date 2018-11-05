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
            Console.WriteLine("     BIENVENUE DANS L'AUBERGE DES HEROS      ");
            
            List<heroes> personnages = new List<heroes>();
            string auberge;
            
            string actualpath = Directory.GetCurrentDirectory();
            if (File.Exists(actualpath + "/sauvegarde.sav"))
            {   
                Console.WriteLine("récupération Sauvegarde");
                XmlSerializer reader = new XmlSerializer(typeof(List<heroes>));
                StreamReader file = new StreamReader("sauvegarde.sav");
                personnages = (List<heroes>)reader.Deserialize(file);
                auberge = personnages[1].auberge;
                file.Close();
                Console.WriteLine("Sauvegarde récupérée \n");
                Console.ReadKey();
                Console.Clear();
            } else {
                Console.WriteLine("Entrez le nom de votre Auberge : ");
                auberge = Console.ReadLine();
            }
            int Choix = 0;
            // beginning of the loop for the iteration of the interface
            do
            {
                Console.WriteLine("     "+auberge+"\n");
                Console.WriteLine("     choisissez action       ");
                Console.WriteLine("1) Créer nouvel héro ");
                Console.WriteLine("2) Supprimer héro existant ");
                Console.WriteLine("3) Afficher liste des héros");
                Console.WriteLine("4) Entrainer héro ");
                Console.WriteLine("5) lancer duel entre héros ");
                Console.WriteLine("6) Quitter Jeu \n");


                Console.ReadKey();

                Console.WriteLine("Entrez Séléction : ");
                try { Choix = Convert.ToInt32(Console.ReadLine()); }
                catch(FormatException) { Console.WriteLine("try again \n"); }
                Console.Clear();

                switch (Choix)
                {
                    case 1:

                        string nom;
                        Console.WriteLine("Entrez nom nouveau héro : ");
                        nom = Console.ReadLine();
                        heroes newhero1 = new heroes();
                        newhero1.name = nom;
                        newhero1.auberge = auberge;

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

                        Console.ReadKey();

                        break;

                    case 2:

                        break;

                    case 3:
                        Console.WriteLine("Liste des personnages créés : \n");
                        foreach (heroes cpt in personnages)
                        {
                            Console.WriteLine("nom : " + cpt.name);
                            Console.WriteLine("Niveau : " + cpt.niveau);
                            Console.WriteLine("XP : " + cpt.xp);
                            Console.WriteLine("PV : " + cpt.PV + "\n");
                        }
                        Console.ReadKey();
                        break;

                    case 4:

                        string choixperso;
                        int index = 0;
                        Console.WriteLine("Sélectionner héro :");
                        foreach (heroes perso in personnages)
                        {
                            Console.WriteLine("nom :" + perso.name);
                        }
                        choixperso = Console.ReadLine();

                        foreach (heroes perso in personnages)
                        {
                            if (choixperso == perso.name)
                            {
                                Console.WriteLine("héro sélectionné : " + perso.name);
                                index = personnages.IndexOf(perso);
                            }
                        }

                        if (index == 0) { Console.WriteLine("héro inexistant..."); Console.ReadKey(); break; }

                        Console.WriteLine(personnages[index].name);
                        Console.WriteLine("Dégat 1 = "+personnages[index].GetDegat());
                        Console.WriteLine("Dégat 2 = " + personnages[index].GetDegat());
                        Console.ReadKey();

                        break;

                    case 5:
                       
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

