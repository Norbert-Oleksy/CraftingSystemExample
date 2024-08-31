using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

/// <summary>
/// Main script of player entity. To contain and manage other player related scripts
/// </summary>
public class Player : MonoBehaviour
{
    #region Fields
    [SerializeField] private Inventory _inventory;
    public Inventory Inventory { get { return _inventory; } }
    [SerializeField] private InputManager _inputManager;
    public InputManager InputManager { get { return _inputManager; } }
    #endregion

    #region Methods
    private IEnumerator TryToSetReference()
    {
        yield return new WaitUntil(() => GameManager.instance != null);
        GameManager.instance.SetPlayerReference(this);
        yield return new WaitUntil(() => UIPlayerManager.instance != null);
        UIPlayerManager.instance.SubscripeToInput(_inputManager);
        yield return null;
    }
    #endregion
    #region Unity-API
    private void Awake()
    {
        if (_inventory == null) _inventory = GetComponent<Inventory>();
        if (_inputManager == null) _inputManager = GetComponent<InputManager>();
        StartCoroutine(TryToSetReference());
    }
    #endregion
}