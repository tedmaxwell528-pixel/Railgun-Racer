using UnityEngine;

public class EnemyCarAI : MonoBehaviour
{
    public CarMovement carMovement;
    public Transform player;
    private SceneLoader sceneLoader;

    public float followDistance = 5f;
    public int breadcrumbDelay = 40;

    [Header("Stuck Recovery")]
    public float stuckSpeed = 0.5f;
    public float stuckTime = 1f;
    public float reverseTime = 1f;

    private int targetIndex;
    private int breadcrumbsCount = PlayerBreadcrumbs.breadcrumbs.Count;
    private float topSpeed = 120;
    private float accelerationAmount = 5;
    private float rotationSpeed = 120;
    private float moveSpeed = 120;

    void Start(){
        sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
    }

    private Vector2 lastPosition;
    private float stuckTimer;
    private float reverseTimer;
    private bool reversing;

    void Start()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (PlayerBreadcrumbs.breadcrumbs.Count <= breadcrumbDelay)
            return;

        // Detect if the car is stuck.
        float speed = Vector2.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;

        if (!reversing)
        {
            if (speed < stuckSpeed)
                stuckTimer += Time.fixedDeltaTime;
            else
                stuckTimer = 0f;

            if (stuckTimer >= stuckTime)
            {
                reversing = true;
                reverseTimer = reverseTime;
                stuckTimer = 0f;
            }
        }

        // Reverse to escape.
        if (reversing)
        {
            reverseTimer -= Time.fixedDeltaTime;

            carMovement.accelerationInput = -1f;

            // Turn while reversing to get away from the wall.
            carMovement.steeringInput = Random.value < 0.5f ? -1f : 1f;

            if (reverseTimer <= 0f)
                reversing = false;

            return;
        }

        // Follow the player's breadcrumbs.
        targetIndex = Mathf.Clamp(
            PlayerBreadcrumbs.breadcrumbs.Count - breadcrumbDelay,
            0,
            PlayerBreadcrumbs.breadcrumbs.Count - 1
        );

        Vector2 target = PlayerBreadcrumbs.breadcrumbs[targetIndex];
        Vector2 direction = target - (Vector2)transform.position;

        float angle = Vector2.SignedAngle(transform.up, direction);
        float steer = Mathf.Clamp(angle / 45f, -1f, 1f);

        carMovement.steeringInput = steer;
        carMovement.accelerationInput = 1f;
    }

        // Steering value from -1 to 1
        float totalRotation = Mathf.Clamp(angle/45, -1f, 1f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(0,0,totalRotation);

        // Apply AI inputs to the car controller
        Vector2 acceleration = carController.ClampMagnitude(transform.up * accelerationAmount, accelerationAmount/2, accelerationAmount);
        Vector2 velocity = acceleration * Time.deltaTime;
        Vector2 driftVelocity = Vector3.ClampMagnitude(velocity, topSpeed);
        Quaternion stiffRotation = Quaternion.AngleAxis(totalRotation, Vector3.forward);
        Vector2 stiffVelocity = stiffRotation * driftVelocity; 
        velocity = Vector2.Lerp(driftVelocity, stiffVelocity, 1) * moveSpeed;
        
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")) sceneLoader.caught.Invoke();
    }
}