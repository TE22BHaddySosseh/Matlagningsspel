using System;
using System.Collections.Generic;

public class Judge
{
    public string Name { get; }
    public string PreferredIngredient { get; }
    public static int Count { get; internal set; }

    public Judge(string name, string preferredIngredient)
    {
        Name = name;
        PreferredIngredient = preferredIngredient;
    }

    public int EvaluateDish(Pot pot)
    {
        int score = pot.Ingredients.Count * 10;
        
        bool hasPreferred = false;
        foreach (var ingredient in pot.Ingredients)
        {
            if (ingredient.Name == PreferredIngredient)
            {
                hasPreferred = true;
                break;
            }
        }

        if (hasPreferred)
        {
            score += 20;
        }
        else
        {
            score -= 10;
        }


        int finalScore = score;

        if (finalScore > 100)
        {
            finalScore = 100;
        }

        while (finalScore < 0)
        {
            finalScore += 1;
        }

        return finalScore;

        
    }
}