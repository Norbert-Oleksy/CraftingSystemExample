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
        SpawnObjectInFrontOfPlayer(item.Prefab).GetComponent<PickUpItem>().SetAmount(amount);
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
        if(_items[item]<=0) _items.Remove(item);
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

    /// <summary>
    /// Does the same thing as HasAItem but for list of items
    /// </summary>
    /// <param name="requiedItems"></param>
    /// <returns></returns>
    public bool HasAItems(List<ItemStack> requiedItems)
    {
        foreach (var item in requiedItems)
        {
            if (!HasAItem(item.item, item.amount)) return false;
        }
        return true;
    }

    /// <summary>
    /// Updates the player's inventory by either adding or removing items
    /// </summary>
    /// <param name="updateItems">The list of items and their amounts to add or remove</param>
    /// <param name="addItem">Determines whether to add (true) or remove (false) the items from the inventory</param>
    public void UpdateInventory(List<ItemStack> updateItems, bool addItem)
    {
        foreach (var item in updateItems)
        {
            if (addItem)
            {
                AddItem(item.item, item.amount);
            }
            else
            {
                RemoveItem(item.item, item.amount);
            }
        }
    }

    private GameObject SpawnObjectInFrontOfPlayer(GameObject prefab, float distanceInFront = 0.5f)
    {
        Vector3 spawnPosition = transform.position + transform.forward * distanceInFront;

        return Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
    #endregion
}