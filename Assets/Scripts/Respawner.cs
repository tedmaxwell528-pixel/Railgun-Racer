using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] GameObject toRespawn;
    float respawnCooldown = 5;
    float respawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnTimer = respawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0){
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0){
                GameObject respawnedbject = Instantiate(toRespawn, transform);
                respawnedbject.transform.localPosition = Vector3.zero;
                respawnTimer = respawnCooldown;
            }
        }
    }
}
