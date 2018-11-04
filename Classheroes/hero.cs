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

        public string name { get; set; }
        public int niveau { get; set; }
        public int xp { get; set; }
        public int PV { get; set; }

        public heroes()
            {

            niveau = 1;
            xp = 0;
            PV = 15;
             }
    }
}





