using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Camera cam;

    // Sensitivity
    [SerializeField] private float sensitivityX = 40f;
    [SerializeField] private float sensitivityY = 40f;

    // Rotation
    [SerializeField] private float rotationX;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void View(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;

        // up & down
        rotationX -= (mouseY * Time.deltaTime) * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -80, 80f);

        // left & right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivityX);

        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}