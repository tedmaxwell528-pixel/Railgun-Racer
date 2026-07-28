using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float life = 3;

    void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
            GameObject.FindFirstObjectByType<PointsManager>().AlterScore(100);
            Destroy(gameObject);
        }
    }
}
