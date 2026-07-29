using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float life = 3;
    [SerializeField] AudioClip hitSfx;

    void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
            PointsManager.AlterScore(100);
            AudioController.playSfx.Invoke(hitSfx);
            Destroy(gameObject);
        }
    }
}
