using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Serialize Variables
    [Header("Variables")]
    [SerializeField] private float rotationSensitivity;
    #endregion

    #region Variables
    private InputManager inputManager;
    private Vector2 curentRotation;
    #endregion

    #region Methods
    private void RotateACamera(Vector3 rotation)
    {
        if (GameManager.instance.isPlayerControlDisabled) return;
        curentRotation.y -= rotation.y * rotationSensitivity;
        curentRotation.y = Mathf.Clamp(curentRotation.y, -90.0f, 90.0f);
        transform.localEulerAngles = new Vector3(curentRotation.y,0f,0f);
    }
    #endregion

    #region Unity-API
    private void Awake()
    {
        inputManager = GetComponentInParent<InputManager>();
        inputManager.OnMouseInput += RotateACamera;
    }
    #endregion
}