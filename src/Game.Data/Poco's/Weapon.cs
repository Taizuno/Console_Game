/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/

//namespace Game.Data

    public class Weapon
    {
        public Weapon(){}

        public Weapon(string name, int magic, int atk)
        {
            Name = name;
            MAG = magic;
            ATK = atk;
        }
        public int ID{get; set;}
        public string Name {get; set;}
        public int MAG{ get; set;}
        public int ATK{get; set;}
    }