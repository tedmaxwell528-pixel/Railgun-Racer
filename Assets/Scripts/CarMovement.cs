using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class CarMovement : MonoBehaviour
{
   private Vector2 acceleration;
   private Vector2 velocity;
   [SerializeField] private float topSpeed = 10;
   [SerializeField] private float accelerationAmount;
   [SerializeField] private float rotationSpeed = 10;
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


       acceleration = Vector3.ClampMagnitude(transform.up * accelerationAmount * gasPercentage, accelerationAmount);
       velocity += acceleration * Time.deltaTime;
       velocity = Vector3.ClampMagnitude(velocity, topSpeed);
       transform.position += (Vector3)velocity * Time.deltaTime;
   }
}




