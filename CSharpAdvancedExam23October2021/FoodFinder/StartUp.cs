namespace FoodFinder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));

            HashSet<char> pear = new HashSet<char> { 'p', 'e', 'a', 'r'};
            HashSet<char> flour = new HashSet<char> { 'f', 'l', 'o', 'u', 'r'};
            HashSet<char> pork = new HashSet<char> { 'p', 'o', 'r', 'k'};
            HashSet<char> olive = new HashSet<char> { 'o', 'l', 'i', 'v', 'e'};

            while (consonants.Count > 0)
            {
                char currentVolew = vowels.Dequeue();
                vowels.Enqueue(currentVolew);
                char currentConsonant = consonants.Pop();

                RemoveLetters(pear, currentVolew, currentConsonant);
                RemoveLetters(flour, currentVolew, currentConsonant);
                RemoveLetters(pork, currentVolew, currentConsonant);
                RemoveLetters(olive, currentVolew, currentConsonant);

            }

            List<string> totalFood = new List<string>();

            if (pear.Count == 0)
            {
                totalFood.Add("pear");
            }

            if (flour.Count == 0)
            {
                totalFood.Add("flour");
            }

            if (pork.Count == 0)
            {
                totalFood.Add("pork");
            }

            if (olive.Count == 0)
            {
                totalFood.Add("olive");
            }

            Console.WriteLine($"Words found: {totalFood.Count}");

            foreach (var food in totalFood)
            {
                Console.WriteLine(food);
            }
        }

        static void RemoveLetters(HashSet<char> food, char vowel, char consonant)
        {
            if (food.Contains(vowel))
            {
                food.Remove(vowel);
            }

            if (food.Contains(consonant))
            {
                food.Remove(consonant);
            }
        }
    }
}