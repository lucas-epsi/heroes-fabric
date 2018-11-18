using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Classheroes;
using methods_system;

namespace herofabric
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n       BIENVENUE DANS L'AUBERGE DES HEROS      \n");

            List<heroes> personnages = new List<heroes>();
            string auberge;

            string actualpath = Directory.GetCurrentDirectory();

            /** erased part used to reveal the path including files ending with .sav
             ** in the working repositery
            
            string[] dirs = Directory.GetFiles(actualpath);
            foreach (string dir in dirs)
            {
                
                if (dir.EndsWith(".sav"))
                {

                    Console.WriteLine(dir);
                }
           
            }


            Console.ReadKey();

           **/


            if (File.Exists(actualpath + "/sauvegarde.sav"))
            {   
                Console.WriteLine(" \n récupération Sauvegarde");
                XmlSerializer reader = new XmlSerializer(typeof(List<heroes>));
                StreamReader file = new StreamReader("sauvegarde.sav");
                personnages = (List<heroes>)reader.Deserialize(file);
                auberge = personnages[1].auberge;
                file.Close();
                Console.WriteLine("Sauvegarde récupérée \n");
                Console.ReadKey();
                Console.Clear();
            } else {
                Console.WriteLine(" \n Entrez le nom de votre Auberge : ");
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
                

                Console.WriteLine("Entrez Séléction : ");
                try {Choix = Convert.ToInt32(Console.ReadLine()); }
                catch(FormatException) { Console.WriteLine("tapez un chiffre ! \n"); }
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
                        Console.WriteLine("XP héro : " + newhero1.xp+"/"+newhero1.maxp);
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
                            Console.WriteLine("XP : " + cpt.xp+"/"+cpt.maxp);
                            Console.WriteLine("PV : " + cpt.PV+"/"+cpt.maxPV);
                            if (cpt.vivant == false) { Console.WriteLine(cpt.name+" n'est plus de ce monde..."); }
                            Console.WriteLine("\n");
                        }
                        Console.ReadKey();
                        break;

                    case 4:


                        int index1;
                        Console.WriteLine("Sélectionner 1er héro : \n");
                        foreach (heroes perso in personnages)
                        {
                            Console.WriteLine(personnages.IndexOf(perso) + ") nom :" + perso.name + " \n");
                        }

                        index1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(personnages[index1].name);
                        Console.ReadKey();

                        int index2;
                        Console.WriteLine("\n Sélectionner 2nd héro : \n");
                        foreach (heroes perso in personnages)
                        {
                            Console.WriteLine(personnages.IndexOf(perso) + ") nom :" + perso.name + "\n ");
                        }
                        index2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(personnages[index2].name);
                        Console.ReadKey();

                        var perso1 = personnages[index1];
                        var perso2 = personnages[index2];

                        Console.WriteLine("\n début du combat");

                        Console.WriteLine(perso1.name + " - LVL " + perso1.niveau + " - " + perso1.xp + "/"+perso1.maxp+" xp");
                        Console.WriteLine(perso2.name + " - LVL " + perso2.niveau + " - " + perso2.xp + "/" + perso2.maxp + " xp \n");
                        Console.WriteLine(perso1.name + " VS " + perso2.name + "\n");
                        Console.WriteLine("             FIGHT  \n");

                        // appel de la méthode de boucle de combat
                        methods.Duel(perso1, perso2);


                        // chargement du fichier de sauvegarde
                        XmlDocument docxml = new XmlDocument();
                        docxml.Load(actualpath + "/sauvegarde.sav");

                        // création du nouveau noeud XML à insérer
                        XElement xmltree = new XElement("Root",
                        new XElement("auberge", perso1.auberge),
                        new XElement("name", perso1.name),
                        new XElement("niveau", perso1.niveau),
                        new XElement("xp", perso1.xp),
                        new XElement("maxp", perso1.maxp),
                        new XElement("PV", perso1.PV),
                        new XElement("maxPV", perso1.maxPV),
                        new XElement("force", perso1.force),
                        new XElement("endurance", perso1.endurance),
                        new XElement("agilité", perso1.agilité),
                        new XElement("vivant", perso1.vivant)
                            
                            );
                        XmlElement root = docxml.DocumentElement;
                        Console.WriteLine(root);
                        XmlNode elem = root.SelectSingleNode("heroes[@name = "+perso1.name+"]");
                        // à régler /!\ élement remplaçant pas dans le meme type 
                        // que le node à remplacer
                        elem.ReplaceChild(xmltree, elem);

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

