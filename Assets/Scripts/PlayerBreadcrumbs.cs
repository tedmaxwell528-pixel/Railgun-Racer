//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerBreadcrumbs : MonoBehaviour
//{
//    public static List<Vector2> breadcrumbs = new List<Vector2>();

<<<<<<< HEAD
//    [Header("Breadcrumb Settings")]
//    public float spacing = 1f;
//    public int maxBreadcrumbs = 500;
//    [SerializeField] float spacing = 0.5f;
//    //[SerializeField] int maxBreadcrumbs = 1000;
//    [SerializeField] GameObject breadcrumbPrefab;
//    [SerializeField] Transform breadcrumbHolder;

//    private Vector2 lastPosition;
=======
    [Header("Breadcrumb Settings")]
    [SerializeField] float spacing = 0.5f;
    [SerializeField] int maxBreadcrumbs = 1000;
    [SerializeField] GameObject breadcrumbPrefab;
    [SerializeField] Transform breadcrumbHolder;

    private Vector2 lastPosition;
    int currentIndex = 0;
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115

//    void Start()
//    {
//        breadcrumbs.Clear();

//        lastPosition = transform.position;
//        breadcrumbs.Add(lastPosition);
//    }

//    void FixedUpdate()
//    {
//        float distance = Vector2.Distance(lastPosition, transform.position);

//        if (distance >= spacing)
//        {
//            lastPosition = transform.position;

//            breadcrumbs.Add(lastPosition);
//            VisualizeBreadcrumbs();

//            // Keep list from getting too large
//            if (breadcrumbs.Count > maxBreadcrumbs)
//            {
//                breadcrumbs.RemoveAt(0);
//            }
//        }
//    }

    public static int GetBreadcrumbIndex(int delay){
        if (breadcrumbs.Count == 0) return 0;

<<<<<<< HEAD
//    // Used by enemy AI to get a point on the player's path
//    public static Vector2 GetBreadcrumb(int delay, int lookAhead)
//    {
//        if (breadcrumbs.Count == 0)
//            return Vector2.zero;

//        int index = breadcrumbs.Count - delay + lookAhead;
=======
        int index = breadcrumbs.Count - delay;
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115

//        index = Mathf.Clamp(
//            index,
//            0,
//            breadcrumbs.Count - 1
//        );

<<<<<<< HEAD
//        return breadcrumbs[index];
//    }
=======
        return index;
    }

    // Used by enemy AI to get a point on the player's path
    public static Vector2 GetBreadcrumb(int delay){
        return breadcrumbs[GetBreadcrumbIndex(delay)];
    }
>>>>>>> 9532085b96330854012c3c81f116e0bb9ce7f115


//    // Optional debug visualization
//    void OnDrawGizmos()
//    {
//        if (breadcrumbs == null || breadcrumbs.Count < 2)
//            return;

//        Gizmos.color = Color.yellow;

//        for (int i = 1; i < breadcrumbs.Count; i++)
//        {
//            Gizmos.DrawLine(
//                breadcrumbs[i - 1],
//                breadcrumbs[i]
//            );
//        }
//    }

//    void VisualizeBreadcrumbs(){
//        Instantiate(breadcrumbPrefab, lastPosition, Quaternion.identity, breadcrumbHolder);
//    }
//