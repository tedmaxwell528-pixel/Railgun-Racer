using UnityEngine;


public class GasController : MonoBehaviour
{
    static float maxGas = 10;
    static float currentGas;
    float useGasCooldown = 0.25f;
    float useGasTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGas = maxGas;
    }


    // Update is called once per frame
    void Update()
    {
        useGasTimer += Time.deltaTime;
        if (useGasTimer > useGasCooldown){
            currentGas = Mathf.Clamp(currentGas - 0.01f, 0.01f, maxGas);
            useGasTimer = 0;
        }
    }

    /// <summary>
    /// Calculates the percentage of current gas remaining.
    /// </summary>
    /// <returns>A float from 0 to 1.</returns>
    public static float GetGasPercentage(){
        return currentGas/maxGas;
    }

    public static void AddGas(){
        currentGas++;
    }
}




