using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item/Item", order = 1)]
/// <summary>
/// Base class for all items
/// </summary>
public class Item : ScriptableObject
{
    [SerializeField] private string _itemId;
    public string ItemId { get { return _itemId; } set { _itemId = value; } }
    [SerializeField] private string _name;
    public string Name { get { return _name; } set { _name = value; } }
    [SerializeField] private string _description;
    public string Description { get { return _description; } set { _description = value; } }
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab { get { return _prefab; } set { _prefab = value; } }
}

[System.Serializable]
public struct ItemStack
{
    public Item item;
    public int amount;

    public ItemStack(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}