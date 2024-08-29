using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    #region Variables
    [SerializeField]private ItemStack _item;
    public ItemStack Item {  get { return _item; } }
    #endregion

    #region Methods
    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();
        if (inventory == null) return;
        inventory.AddItem(_item.item,_item.amount);
        Destroy(this.gameObject);
    }

    public void SetAmount(int amount)
    {
        _item.amount = amount;
    }
    #endregion
}
