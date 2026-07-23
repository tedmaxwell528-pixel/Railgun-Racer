using UnityEngine;

public class EnemyCarAI : MonoBehaviour
{
    public CarMovement carController;
    public Transform player;

    public float followDistance = 5f;
    public int breadcrumbDelay = 40;

    private int targetIndex;
    private int breadcrumbsCount = PlayerBreadcrumbs.breadcrumbs.Count;
    private float topSpeed = 10;

    void FixedUpdate()
    {
        if (breadcrumbsCount <= breadcrumbDelay)
            return;

        // Follow an older point in the player's path
        targetIndex = Mathf.Clamp(breadcrumbsCount - breadcrumbDelay, 0, breadcrumbsCount - 1);

        Vector2 target = PlayerBreadcrumbs.breadcrumbs[targetIndex];

        Vector2 direction = target - (Vector2)transform.position;

        // Convert direction into local space
        float angle = Vector2.SignedAngle(transform.up, direction);

        // Steering value from -1 to 1
        float totalRotation = Mathf.Clamp(angle / 45f, -1f, 1f);

        // Apply AI inputs to the car controller
        Vector2 acceleration = transform.up;
        Vector2 velocity = acceleration * Time.deltaTime;
        Vector2 driftVelocity = Vector3.ClampMagnitude(velocity, topSpeed);
        Quaternion stiffRotation = Quaternion.AngleAxis(totalRotation, Vector3.forward);
        Vector2 stiffVelocity = stiffRotation * driftVelocity; 
        velocity = Vector2.Lerp(driftVelocity, stiffVelocity, 1);
        
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}