namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            GetTrainersAndPokemonInfo(trainers);
            GetFight(trainers);
            PrinTrainers(trainers);
        }

        static void PrinTrainers(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
        static void GetFight(Dictionary<string, Trainer> trainers)
        {
            string element;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Value.Badges += 1;
                    }
                    else
                    {
                        trainer.Value.Pokemons.Select(x => x.Health -= 10).ToList();
                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }
        }
        static void GetTrainersAndPokemonInfo(Dictionary<string, Trainer> trainers)
        {
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainerName, trainer);
                    continue;
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }
        }
    }
}