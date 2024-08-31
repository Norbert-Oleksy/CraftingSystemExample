using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    #endregion

    #region Variables
    public bool isPlayerControlDisabled { get { return OpenCloseInventory(); } }
    private Player _referenceToPlayerObject;
    public Player ReferenceToPlayer { get { return _referenceToPlayerObject; } }
    #endregion

    #region Methods
    private bool OpenCloseInventory()
    {
        return UIPlayerManager.instance.isInventoryOpen;
    }

    public void SetPlayerReference(Player player)
    {
        _referenceToPlayerObject = player;
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