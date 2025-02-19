using System;
using System.Collections.Generic;

public class Ingredient
{
    public string Name { get; }
    public int Price { get; } = 30;

    public Ingredient(string name) => Name = name;
}