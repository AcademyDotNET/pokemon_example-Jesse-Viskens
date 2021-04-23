using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Pokemon
    {
        private int hp_Base, attack_Base, defense_Base, specialAttack_Base, specialDefense_Base, speed_Base = 0;
        private int level = 1;
        //full props
        public int Hp_Base
        {
            get
            {
                return hp_Base;
            }
            set
            {
                hp_Base = value;
            }
        }
        public int Attack_Base
        {
            get { return attack_Base; }
            set { attack_Base = value; }
        }
        public int Defense_Base
        {
            get { return defense_Base; }
            set { defense_Base = value; }
        }
        public int SpecialAttack_Base
        {
            get
            {
                return specialAttack_Base;
            }
            set
            {
                specialAttack_Base = value;
            }
        }
        public int SpecialDefence_Base
        {
            get { return specialDefense_Base; }
            set { specialDefense_Base = value; }
        }
        public int Speed_Base
        {
            get { return speed_Base; }
            set { speed_Base = value; }
        }
        public int Level
        {
            get { return level; }
            private set { level = value; }
        }
        //auto props
        public string Naam { get; set; }
        public int Nummer { get; set; }
        public string Type { get; set; }
        //Statistics
        public double Average
        {
            get
            {
                return (Hp_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefence_Base + speed_Base) / 6;
            }
        }
        public double Total
        {
            get
            {
                return Hp_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefence_Base + speed_Base;
            }
        }
        //level based stats
        public int Hp_Full
        {
            get
            {
                return (((Hp_Base + 50) * Level) / 50) + 10;
            }
        }
        public int Attack_Full
        {
            get { return ((Attack_Base * Level) / 50) + 5; }
        }
        public int Defense_Full
        {
            get { return ((Defense_Base * Level) / 50) + 5; }
        }
        public int SpecialAttack_Full
        {
            get { return ((SpecialAttack_Base * Level) / 50) + 5; }
        }
        public int SpecialDefense_Full
        {
            get { return ((SpecialDefence_Base * Level) / 50) + 5; }
        }
        public int Speed_Full
        {
            get { return ((Speed_Base * Level) / 50) + 5; }
        }
        public int Average_Full
        {
            get
            {
                return (Hp_Full + Attack_Full + Defense_Full + SpecialAttack_Full + SpecialDefense_Full + Speed_Full) / 6;
            }
        }

        //methods
        public void VerhoogLevel()
        {
            Level++;
        }

        //Part 2: the poketester
        public void ShowInfo()
        {
            Console.WriteLine($"" +
                $"{Naam} (level {Level})\n" +
                $"\t* Health = {Hp_Base}\n" +
                $"\t* Attack = {Attack_Base}\n" +
                $"\t* Defence = {Defense_Base}\n" +
                $"\t* Special Attack = {SpecialAttack_Base}\n" +
                $"\t* Special Defence = {SpecialDefence_Base}\n" +
                $"\t* Speed = {Speed_Base}\n" +
                $"Full stats:\n" +
                $"\t* Health = {Hp_Full}\n" +
                $"\t* Attack = {Attack_Full}\n" +
                $"\t* Defence = {Defense_Full}\n" +
                $"\t* Special Attack = {SpecialAttack_Full}\n" +
                $"\t* Special Defence = {SpecialDefense_Full}\n" +
                $"\t* Speed = {Speed_Full}\n"
                );
        }
    }
}
