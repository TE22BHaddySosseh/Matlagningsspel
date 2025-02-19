using System;
using System.Collections.Generic;

public class Pot{
    public List<Ingredient> Ingredients { get; } = new();
    public int Budget { get; private set; } = 500;
    private int discount;

    public bool AddIngredient(Ingredient ingredient){
        if (Budget < ingredient.Price){
        return false;
        }
        Ingredients.Add(ingredient);
        Budget -= ingredient.Price;
        if (Budget < 500){

        }
        return true;
    }
}