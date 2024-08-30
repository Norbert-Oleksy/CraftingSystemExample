using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryMenu : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject inventoryPage;
    [SerializeField] private GameObject craftingPage;

    [SerializeField] private Transform itemsContent;
    [SerializeField] private Transform recipesContent;

    private List<Button> inventoryItems;
    private List<Button> craftingRecipes;
    private void Awake()
    {
        inputManager.OnInventoryKeyInput += OpenCloseInventory;
    }

    private void OpenCloseInventory()
    {
        if(inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);
            inputManager.inventoryOpen = false;
        }
        else
        {
            inputManager.inventoryOpen = true;
            SetBasicConfiguration();
        }
    }

    private void SetBasicConfiguration()
    {
        inventoryMenu.SetActive(true);
        inventoryPage.SetActive(true);
        craftingPage.SetActive(false);
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
}
