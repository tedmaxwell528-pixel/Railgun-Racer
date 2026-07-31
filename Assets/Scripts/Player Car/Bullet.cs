using System.Collections.Generic;
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
            collision.gameObject.transform.parent.GetComponent<Respawner>().explode?.Invoke();
            Destroy(collision.gameObject);
            ScoreManager.Score += 50;
            AudioController.playSfx?.Invoke(hitSfx);
            Destroy(gameObject);
        }
    }
}
