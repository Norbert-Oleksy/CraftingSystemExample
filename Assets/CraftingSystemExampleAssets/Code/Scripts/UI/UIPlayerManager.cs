using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main Ui script to manage a ui for a player
/// </summary>
public class UIPlayerManager : MonoBehaviour
{
    #region Singleton
    public static UIPlayerManager instance;
    #endregion

    #region Fields
    [SerializeField] private GameObject inventoryMenu;
    #endregion

    #region Variables
    public bool isInventoryOpen { get { return inventoryMenu.activeSelf; } }
    #endregion

    #region Methods
    private void OpenCloseInventory()
    {
        if (inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);
        }
        else
        {
            inventoryMenu.SetActive(true);
        }
    }

    public void SubscripeToInput(InputManager inputManager)
    {
        inputManager.OnInventoryKeyInput += OpenCloseInventory;
    }
    #endregion

    #region Unity-API
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    #endregion
}