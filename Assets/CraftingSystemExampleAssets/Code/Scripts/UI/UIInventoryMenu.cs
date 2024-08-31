using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryMenu : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject inventoryPage;
    [SerializeField] private GameObject craftingPage;

    [SerializeField] private Transform itemsContent;
    [SerializeField] private Transform recipesContent;
    [Header("Prefabs")]
    [SerializeField] private GameObject inventoryItemDisplayPrefab;
    [SerializeField] private GameObject craftingRecipeDisplayPrefab;
    #endregion

    #region Variables
    private Inventory inventory;
    private List<UICraftingRecipeDisplay> listRecipeDisplays = new List<UICraftingRecipeDisplay>();
    #endregion

    #region Methods
    private void SetBasicConfiguration()
    {
        inventoryPage.SetActive(true);
        craftingPage.SetActive(false);
        inventory = GameManager.instance.ReferenceToPlayer.Inventory;
        UpdateItemListDisplay();
        LoadRecipesListDisplay();
    }

    public void ChangePage(bool isInvenotryPage)
    {
        if(isInvenotryPage)
        {
            inventoryPage.SetActive(true);
            craftingPage.SetActive(false);
        }else
        {
            inventoryPage.SetActive(false);
            craftingPage.SetActive(true);
        }
    }

    private void UpdateItemListDisplay()
    {
        UIInventoryItemDisplay[] list = itemsContent.GetComponentsInChildren<UIInventoryItemDisplay>();
        if(list.Length > 0 )
        {
            foreach( UIInventoryItemDisplay toRemove in list )
            {
                RemoveItemDisplay(toRemove);
            }
        }
        SpawnItemsToListDisplay();
       
    }

    private void SpawnItemsToListDisplay()
    {
        foreach(var itemEntry in inventory.Items)
        {
            GameObject itemDisplay = Instantiate(inventoryItemDisplayPrefab);
            itemDisplay.transform.SetParent(itemsContent, false);
            itemDisplay.GetComponent<UIInventoryItemDisplay>().Initialization(this, new ItemStack(itemEntry.Key,itemEntry.Value));
        }
    }

    public void UpdateRecipesListDisplay()
    {
        foreach (var recipe in listRecipeDisplays)
        {
            recipe.CheckIfCanCraft(inventory);
        }
    }

    private void LoadRecipesListDisplay()
    {
        UICraftingRecipeDisplay[] list = recipesContent.GetComponentsInChildren<UICraftingRecipeDisplay>();
        if (list.Length > 0)
        {
            foreach (UICraftingRecipeDisplay toRemove in list)
            {
                Destroy(toRemove.gameObject);
            }
        }
        listRecipeDisplays.Clear();
        foreach (var recipe in CraftingSystem.instance.CraftingDataBase)
        {
            GameObject recipeDisplay = Instantiate(craftingRecipeDisplayPrefab);
            recipeDisplay.transform.SetParent(recipesContent, false);
            UICraftingRecipeDisplay uiRecipeDisplay = recipeDisplay.GetComponent<UICraftingRecipeDisplay>();
            uiRecipeDisplay.Initialization(this, recipe);
            listRecipeDisplays.Add(uiRecipeDisplay);
        }
    }
    #endregion

    #region Methods Inventory
    public void DropItem(UIInventoryItemDisplay dropItem)
    {
        int howMuch = 1;
        inventory.DropItem(dropItem.Item.item, howMuch);
        dropItem.UpdateItemAmmount(dropItem.Item.amount - howMuch);
    }

    public void RemoveItemDisplay(UIInventoryItemDisplay itemDisplay)
    {
        Destroy(itemDisplay.gameObject);
    }
    #endregion

    #region Methods Crafting
    public void CraftItem(UICraftingRecipeDisplay craftingRecipeDisplay)
    {
        CraftingSystem.instance.CraftingProcess(inventory,craftingRecipeDisplay.CraftingRecipe);
        UpdateRecipesListDisplay();
        UpdateItemListDisplay();
    }

    #endregion

    #region Unity-Api
    private void OnEnable()
    {
        SetBasicConfiguration();
    }
    #endregion
}