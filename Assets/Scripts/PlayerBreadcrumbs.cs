using System.Collections.Generic;
using UnityEngine;

public class PlayerBreadcrumbs : MonoBehaviour
{
    // Shared list of positions that enemy cars can follow.
    public static List<Vector2> breadcrumbs = new List<Vector2>();

    [Header("Breadcrumb Settings")]
    [SerializeField] float spacing = 0.5f;
    [SerializeField] int maxBreadcrumbs = 1000;
    [SerializeField] GameObject breadcrumbPrefab;
    [SerializeField] Transform breadcrumbHolder;

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
        //Debug.Log(PrintBreadcrumbs(10));
        if (Vector2.Distance(lastPosition, transform.position) >= spacing)
        {
            lastPosition = transform.position;
            breadcrumbs.Add(lastPosition);
            VisualizeBreadcrumbs();

            if (breadcrumbs.Count > maxBreadcrumbs)
            {
                breadcrumbs.RemoveAt(0);
            }
        }
    }

    string PrintBreadcrumbs(int amt){
        string allBreadcrumbs = "";
        if (breadcrumbs.Count >= amt){
            for (int i = 0; i < amt; i++){
                allBreadcrumbs += breadcrumbs[i];
            }
        }
        return allBreadcrumbs;
    }

    void VisualizeBreadcrumbs(){
        Instantiate(breadcrumbPrefab, lastPosition, Quaternion.identity, breadcrumbHolder);
    }
}