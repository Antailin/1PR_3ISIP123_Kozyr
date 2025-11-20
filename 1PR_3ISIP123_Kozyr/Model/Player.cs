using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1PR_3ISIP123_Kozyr.Model
{
    public class Player
    {
        public int MaxHP { get; set; } = 100;
        public int HP { get; set; } = 100;
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public bool IsFrozen { get; set; } = false;

        public Player(WeaponFactory weaponFactory, ArmorFactory armorFactory)
        {
            Weapon = weaponFactory.CreateStarterWeapon();
            Armor = armorFactory.CreateStarterArmor();
        }

        public int GetAttack() => Weapon.Attack;
        public int GetDefense() => Armor.Defense;
        public bool IsAlive() => HP > 0;
        public void Heal() => HP = MaxHP;
    }
}
