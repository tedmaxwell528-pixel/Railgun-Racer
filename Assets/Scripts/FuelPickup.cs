using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupFuelSfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FuelSystem.ChangeFuel(20);
            AudioController.playSfx?.Invoke(pickupFuelSfx);
            Destroy(gameObject);
        }
    }
}