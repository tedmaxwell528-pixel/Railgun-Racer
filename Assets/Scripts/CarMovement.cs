using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class CarMovement : MonoBehaviour
{
    private Vector2 acceleration;
    private Vector2 velocity;
    [SerializeField] private float topSpeed;
    [SerializeField] private float accelerationAmount;
    [SerializeField] private float rotationSpeed;
    public Action<float> updateCurrentGas = null;
    private GasController gasController;
    private float gasPercentage;
    Camera mainCam;
  
   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gasController = GetComponent<GasController>();
        mainCam = Camera.main;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, mainCam.transform.position.z);
        gasPercentage = gasController.GasPercentage();
        float turnInput = 0;
        if (Keyboard.current.aKey.isPressed){
            turnInput = 1;
        } else if (Keyboard.current.dKey.isPressed){
            turnInput = -1;
        }
        float totalRotation = turnInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0,0,totalRotation);

        acceleration = ClampMagnitude(transform.up * accelerationAmount * gasPercentage, accelerationAmount/2, accelerationAmount);
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, topSpeed);
        Debug.Log(acceleration.magnitude);
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    Vector3 ClampMagnitude(Vector3 vector, float minMag, float maxMag){
        Vector3 clampedVector = vector.normalized;
        if (vector.magnitude < minMag){
            clampedVector *= minMag;
        } else if (vector.magnitude > maxMag){
            clampedVector *= maxMag;
        } else {
            clampedVector = vector;
        }
        return clampedVector;
    }
}




