/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/

//namespace src

    public class Armor
    {
        public Armor(){}
        public Armor(string name, int def, int res)
        {
            Name = name;
            DEF = def;
            RES = res;
        }   
            public int ID{get; set;}
            public string Name{get; set;}
            public int DEF{get; set;}
            public int RES{get; set;}
    }