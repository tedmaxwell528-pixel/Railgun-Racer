using System.Collections.Generic;
using UnityEngine;

public class PlayerBreadcrumbs : MonoBehaviour
{
    public static List<Vector2> breadcrumbs = new List<Vector2>();

    [Header("Breadcrumb Settings")]
    public float spacing = 1f;
    public int maxBreadcrumbs = 500;

    private Vector2 lastPosition;

    void Start()
    {
        breadcrumbs.Clear();

        lastPosition = transform.position;
        breadcrumbs.Add(lastPosition);
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(lastPosition, transform.position);

        if (distance >= spacing)
        {
            lastPosition = transform.position;

            breadcrumbs.Add(lastPosition);

            // Keep list from getting too large
            if (breadcrumbs.Count > maxBreadcrumbs)
            {
                breadcrumbs.RemoveAt(0);
            }
        }
    }


    // Used by enemy AI to get a point on the player's path
    public static Vector2 GetBreadcrumb(int delay, int lookAhead)
    {
        if (breadcrumbs.Count == 0)
            return Vector2.zero;

        int index = breadcrumbs.Count - delay + lookAhead;

        index = Mathf.Clamp(
            index,
            0,
            breadcrumbs.Count - 1
        );

        return breadcrumbs[index];
    }


    // Optional debug visualization
    void OnDrawGizmos()
    {
        if (breadcrumbs == null || breadcrumbs.Count < 2)
            return;

        Gizmos.color = Color.yellow;

        for (int i = 1; i < breadcrumbs.Count; i++)
        {
            Gizmos.DrawLine(
                breadcrumbs[i - 1],
                breadcrumbs[i]
            );
        }
    }
}