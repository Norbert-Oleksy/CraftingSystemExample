using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] private CharacterController characterController;
    #endregion

    #region Serialize Variables
    [Header("Variables")]
    [SerializeField] private float speed;
    [SerializeField] private float moveSmoothness;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private float gravityStrenght;
    #endregion

    #region Variables
    private InputManager inputManager;
    private Vector3 curentMoveVelocity;
    private Vector3 moveDampVelocity;
    private Vector2 curentRotation;
    #endregion

    #region Methods
    private void MoveAPlayer(Vector3 movement)
    {
        Vector3 moveVectore = transform.TransformDirection(movement);

        curentMoveVelocity = Vector3.SmoothDamp(
            curentMoveVelocity,
            moveVectore * speed,
            ref moveDampVelocity,
            moveSmoothness
            );
        curentMoveVelocity.y -= gravityStrenght * Time.deltaTime;
        characterController.Move(curentMoveVelocity * Time.deltaTime);
    }

    private void RotateAPlayer(Vector3 rotation)
    {
        curentRotation.x += rotation.x * rotationSensitivity;
        transform.eulerAngles = new Vector3(0f, curentRotation.x, 0f);
    }
    #endregion

    #region Unity-API
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        inputManager.OnMove += MoveAPlayer;
        inputManager.OnMouseInput += RotateAPlayer;
    }
    #endregion
}