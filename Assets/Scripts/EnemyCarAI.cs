<<<<<<< HEAD
//using UnityEngine;
=======
using UnityEngine;
using System.Collections;
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115

//public class EnemyCarAI : MonoBehaviour
//{
//    [SerializeField] CarMovement carMovement;
//    Transform player;
//    private SceneLoader sceneLoader;

//    [Header("Path Following")]
//    [SerializeField] int breadcrumbDelay = 40;

//    [Header("Acceleration")]
//    [SerializeField] float forwardAcceleration = 1f;
//    [SerializeField] float reverseAcceleration = -1f;

//    [Header("Stuck Recovery")]
//    [SerializeField] float stuckSpeed = 0.5f;
//    [SerializeField] float stuckTime = 1f;
//    [SerializeField] float reverseDuration = 1f;

<<<<<<< HEAD
//    private int targetIndex;
//    private int breadcrumbsCount = PlayerBreadcrumbs.breadcrumbs.Count;
//    private float topSpeed = 120;
//    private float accelerationAmount = 5;
//    private float rotationSpeed = 60;
//    private float moveSpeed = 120;
//    private Vector2 lastPosition;
//    private float stuckTimer, reverseTimer, reverseSteer, steeringInput, accelerationInput;
//    private bool reversing;

//    void Start()
//    {
//        //sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
//        lastPosition = transform.position;
//        player = GameObject.FindWithTag("Player").transform;
//    }

//    void FixedUpdate()
//    {
//        if (PlayerBreadcrumbs.breadcrumbs.Count <= breadcrumbDelay)
//            return;
=======
    private int targetIndex;
    private int breadcrumbsCount = PlayerBreadcrumbs.breadcrumbs.Count;
    private float topSpeed = 120;
    private float accelerationAmount = 5;
    private float rotationSpeed = 300;
    private float moveSpeed = 120;
    private float getCloserDuration = 2;
    private float tooFar = 50;
    private Vector2 lastPosition;
    private float stuckTimer, reverseTimer, reverseSteer, steeringInput, accelerationInput, closerTimer;
    private bool reversing;

    void Start()
    {
        //sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
        lastPosition = transform.position;
        player = GameObject.FindWithTag("Player").transform;
        closerTimer = getCloserDuration;
    }

    void FixedUpdate()
    {
        breadcrumbsCount = PlayerBreadcrumbs.breadcrumbs.Count;
        if (breadcrumbsCount <= breadcrumbDelay) return;
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115

//        // Measure speed.
//        float speed = Vector2.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
//        lastPosition = transform.position;

<<<<<<< HEAD
//        // Follow breadcrumbs.
//        targetIndex = Mathf.Clamp(
//            PlayerBreadcrumbs.breadcrumbs.Count - breadcrumbDelay,
//            0,
//            PlayerBreadcrumbs.breadcrumbs.Count - 1
//        );
=======
        // Follow breadcrumbs.
        targetIndex = Mathf.Clamp(
            breadcrumbsCount - breadcrumbDelay,
            0,
            breadcrumbsCount - 1
        );
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115

//        Vector2 target = PlayerBreadcrumbs.breadcrumbs[targetIndex];
//        Vector2 direction = target - (Vector2)transform.position;

//        float angle = Vector2.SignedAngle(transform.up, direction);
//        float steer = Mathf.Clamp(angle / 45f, -1f, 1f);
//        steeringInput = steer;
//        accelerationInput = forwardAcceleration;

//        // Check if stuck.
//        if (!reversing)
//        {
//            if (speed < stuckSpeed)
//            {
//                stuckTimer += Time.fixedDeltaTime;

//                if (stuckTimer >= stuckTime)
//                {
//                    reversing = true;
//                    reverseTimer = reverseDuration;
//                    reverseSteer = Random.value < 0.5f ? -1f : 1f;
//                    stuckTimer = 0f;
//                }
//            }
//            else
//            {
//                stuckTimer = 0f;
//            }
//        } else { //Reverse mode
//            reverseTimer -= Time.fixedDeltaTime;

//            accelerationInput = reverseAcceleration;
//            steeringInput = reverseSteer;

<<<<<<< HEAD
//            if (reverseTimer <= 0f)
//            {
//                reversing = false;
//            }
//        }

//        // Steering value from -1 to 1
//        float totalRotation = steer * rotationSpeed * Time.deltaTime;
//        transform.Rotate(0,0,totalRotation);

//        // Apply AI inputs to the car controller
//        Vector2 acceleration = carMovement.ClampMagnitude(transform.up * accelerationAmount * accelerationInput, accelerationAmount/2, accelerationAmount);
//        Vector2 velocity = acceleration * Time.deltaTime;
//        Vector2 driftVelocity = Vector3.ClampMagnitude(velocity, topSpeed);
//        Quaternion stiffRotation = Quaternion.AngleAxis(totalRotation, Vector3.forward);
//        Vector2 stiffVelocity = stiffRotation * driftVelocity; 
//        velocity = Vector2.Lerp(driftVelocity, stiffVelocity, 1) * moveSpeed;
        
//        transform.position += (Vector3)velocity * Time.deltaTime;
//    }

//    void OnCollisionEnter2D(Collision2D collision){
//        //if (collision.gameObject.CompareTag("Player")) sceneLoader.caught.Invoke();
//    }
//}
=======
            if (reverseTimer <= 0f)
            {
                reversing = false;
                reverseTimer = reverseDuration;
            }
        }

        // Steering value from -1 to 1
        float totalRotation = steeringInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0,0,totalRotation);

        // Apply AI inputs to the car controller
        Vector2 acceleration = carMovement.ClampMagnitude(transform.up * accelerationAmount * accelerationInput, accelerationAmount/2, accelerationAmount);
        Vector2 velocity = acceleration * Time.deltaTime;
        Vector2 driftVelocity = Vector3.ClampMagnitude(velocity, topSpeed);
        Quaternion stiffRotation = Quaternion.AngleAxis(totalRotation, Vector3.forward);
        velocity = stiffRotation * driftVelocity * moveSpeed;
        
        transform.position += (Vector3)velocity * Time.deltaTime;

        closerTimer -= Time.deltaTime;
        if (closerTimer <= 0){
            TargetKill();
            closerTimer = getCloserDuration;
        }

        if (Vector2.Distance(player.position, transform.position) >= tooFar){
            transform.position = PlayerBreadcrumbs.breadcrumbs[breadcrumbsCount-50];
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        //if (collision.gameObject.CompareTag("Player")) sceneLoader.caught.Invoke();
    }

    /// <summary>
    /// If the current gas percentage is above 95%, the police car will lengthen 
    /// the gap between it and the player.
    /// <br/>If it is between 80% to 90%, the police car will shorten the gap
    /// between it and the player.
    /// <br/>Under 80%, the police car will quickly shorten the gap.
    /// <br/>If the gap is short enough, the time it takes for the cop car to get closer
    /// will get shorter.
    /// </summary>
    void TargetKill(){
        float quicken = 20;
        if (breadcrumbDelay > 5){
            float pct = GasController.GetGasPercentage();
            if (pct >= 0.95f){
                breadcrumbDelay = Mathf.Clamp(breadcrumbDelay++, 0, 40);
            } else if (pct >= 0.8f && pct <= 0.9f){
                breadcrumbDelay--;
            } else {
                breadcrumbDelay = Mathf.Clamp(breadcrumbDelay - 2, 0, 40);
            }
        }
        if (breadcrumbDelay <= quicken){
            getCloserDuration = Mathf.Lerp(1,5,breadcrumbDelay/quicken);
        } else {
            getCloserDuration = 5;
        }
    }
}
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115
