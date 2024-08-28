using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to contain and manage items within
/// </summary>
public class Inventory : MonoBehaviour
{
    #region Variables
    private Dictionary<Item, int> _items = new Dictionary<Item, int>();
    public Dictionary<Item, int> Items {  get { return _items; } }
    #endregion

    #region Methods
    public void AddItem(Item item, int amount = 1)
    {
        ModifyItemAmount(item, amount);
    }

    public void DropItem(Item item, int amount = 1)
    {
        if(!Items.ContainsKey(item)) return;
        //Add method that spawn object in the scene
        RemoveItem(item, amount );
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        if (!Items.ContainsKey(item)) return;
        ModifyItemAmount(item, -amount);
    }

    private void ModifyItemAmount(Item item, int amount)
    {
        if (!Items.ContainsKey(item))
        {
            if(amount>0) Items.Add(item, amount);
            return;
        }
        _items[item] += amount;
        if(_items[item]<0) _items.Remove(item);
    }

    /// <summary>
    /// Check if inventory has item and optionaly if it has right amount
    /// </summary>
    /// <param name="item"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool HasAItem(Item item, int amount = 1)
    {
        return Items.ContainsKey(item) && _items[item] >= amount;
    }
    #endregion
}