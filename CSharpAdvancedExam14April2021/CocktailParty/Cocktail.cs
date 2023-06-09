namespace CocktailParty
{
    using System.Collections.Generic;
    using System.Text;
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }

        public Dictionary<string, Ingredient> Ingredients;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel
        {
            get
            {
                int alcoholLevel = 0;

                foreach (var item in Ingredients)
                {
                    alcoholLevel += item.Value.Alcohol;
                }
                return alcoholLevel;
            }
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) 
                && Ingredients.Count < Capacity 
                && ingredient.Alcohol + CurrentAlcoholLevel <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                Ingredients.Remove(name);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int alcohol = 0;
            Ingredient ingredient = null;

            foreach (var item in Ingredients)
            {
                if (item.Value.Alcohol > alcohol)
                {
                    alcohol = item.Value.Alcohol;
                    ingredient = item.Value;
                }
            }

            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
