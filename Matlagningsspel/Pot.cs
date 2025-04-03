using System;
using System.Collections.Generic;

public class Pot{
    public List<Ingredient> Ingredients { get; } = new();
    public int Budget { get; private set; } = 500;

    public bool AddIngredient(Ingredient ingredient){
        if (Budget < ingredient.Price){
        return false;
        }
        Ingredients.Add(ingredient);
        Budget -= ingredient.Price;
        return true;
    }
}