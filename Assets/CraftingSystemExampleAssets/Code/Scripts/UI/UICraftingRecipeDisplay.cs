using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICraftingRecipeDisplay : MonoBehaviour
{
    #region Fields
    [SerializeField] private TextMeshProUGUI costTextDisplay;
    [SerializeField] private TextMeshProUGUI resoulTextDisplay;
    [SerializeField] private Button craftingButton;
    #endregion

    #region Variables
    private CraftingRecipe _craftingRecipe;
    public CraftingRecipe CraftingRecipe { get { return _craftingRecipe; } }
    private UIInventoryMenu uIInventoryMenu;
    #endregion

    #region Methods
    public void Initialization(UIInventoryMenu menuReference, CraftingRecipe recipe)
    {
        uIInventoryMenu = menuReference;
        _craftingRecipe = recipe;
        costTextDisplay.text = "Cost:" + GetStringToDisplay(recipe.CostOfCraft);
        resoulTextDisplay.text = "Resoult:" + GetStringToDisplay(recipe.ResoultOfCraft);
    }

    private string GetStringToDisplay(List<ItemStack> items)
    {
        string resoult = "";
        foreach (ItemStack item in items)
        {
            resoult += "\n"+item.item.Name+"    "+item.amount;
        }
        return resoult;
    }

    public void CheckIfCanCraft(Inventory inventory)
    {
        craftingButton.interactable = inventory.HasAItems(CraftingRecipe.CostOfCraft);
    }

    public void CraftItem()
    {
        uIInventoryMenu.CraftItem(this);
    }
    #endregion
}