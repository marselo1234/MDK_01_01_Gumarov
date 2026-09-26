using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public class PersonInfo
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Armor {  get; set; }

        public int Level { get; set; }

        public int Glasses { get; set; }

        public int Money { get; set; }

        public float Damage { get; set; }

        public int Pierce { get; set; }

        public int ContrAttack { get; set; }

        public string Image {  get; set; }


        public PersonInfo(string Name, int Health, int Armor, int Level, int Glasses, int Money, float Damage, int Pierce, int ContrAttack, string Image)
        {
            this.Name = Name;
            this.Health = Health;
            this.Armor = Armor;
            this.Level = Level;
            this.Glasses = Glasses;
            this.Money = Money;
            this.Damage = Damage;
            this.Pierce = Pierce;
            this.ContrAttack = ContrAttack;
            this.Image = Image;
        }
    }

    
}
