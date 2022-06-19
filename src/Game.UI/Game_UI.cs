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
        System.Random random = new System.Random();
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
        }

        public void RunApp()
        {
            bool Running = true;
            Character NPC = new Character();
            NPC.Name = "Opponent";
            Character Player = new Character();
            Player.HP = 200;
            NameCharacter();
            while(Running)
            {
            NPC.HP = 200;
            System.Console.WriteLine("=== Welcome! To The Coloseum!=== \n");
            DisplayOpponent(NPC);
            WeaponSelect(Player);
            ArmorSelect(Player);
            System.Console.WriteLine("LET THE MATCH BEGIN!!!\n");
            PressAnyKey();
            while(NPC.HP > 0 && Player.HP > 0)
            {
                DisplayHP(NPC, Player);
                System.Console.WriteLine
                    ("                 === Choose an Action!=== \n"
                    +"\n"
                    +"\n"
                    +"\n"
                    +"\n"
                    +"\n"
                    +"'['Z. Attack']' '['X. Magic']' '['C. Guard']' '['V. Charge']'\n");

                string input = Console.ReadLine().ToUpper();
                switch(input)
                {
                    case "Z":
                        Attack(Player,NPC);
                        NPC.Guard = false;
                        Player.Charge = false;
                        break;
                    case "X":
                        Magic(Player,NPC);
                        NPC.Guard = false;
                        Player.Charge = false;
                        break;
                    case "C":
                        Guard(Player);
                        break;
                    case "V":
                        Charge(Player);
                        break;
                }
                if(NPC.HP < 0)
                {
                    break;
                }
                else
                {
                int act = random.Next(1,4);
                switch(act)
                {
                    case 1:
                        Attack(NPC,Player);
                        NPC.Charge = false;
                        Player.Guard = false;
                        break;
                    case 2:
                        Magic(NPC,Player);
                        NPC.Charge = false;
                        Player.Guard = false;
                        break;
                    case 3:
                        Guard(NPC);
                        break;
                    case 4:
                        Charge(NPC);
                        break;
                }
                }
            }
            Console.Clear();
            if(NPC.HP > 0)
            {
                System.Console.WriteLine
                ("       YOU LOSE! \n"
                +"Better luck next time");
            }
            else
            {
                System.Console.WriteLine
                ("YOU WIN!");
            }
            bool invalid = true;
            while(invalid)
            {
            System.Console.WriteLine("Play again? y/n \n");
            string answer = Console.ReadLine();
            if(answer == "n")
            {
                Running = CloseApp();
                invalid = false;
            }
            else if(answer != "y")
            {
                System.Console.WriteLine("INVALID ENTRY");
                PressAnyKey();
                Console.Clear();
            }
            else
            {
                invalid = false;
            }
            }
        }
    }
    public void NameCharacter()
    {
        bool real = false;
        while(real != true)
        {
        System.Console.WriteLine("Please enter your Character's name. \n");
        string MyName = Console.ReadLine();
        if(MyName != null)
        {
            real = true;
        }
        else
        {
            System.Console.WriteLine("INVALID ENTRY");
        }
        PressAnyKey();
        Console.Clear();
        }
    }
    public void DisplayOpponent(Character npc)
    {
        Console.Clear();
        int wmax = _wRepo.WeaponCount();
        int amax = _aRepo.ArmorCount();
        int min = 1; 
        int rand_W = random.Next(min, wmax);
        int rand_A = random.Next(min, amax);
        npc.armor = _aRepo.ViewArmorByID(rand_A);
        npc.weapon = _wRepo.ViewWeaponByID(rand_W);
        System.Console.WriteLine
        ("                                   ===NPC STATS=== \n"
        +$"ATK:{npc.weapon.ATK} MAG: {npc.weapon.MAG} DEF: {npc.armor.DEF} RES: {npc.armor.RES} \n"
        );
        PressAnyKey();
    }
    public void WeaponSelect(Character player)
    {
        Console.Clear();
        var weapons = _wRepo.ViewAllWeapons();
        bool check = false;
        while(check != true)
        {
        foreach(Weapon w in weapons)
        {
            System.Console.WriteLine($"ID: {w.ID} {w.Name} ATK: {w.ATK} Mag: {w.MAG} \n");
        }
        System.Console.WriteLine("Enter ID of Weapon you wish to use");
        string name = Console.ReadLine();
        int id = int.Parse(name);
        if(_wRepo.ViewWeaponByID(id) != null)
        {
            player.weapon = _wRepo.ViewWeaponByID(id);
            check = true;
        }
        else
        {
            System.Console.WriteLine("INVALID ENTRY");
            PressAnyKey();
        }
        }
    }
    public void ArmorSelect(Character player)
    {
        Console.Clear();
        var armor = _aRepo.ViewAllArmor();
        bool check = false;
        while(check != true)
        {
        foreach(Armor a in armor)
        {
            System.Console.WriteLine($"ID: {a.ID} {a.Name} DEF: {a.DEF} RES: {a.RES} \n");
        }
        System.Console.WriteLine("Enter ID of Weapon you wish to use");
        string name = Console.ReadLine();
        int id = int.Parse(name);
        player.armor = _aRepo.ViewArmorByID(id);
        if(player.armor != null)
        {
            check = true;
        }
        else
        {
            System.Console.WriteLine("INVALID ENTRY");
            PressAnyKey();
        }
        }
    }
    public void DisplayHP(Character opp, Character player)
    {
        Console.Clear();
        System.Console.WriteLine($" Opponent HP:{opp.HP}          HP:{player.HP}");
    }
    public void Attack(Character Attacker, Character reciever)
    {
        Console.Clear();
        int atk = Attacker.weapon.ATK;
        int def = reciever.armor.DEF;
        if(Attacker.Charge)
        {
            atk *= 2;
        }
        if(reciever.Guard)
        {
            def *= 2;
        }
        int damage = atk - def; 
        reciever.HP -= damage;
        System.Console.WriteLine($"{Attacker.Name} delt {damage} damage.\n");
        PressAnyKey();
    }
    public void Magic(Character Attacker, Character reciever)
    {
        Console.Clear();
        int atk = Attacker.weapon.MAG;
        int def = reciever.armor.RES;
        if(Attacker.Charge)
        {
            atk *= 2;
        }
        if(reciever.Guard)
        {
            def *= 2;
        }
        int damage = atk - def; 
        reciever.HP -= damage;
        System.Console.WriteLine($"{Attacker.Name} delt {damage} damage. \n");
        PressAnyKey();
    }
    public void Charge(Character Char)
    {
        Console.Clear();
        Char.Charge = true;
        System.Console.WriteLine($"{Char.Name} is charging, next attack is now doubled \n");
        PressAnyKey();
    }
    public void Guard(Character Char)
    {
        Console.Clear();
        Char.Guard = true;
        System.Console.WriteLine($"{Char.Name} is Guarding, next attack your defence is doubled! \n");
        PressAnyKey();
    }
    private bool CloseApp()
        {
            Console.Clear();
            System.Console.WriteLine("Come Play Again!");
            PressAnyKey();
            return false;
        }
    private void PressAnyKey()
        {
            System.Console.WriteLine("Press ANY KEY to continue...");
            Console.ReadKey();
        }
    }
