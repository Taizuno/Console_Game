using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace Game.Repository.Repositories

    public class Weapon_Repo
    {
        private readonly List<Weapon> _weaponRepo = new List<Weapon>();
        private int _count;

        public bool addWeaponToDB(Weapon tool)
        {
            if(tool != null)
            {
            _count++;
            tool.ID = _count;
            _weaponRepo.Add(tool);
            return true;
            }
            else
            {
                return false;
            }
        }
        public List<Weapon> ViewAllWeapons()
        {
            return _weaponRepo;
        }
        public Weapon ViewWeaponByID(int id)
        {
            foreach(Weapon w in _weaponRepo)
            {
                if(w.ID == id)
                {
                    return w;
                }
            }
            return null;
        }
    }