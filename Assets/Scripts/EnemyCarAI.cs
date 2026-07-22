using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyCarAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public int followDistance = 30;

    public Vector2 carForward = Vector2.up;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        if (PlayerBreadcrumbs.breadcrumbs.Count <= followDistance)
            return;

        int targetIndex = PlayerBreadcrumbs.breadcrumbs.Count - followDistance;

        Vector2 target = PlayerBreadcrumbs.breadcrumbs[targetIndex];

        Vector2 direction = target - rb.position;

        if (direction.magnitude < 0.1f)
            return;

        direction.Normalize();

        // Calculate rotation
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // If your car faces UP, subtract 90 degrees
        targetAngle -= 90f;

        float angle = Mathf.MoveTowardsAngle(
            rb.rotation,
            targetAngle,
            turnSpeed * Time.fixedDeltaTime
        );

        rb.MoveRotation(angle);

        // Move forward
        rb.linearVelocity = transform.up * moveSpeed;
    }
}
