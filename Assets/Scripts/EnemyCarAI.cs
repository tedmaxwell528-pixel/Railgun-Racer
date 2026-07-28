//using UnityEngine;

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

//        // Measure speed.
//        float speed = Vector2.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
//        lastPosition = transform.position;

//        // Follow breadcrumbs.
//        targetIndex = Mathf.Clamp(
//            PlayerBreadcrumbs.breadcrumbs.Count - breadcrumbDelay,
//            0,
//            PlayerBreadcrumbs.breadcrumbs.Count - 1
//        );

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