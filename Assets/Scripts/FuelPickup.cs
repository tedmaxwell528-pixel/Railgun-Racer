using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FuelSystem.ChangeFuel(10);
            Destroy(gameObject);
        }
    }
}