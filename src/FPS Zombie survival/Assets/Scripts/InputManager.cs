using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.WalkingActions walking;
    private PlayerMovement movement;
    private PlayerView fpView;
    [SerializeField]private GunManager gun;

    void Awake() {
        playerInput =  new PlayerInput();
        walking = playerInput.Walking;
        movement = GetComponent<PlayerMovement>();
        fpView = GetComponent<PlayerView>();
        walking.Shoot.performed += _ => gun.Shoot();

    }

    void FixedUpdate() {
        movement.Move(walking.Move.ReadValue<Vector2>());
    }

    void LateUpdate() {
        fpView.View(walking.View.ReadValue<Vector2>());
    }

    private void OnEnable() {
        walking.Enable();
    }

    private void OnDisable() {
        walking.Disable();
    }
}