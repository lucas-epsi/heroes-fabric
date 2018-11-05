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
        public int PV { get; set; }
        public int force { get; set; }
        public int endurance { get; set; }
        public int agilité { get; set; }



        public heroes()
            {
            niveau = 1;
            xp = 0;
            PV = 15;
            force = 10;
            endurance = 10;
            agilité = 10;
             }

         public int GetDegat()
        {
            int Degat;
            Random aleatoire = new Random();
            int entre1et9 = aleatoire.Next(10);
            Degat = force + (force+entre1et9) / 10;
            return Degat;
        }

    }
}





