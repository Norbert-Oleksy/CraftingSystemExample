using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListCraftingRecipes", menuName = "ScriptableObjects/Item/ListCraftingRecipes", order = 3)]
/// <summary>
/// A list of crafting recipes
/// </summary>
public class ListCraftingRecipes : ScriptableObject
{
    [SerializeField] private List<CraftingRecipe> _recipes;
    public List<CraftingRecipe> Recipes { get { return _recipes; } }
}