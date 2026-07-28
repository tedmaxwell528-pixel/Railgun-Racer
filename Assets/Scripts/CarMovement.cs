using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    private Vector2 acceleration = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    public Vector2 CurrentVelocity => velocity;

    [Header("Car Stats")]
    [SerializeField] private float topSpeed;
    [SerializeField] private float accelerationAmount;
    [SerializeField] private float rotationSpeed;
    [Tooltip("Float from 0 to 1.")]
    [SerializeField] private float steeringStiffness;
    
    public Action<float> updateCurrentGas = null;
    private float gasPercentage;
    Camera mainCam;
    float cameraOffset = 3;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Make camera track car
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, mainCam.transform.position.z) + transform.up * cameraOffset;

        //Turn car based on inputs
        float totalRotation = GetTurnInput() * rotationSpeed * Time.deltaTime;
        transform.Rotate(0,0,totalRotation);

        //Accelerate car
        gasPercentage = FuelSystem.GetGasPercentage();
        float adjustedAccelerationAmt = accelerationAmount/2 + accelerationAmount/2 * gasPercentage;
        acceleration = ClampMagnitude(transform.up * adjustedAccelerationAmt, accelerationAmount/2, accelerationAmount);
        velocity += acceleration * Time.fixedDeltaTime;

        //Restrict top speed based on gas percentage
        float adjustedSpeed = Mathf.Clamp(topSpeed * gasPercentage, topSpeed*0.2f, topSpeed);

        //Lessen drift of the car based on steeringStiffness
        Vector2 driftVelocity = Vector3.ClampMagnitude(velocity, adjustedSpeed);
        Quaternion stiffRotation = Quaternion.AngleAxis(totalRotation, Vector3.forward);
        Vector2 stiffVelocity = stiffRotation * driftVelocity; 
        velocity = Vector2.Lerp(driftVelocity, stiffVelocity, steeringStiffness);
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Clamps the magnitude of <i>vector</i> to between <i>minMag</i> and <i>maxMag</i>.
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="minMag"></param>
    /// <param name="maxMag"></param>
    /// <returns>The clamped vector</returns>
    public Vector3 ClampMagnitude(Vector3 vector, float minMag, float maxMag){
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

    /// <summary>
    /// Turns the car based on the user's input.
    /// </summary>
    /// <returns>0 for straight, 1 for left, -1 for right</returns>
    int GetTurnInput(){
        int turnInput = 0;
        if (Keyboard.current.aKey.isPressed){
            turnInput = 1;
        } else if (Keyboard.current.dKey.isPressed){
            turnInput = -1;
        }
        return turnInput;
    }
}