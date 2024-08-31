using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;

public class UIInventoryItemDisplay : MonoBehaviour
{
    #region Fields
    [SerializeField] private TextMeshProUGUI nameTextDisplay;
    [SerializeField] private TextMeshProUGUI amountTextDisplay;
    #endregion

    #region Variables
    private ItemStack _item;
    public ItemStack Item {  get { return _item; } }
    private UIInventoryMenu uIInventoryMenu;
    #endregion

    #region Methods
    public void Initialization(UIInventoryMenu menuReference,ItemStack item)
    {
        uIInventoryMenu = menuReference;
        _item = item;
        nameTextDisplay.text = item.item.name;
        amountTextDisplay.text = item.amount.ToString();
    }

    public void UpdateItemAmmount(int ammount)
    {
        if(ammount <= 0)
        {
            uIInventoryMenu.RemoveItemDisplay(this);
            return;
        }
        _item.amount = ammount;
        amountTextDisplay.text = ammount.ToString();
    }

    public void DropItem()
    {
        uIInventoryMenu.DropItem(this);
    }
    #endregion
}