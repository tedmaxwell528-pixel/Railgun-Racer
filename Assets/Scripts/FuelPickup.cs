using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupFuelSfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FuelSystem.ChangeFuel(10);
            AudioController.playSfx.Invoke(pickupFuelSfx);
            Destroy(gameObject);
        }
    }
}