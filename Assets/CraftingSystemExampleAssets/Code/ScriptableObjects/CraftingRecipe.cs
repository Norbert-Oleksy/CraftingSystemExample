using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "ScriptableObjects/Item/CraftingRecipe", order = 2)]
/// <summary>
/// Crafting recipe that contain information about cost and result of operatio
/// Cost: which and how many items is needed
/// Resoult: What and how much we get in result of crafting operation
/// </summary>
public class CraftingRecipe : ScriptableObject
{
    [SerializeField] private List<ItemStack> _costOfCraft;
    public List<ItemStack> CostOfCraft { get { return _costOfCraft; } set { _costOfCraft = value; } }
    [SerializeField] private List<ItemStack> _resoultOfCraft;
    public List<ItemStack> ResoultOfCraft { get { return _resoultOfCraft; } set { _resoultOfCraft = value; } }
    [SerializeField][Range(0.0f, 100.0f)] private float _successChance;
    public float SuccessChance { get { return _successChance; } set { _successChance = value; } }
}