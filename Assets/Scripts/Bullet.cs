using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
