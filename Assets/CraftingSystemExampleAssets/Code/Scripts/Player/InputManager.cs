using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Fields
    [Header("Controls")]
    [SerializeField] private KeyCode moveUpKey;
    [SerializeField] private KeyCode moveDownKey;
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private KeyCode inventoryKey;
    #endregion

    #region Actions
    public Action<Vector3> OnMove;
    public Action<Vector3> OnMouseInput;
    public Action OnInteractionKeyInput;
    public Action OnInventoryKeyInput;
    #endregion

    #region
    private Vector3 movement;
    #endregion
    private void MovementInput()
    {
        movement = Vector3.zero;
        if (Input.GetKey(moveUpKey))
        { movement.z = 1;
        }else if(Input.GetKey(moveDownKey))
        { movement.z = -1; }

        if (Input.GetKey(moveRightKey))
        { movement.x = 1;
        } else if (Input.GetKey(moveLeftKey))
        { movement.x = -1; }

        OnMove?.Invoke(movement);
    }

    private void MouseInput()
    {
        Vector3 mouseInput = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);
        OnMouseInput?.Invoke(mouseInput);
    }
    #region Methods

    #endregion

    #region Unity-API
    void Update()
    {
        MovementInput();
        MouseInput();

        if (Input.GetKeyDown(interactionKey)) OnInteractionKeyInput?.Invoke();
        if (Input.GetKeyDown(inventoryKey)) OnInventoryKeyInput?.Invoke();
    }
    #endregion
}