using System.Collections.Generic;
using UnityEngine;

public class PlayerBreadcrumbs : MonoBehaviour
{
    public static List<Vector2> breadcrumbs = new List<Vector2>();

    [Header("Breadcrumb Settings")]
    [SerializeField] float spacing = 0.5f;
    [SerializeField] int maxBreadcrumbs = 1000;
    [SerializeField] GameObject breadcrumbPrefab;
    [SerializeField] Transform breadcrumbHolder;

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
            VisualizeBreadcrumbs();

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

    void VisualizeBreadcrumbs(){
        Instantiate(breadcrumbPrefab, lastPosition, Quaternion.identity, breadcrumbHolder);
    }
}