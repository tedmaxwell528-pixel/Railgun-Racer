using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyCarAI : MonoBehaviour
{
    public CarMovement carMovement;
    public Transform player;

    [Header("Path Following")]
    public int breadcrumbDelay = 40;

    [Header("Acceleration")]
    public float forwardAcceleration = 1f;
    public float reverseAcceleration = -1f;

    [Header("Stuck Recovery")]
    public float stuckSpeed = 0.5f;
    public float stuckTime = 1f;
    public float reverseDuration = 1f;

    private int targetIndex;

    private Vector2 lastPosition;
    private float stuckTimer;
    private float reverseTimer;
    private bool reversing;
    private float reverseSteer;

    void Start()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (PlayerBreadcrumbs.breadcrumbs.Count <= breadcrumbDelay)
            return;

        // Measure speed.
        float speed = Vector2.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;

        // Check if stuck.
        if (!reversing)
        {
            if (speed < stuckSpeed)
            {
                stuckTimer += Time.fixedDeltaTime;

                if (stuckTimer >= stuckTime)
                {
                    reversing = true;
                    reverseTimer = reverseDuration;
                    reverseSteer = Random.value < 0.5f ? -1f : 1f;
                    stuckTimer = 0f;
                }
            }
            else
            {
                stuckTimer = 0f;
            }
        }

        // Reverse mode.
        if (reversing)
        {
            reverseTimer -= Time.fixedDeltaTime;

            carMovement.accelerationInput = reverseAcceleration;
            carMovement.steeringInput = reverseSteer;

            if (reverseTimer <= 0f)
            {
                reversing = false;
            }

            return;
        }

        // Follow breadcrumbs.
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
        carMovement.accelerationInput = forwardAcceleration;
    }
}