using UnityEngine;

public class EnemyCarAI : MonoBehaviour
{
    /*
    public CarController carController;
    public Transform player;

    public float followDistance = 5f;
    public int breadcrumbDelay = 40;

    private int targetIndex;

    void FixedUpdate()
    {
        if (PlayerBreadcrumbs.breadcrumbs.Count <= breadcrumbDelay)
            return;

        // Follow an older point in the player's path
        targetIndex = Mathf.Clamp(
            PlayerBreadcrumbs.breadcrumbs.Count - breadcrumbDelay,
            0,
            PlayerBreadcrumbs.breadcrumbs.Count - 1
        );

        Vector2 target = PlayerBreadcrumbs.breadcrumbs[targetIndex];

        Vector2 direction = target - (Vector2)transform.position;

        // Convert direction into local space
        float angle = Vector2.SignedAngle(transform.up, direction);

        // Steering value from -1 to 1
        float steer = Mathf.Clamp(angle / 45f, -1f, 1f);

        // Apply AI inputs to the car controller
        carController.steeringInput = steer;
        carController.accelerationInput = 1f;
    }
    */
}

