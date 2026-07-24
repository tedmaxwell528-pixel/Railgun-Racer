using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyCarAI : MonoBehaviour
{
    public CarMovement carMovement;
    public Transform player;

    public float followDistance = 5f;
    public int breadcrumbDelay = 40;

    [Header("Stuck Recovery")]
    public float stuckSpeed = 0.5f;
    public float stuckTime = 1f;
    public float reverseTime = 1f;

    private int targetIndex;

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
}