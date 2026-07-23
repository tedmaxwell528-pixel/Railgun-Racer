using System.Collections.Generic;
using UnityEngine;

public class PlayerBreadcrumbs : MonoBehaviour
{
    // Shared list of positions that enemy cars can follow.
    public static List<Vector2> breadcrumbs = new List<Vector2>();

    [Header("Breadcrumb Settings")]
    [SerializeField] float spacing = 0.5f;
    [SerializeField] int maxBreadcrumbs = 1000;

    private Vector2 lastPosition;

    void Start()
    {
        // Clear old breadcrumbs if the scene is restarted.
        breadcrumbs.Clear();

        lastPosition = transform.position;
        breadcrumbs.Add(lastPosition);
    }

    void Update()
    {
        if (Vector2.Distance(lastPosition, transform.position) >= spacing)
        {
            lastPosition = transform.position;
            breadcrumbs.Add(lastPosition);

            if (breadcrumbs.Count > maxBreadcrumbs)
            {
                breadcrumbs.RemoveAt(0);
            }
        }
    }
}