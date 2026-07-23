using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float life = 3;

    void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
