using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    #region Serialize Variables
    [Header("Variables")]
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interacRange;
    #endregion

    #region Variables
    private InputManager inputManager;
    private IInteractable interactObj;
    #endregion

    #region Methods
    private void InteractWithTheObject()
    {
        if(interactObj == null) return;
        interactObj.Interact(this.gameObject);
    }

    private void CastInteractionRay()
    {
        Ray ray = new Ray(interactorSource.position, interactorSource.up);
        if (Physics.Raycast(ray,out RaycastHit hitInfo, interacRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable terget))
            {
                interactObj = terget;
            }
        }
        else
        {
            interactObj = null;
        }
    }
    #endregion

    #region Unity-API
    private void Awake()
    {
        inputManager = GetComponentInParent<InputManager>();
        inputManager.OnInteractionKeyInput += InteractWithTheObject;
    }

    private void Update()
    {
        CastInteractionRay();
    }
    #endregion
}