using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Pokemon
    {
        public Pokemon()
        {
            Hp_Base = 10;
            Attack_Base = 10;
            Defense_Base = 10;
            SpecialAttack_Base = 10;
            SpecialDefence_Base = 10;
            speed_Base = 10;
        }
        public Pokemon(int hp, int att, int def, int spAtt, int spDef, int spd)
        {
            Hp_Base = hp;
            Attack_Base = att;
            Defense_Base = def;
            specialAttack_Base = spAtt;
            specialDefense_Base = spDef;
            speed_Base = spd;
        }

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

        //deel2
        public static int AmountOfTimesIncreased { get; private set; }
        public static int AmountOfBattles { get; private set; }
        public static int AmountOfDraws { get; set; }
        public static int AmountOfRandomPokemonCreated { get; set; }
        public static bool NoLevelingAllowed { get; set; } = false;

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
            if(NoLevelingAllowed == true)
            {
                AmountOfTimesIncreased++;
                Level++;
            }
            else
            {
                Console.WriteLine("This pokemon cannot level right now!");
            }

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
        public static Pokemon GeneratorPokemon(Random rnd, string name)
        {
            AmountOfRandomPokemonCreated++;
            Pokemon randomPokemon = new Pokemon();

            randomPokemon.Hp_Base = rnd.Next(1, 251);
            randomPokemon.Attack_Base = rnd.Next(1, 251);
            randomPokemon.Defense_Base = rnd.Next(1, 251);
            randomPokemon.SpecialAttack_Base = rnd.Next(1, 251);
            randomPokemon.SpecialDefence_Base = rnd.Next(1, 251);
            randomPokemon.Speed_Base = rnd.Next(1, 251);

            return randomPokemon;
        }
        //Maak een methode met volgende signatuur: static Pokemon GeneratorPokemon(). 
        //Plaats deze methode niet in je Pokémon-klasse, maar in Program.cs.
        public static int Battle(Pokemon poke1, Pokemon poke2)
        {
            if (poke1 == null && poke2 == null)
            {
                //draw
                AmountOfDraws++;
                return 0;
            }
            else if (poke1 == null && poke2 != null)
            {
                //poke2 wint
                return 2;
            }
            else if (poke1 != null && poke2 == null)
            {
                //poke1 wint
                return 1;
            }
            else
            {
                //let them fight! i know, kinda boring but hey :)
                AmountOfBattles++;
                int winner = poke1.Average_Full - poke2.Average_Full;
                if (winner < 0)
                {
                    return 2;
                }
                else if (winner > 0)
                {
                    return 1;
                }
                else
                {
                    AmountOfDraws++;
                    return 0;
                }
            }
        }

        public static void Info()
        {
            Console.WriteLine(
                $"Extra Information: \n" +
                $"\t Aantal keer verhoogd: {AmountOfTimesIncreased}\n" +
                $"\t Aantal keer gevochten: {AmountOfBattles}\n" +
                $"\t Aantal keer gelijk: {AmountOfDraws}\n" +
                $"\t Aantal keer random aangemaakt: {AmountOfRandomPokemonCreated}\n");
        }
    }
}
