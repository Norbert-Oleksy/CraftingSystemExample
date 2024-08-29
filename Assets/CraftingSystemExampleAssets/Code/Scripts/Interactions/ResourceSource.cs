using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the logic for interactive resource objects in the world. Give player a item after interaction
/// </summary>
public class ResourceSource : MonoBehaviour, IInteractable
{
    #region Variables
    [SerializeField] private ItemStack _item;
    public ItemStack Item { get { return _item; } }
    #endregion

    #region Methods
    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();
        if (inventory == null) return;
        inventory.AddItem(_item.item, _item.amount);
    }
    #endregion
}
