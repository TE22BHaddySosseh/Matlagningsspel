using System;
using System.Collections.Generic;

Game game = new();

game.Start();

public class Game
{
    private static Random random = new();
    private static List<string> ingredientNames = new()
    {
        "Carrots", "Onion", "Garlic", "Glass Noodles", "Sriracha", "Chicken", "Duck", "Bay Leaf",
        "Salt", "Pepper", "Paprika", "Cheese", "Milk", "Pasta", "Beef"
    };
    private static List<string> JudgesNames = new(){
        "Ramsey","Judy","Nicholas","Emery","Shalomm","Galinda","Logan","StunnaGrl"
    };

    public void Start()
    {

        while (true)
        {
            Console.WriteLine("Welcome to the ultimate cooking show! Your job is to make a dish our judges will simply rave over!");
            Console.WriteLine("Get your knives and cutting board ready, chef!");
            Console.WriteLine("Choose ingredients for your dish! Here's a list:");
            Console.WriteLine("Carrots, Onion, Garlic, Glass Noodles, Sriracha, Chicken, Duck, Bay Leaf");
            Console.WriteLine("Salt, Pepper, Paprika, Cheese, Milk, Pasta and Beef!");

            Pot pot = new();
            List<Judge> judges = GenerateJudges(3);
            foreach (var name in ingredientNames)
            {

                Console.WriteLine("- " + name);
            }

            bool done = false;
            while (!done)
            {
                Console.Write("Enter your ingredient name to get cookin'! (or type 'done' to finish!): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid ingredient!");
                    continue;
                }

                if (input == "done")
                {
                    done = true;
                    continue;
                }

                Ingredient ingredientToAdd = new Ingredient(input);
                bool added = false;
                if (pot.AddIngredient(ingredientToAdd))
                {
                    added = true;
                }


                if (!added)
                {
                    Console.WriteLine("Oops, not enough budget!");
                }

            }

            int totalscore = 0;
            Console.WriteLine("Judge score!:");
            foreach (var Judge in judges)
            {
                int score = Judge.EvaluateDish(pot);
                Console.WriteLine(Judge.Name + " likes " + Judge.PreferredIngredient + " and gave your dish " + score);
                totalscore += score;
            }

            int averagescore = totalscore / judges.Count;
            Console.WriteLine("Your average score is: " + averagescore);

            Console.Write("Play another round? (y/n): ");
            string playAgain = Console.ReadLine();
            if (playAgain != "yes" && playAgain != "y")
            {
                break;
            }
        }
    }

    public List<Judge> GenerateJudges(int Count)
    {
        List<Judge> judges = new();
        List<string> copynames = new(JudgesNames);
        for (int i = 1; 1 <= Count; i++)
        {
            string name = $"Judge {i}";
            string preferredIngredient = ingredientNames[random.Next(ingredientNames.Count)];
            judges.Add(new Judge(name, preferredIngredient));
        }
        return judges;
    }
}