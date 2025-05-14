using System;
using System.Collections.Generic;

public class Game
{
    private static Random random = new();
    private static List<string> ingredientNames = new()
    {
        "Carrots", "Onion", "Garlic", "Glass Noodles", "Sriracha", "Chicken", "Duck", "Bay Leaf",
        "Salt", "Pepper", "Paprika", "Cheese", "Milk", "Pasta", "Beef"
    };

    public void Start()
    {
        
        while (true)
        {
            Console.WriteLine("Welcome to the ultimate cooking show! Your job is to make a dish our judges will simply rave over!");
            Console.WriteLine("Get your knives and cutting board ready, chef!");

            Pot pot = new();
            Console.WriteLine("Choose ingredients for your dish! Here's a list:");
            foreach (var name in ingredientNames){
        
                Console.WriteLine("- " + name + " *");
            }

            bool done = false;
            while (!done)
            {
                Console.Write("Enter your ingredient name to get cookin'! (or type 'done' to finish!): ");
                string input = Console.ReadLine();
                
                if (input == null){
                    Console.WriteLine("Please enter a valid ingredient!");
                    continue;
                }

                if (input == "done"){
                    done = true;
                    continue;
                }

                Ingredient ingredientToAdd = new Ingredient(input);
                bool added = false;
                if (pot.AddIngredient(ingredientToAdd)){
                    added = true;
                }

                if (!added){
                    Console.WriteLine("Oops, not enough budget!");
                }

            }

            int totalscore = 0;
            foreach (var Judge in judges){
                int score = Judge.EvaluateDish(pot);
                totalscore += score;
            }

            int averagescore = 0;

            Console.Write("Play another round? (y/n): ");
            string playAgain = Console.ReadLine();
            if (playAgain != "yes" && playAgain != "y"){
                break;
            }
        }
    }
}