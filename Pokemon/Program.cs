using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {

            //Maak enkele Pokemon aan 

            Pokemon pikachu = new Pokemon();
            pikachu.Naam = "Pikachu";
            pikachu.Hp_Base = 35;
            pikachu.Attack_Base = 55;
            pikachu.Defense_Base = 40;
            pikachu.SpecialAttack_Base = 50;
            pikachu.SpecialDefence_Base = 50;
            pikachu.Speed_Base = 90;
            pikachu.ShowInfo();

            Pokemon rattata = new Pokemon();
            rattata.Naam = "Rattata";
            rattata.Hp_Base = 30;
            rattata.Attack_Base = 56;
            rattata.Defense_Base = 35;
            rattata.SpecialAttack_Base = 25;
            rattata.SpecialDefence_Base = 35;
            rattata.Speed_Base = 72;
            rattata.ShowInfo();

            Pokemon magikarp = new Pokemon();
            magikarp.Naam = "Magicarp";
            magikarp.Hp_Base = 20;
            magikarp.Attack_Base = 10;
            magikarp.Defense_Base = 55;
            magikarp.SpecialAttack_Base = 15;
            magikarp.SpecialDefence_Base = 20;
            magikarp.Speed_Base = 80;
            magikarp.ShowInfo();

            //Toon aan dat de Average, Total , HP en andere stats correct berekend worden
            Console.WriteLine($"Average Level of {pikachu.Naam}: { pikachu.Average}");
            Console.WriteLine($"Total Level of {pikachu.Naam}: { pikachu.Total}");

            //Level-up tester
            for (int i = 0; i< 55; i++)
            {
                pikachu.VerhoogLevel();
            }
            Random rnd = new Random();
            //pokemon generator
            Pokemon specialPokemon = Pokemon.GeneratorPokemon(rnd,"test");

            //battle tester
            int winner = Pokemon.Battle(pikachu, magikarp);

            //alles samen
            AllesSamen(rnd);

            Pokemon pokeDeel2 = new Pokemon() { Hp_Base = 40, Naam = "Pikachu" };

            Pokemon.Info();

        }

        private static void AllesSamen(Random rnd)
        {
            Pokemon pokemon1 = Pokemon.GeneratorPokemon(rnd, "Kinkysaurus");
            Pokemon pokemon2 = Pokemon.GeneratorPokemon(rnd, "Charmander");
            int result = Pokemon.Battle(pokemon1, pokemon2);
            int aantalLevelsGestegen = rnd.Next(1, 6);

            switch (result)
            {
                case 1:
                    for (int i = 0; i < aantalLevelsGestegen; i++)
                    {
                        pokemon1.VerhoogLevel();
                    }
                    Console.WriteLine($"Pokemon {pokemon1.Naam} won! He now leveled {aantalLevelsGestegen} levels.");
                    break;
                case 2:
                    for (int i = 0; i < aantalLevelsGestegen; i++)
                    {
                        pokemon2.VerhoogLevel();
                    }
                    Console.WriteLine($"Pokemon {pokemon2.Naam} won! He now leveled {aantalLevelsGestegen} levels.");
                    break;
                case 0:
                    Console.WriteLine("It's a draw.");
                    break;
                default:
                    Console.WriteLine("I don't know how you got here. ");
                    break;
            }
        }
    }
}
