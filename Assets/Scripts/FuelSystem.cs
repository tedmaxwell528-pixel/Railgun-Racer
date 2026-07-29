using TMPro;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [Header("Fuel Settings")]
    [SerializeField] static float maxFuel = 100f;
    private static float currentFuel;

    [Header("Fuel Consumption")]
    [SerializeField] float fuelConsumptionRate = 5f; // Fuel lost per second
    [SerializeField] static float speedThreshold = 0.1f; // Minimum speed needed to use fuel

    [SerializeField] TMP_Text gasText;
    private static Rigidbody2D rb;
    private static CarMovement car;

    void Awake()
    {
        car = GetComponent<CarMovement>();
    }

    void Start()
    {
        currentFuel = maxFuel;
    }

    void Update()
    {
        ChangeFuel(-fuelConsumptionRate * Time.deltaTime);
        gasText.text = $"{Mathf.Round(currentFuel)} / {maxFuel}";
    }

    /// <summary>
    /// Changes the current fuel by <i>amount</i>.
    /// <br/>If it is negative, the current fuel will be subtracted from.
    /// </summary>
    /// <param name="amount"></param>
    public static void ChangeFuel(float amount)
    {
        // Check if car is moving
        if (car.CurrentVelocityMagnitude > speedThreshold){
            currentFuel = Mathf.Clamp(currentFuel + amount, 0, maxFuel);
        }
    }

    /// <summary>
    /// Calculates the percentage of current gas remaining.
    /// </summary>
    /// <returns>A float from 0 to 1.</returns>
    public static float GetGasPercentage(){
        return currentFuel/maxFuel;
    }
}
