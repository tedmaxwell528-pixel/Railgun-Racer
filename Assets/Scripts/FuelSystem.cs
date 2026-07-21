using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [Header("Fuel Settings")]
    public float maxFuel = 100f;
    public float currentFuel;

    [Header("Fuel Consumption")]
    public float fuelConsumptionRate = 5f; // Fuel lost per second
    public float speedThreshold = 0.1f; // Minimum speed needed to use fuel

    private Rigidbody2D rb;

    void Start()
    {
        currentFuel = maxFuel;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UseFuel();
    }

    void UseFuel()
    {
        // Check if car is moving
        if (rb != null && rb.linearVelocity.magnitude > speedThreshold)
        {
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
        }

        // Prevent negative fuel
        if (currentFuel <= 0)
        {
            currentFuel = 0;
            StopCar();
        }
    }

    public void AddFuel(float amount)
    {
        currentFuel += amount;

        // Prevent fuel from going over max
        if (currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }

        Debug.Log("Fuel: " + currentFuel);
    }

    void StopCar()
    {
        Debug.Log("Out of fuel!");

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
