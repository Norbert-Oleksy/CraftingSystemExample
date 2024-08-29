using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class responsible for managing the crafting process
/// </summary>
public class CraftingSystem : MonoBehaviour
{
    #region Singleton
    public static CraftingSystem instance;
    #endregion

    #region Fields
    [Header("Crafting Recipes")]
    [SerializeField] private ListCraftingRecipes _craftingDataBase;
    public ListCraftingRecipes CraftingDataBase { get { return _craftingDataBase; } }
    [Space(10)]
    [Header("Events")]
    [SerializeField] private UnityEvent OnSuccesCrafting; // Do when item was successfully created
    [SerializeField] private UnityEvent OnFailedCrafting; // Do when failed to craft a item
    [SerializeField] private UnityEvent OnDoneCrafting; // Always do after crafting operation
    #endregion

    #region Methods
    /// <summary>
    /// Executes the crafting process by steps.
    /// </summary>
    /// <param name="inventory">The inventory that function operate on</param>
    /// <param name="recipe">Executed crafting recipe</param>
    public void CraftingProcess(Inventory inventory, CraftingRecipe recipe)
    {
        if(inventory.HasAItems(recipe.CostOfCraft)) return;

        inventory.UpdateInventory(recipe.CostOfCraft,false);

        if (IsSuccess(recipe.SuccessChance))
        {
            inventory.UpdateInventory(recipe.ResoultOfCraft, true);
            SuccessfullyCraftingOperation();
        }
        else
        {
            FailedCraftingOperation();
        }
        OnDoneCrafting?.Invoke();
    }

    private bool IsSuccess(float chance)
    {
        return Random.Range(0f, 100f) <= chance;
    }    
    
    private void SuccessfullyCraftingOperation()
    {
        OnSuccesCrafting?.Invoke();
    }

    private void FailedCraftingOperation()
    {
        OnFailedCrafting?.Invoke();
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