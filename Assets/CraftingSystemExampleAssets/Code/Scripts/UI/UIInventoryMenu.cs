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
    #endregion

    #region Methods
    private void SetBasicConfiguration()
    {
        inventoryPage.SetActive(true);
        craftingPage.SetActive(false);
        inventory = GameManager.instance.ReferenceToPlayer.Inventory;
        UpdateItemListDisplay();
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
        Debug.Log(inventory.Items.Count);
        foreach(var itemEntry in inventory.Items)
        {
            GameObject infoMsg = Instantiate(inventoryItemDisplayPrefab);
            infoMsg.transform.SetParent(itemsContent, false);
            infoMsg.GetComponent<UIInventoryItemDisplay>().Initialization(this, new ItemStack(itemEntry.Key,itemEntry.Value));
        }
    }

    private void UpdateRecipesListDisplay()
    {

    }

    private void LoadRecipesListDisplay()
    {

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

    #region Unity-Api
    private void OnEnable()
    {
        SetBasicConfiguration();
    }
    #endregion
}