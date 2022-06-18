using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace Game.UI

    public class Game_UI
    {
        private readonly Armor_Repo _aRepo = new Armor_Repo();
        private readonly Weapon_Repo _wRepo = new Weapon_Repo();
        private readonly Character_Repo _cRepo = new Character_Repo();
        public void Run()
        {
            SeedData();

            RunApp();
        }

        private void SeedData()
        {
            Armor Plate = new Armor("Plate", 40, 10);
            Armor Robe = new Armor("Robe", 10, 40);
            Armor Leather = new Armor("Leather",20, 30);
            Armor Mail = new Armor("Mail",30,20);
            _aRepo.addArmorToDB(Plate);
            _aRepo.addArmorToDB(Robe);
            _aRepo.addArmorToDB(Leather);
            _aRepo.addArmorToDB(Mail);
            Weapon Short = new Weapon("Shortsword",20,60);
            Weapon Staff = new Weapon("Staff",60,20);
            Weapon Rod = new Weapon("Rod",50,30);
            Weapon Dagger = new Weapon("Dagger",30,50);
            _wRepo.addWeaponToDB(Short);
            _wRepo.addWeaponToDB(Staff);
            _wRepo.addWeaponToDB(Rod);
            _wRepo.addWeaponToDB(Dagger);
            Character Player = new Character();
            Character NPC = new Character();
        }

        public void RunApp()
        {
            
        }
    }
