using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace Game.Repository.Repositories

    public class Armor_Repo
    {
        private readonly List<Armor> _armorRepo = new List<Armor>();
        private int _count;

        public bool addArmorToDB(Armor tool)
        {
            if(tool != null)
            {
            _count++;
            tool.ID = _count;
            _armorRepo.Add(tool);
            return true;
            }
            else
            {
                return false;
            }
        }
        public List<Armor> ViewAllArmor()
        {
            return _armorRepo;
        }
        public Armor ViewArmorByID(int id)
        {
            foreach(Armor a in _armorRepo)
            {
                if(a.ID == id)
                {
                    return a;
                }
            }
            return null;
        }   
    }