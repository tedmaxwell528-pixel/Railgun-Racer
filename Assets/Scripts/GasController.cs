using UnityEngine;


public class GasController : MonoBehaviour
{
   float maxGas = 100;
   float currentGas;
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
           currentGas = Mathf.Clamp(currentGas - 0.01f, 0, maxGas);
           useGasTimer = useGasCooldown;
       }
   }


   public float GasPercentage(){
       return currentGas/maxGas;
   }
}




