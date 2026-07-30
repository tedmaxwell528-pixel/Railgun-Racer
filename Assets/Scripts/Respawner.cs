using UnityEngine;
using System.Collections.Generic;

public class Respawner : MonoBehaviour
{
    [SerializeField] GameObject toRespawn;
    [SerializeField] List<Sprite> explodeFrames;
    float respawnCooldown = 5;
    float respawnTimer;
    bool explodeOnce = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnTimer = respawnCooldown;
        RespawnObject();
    }

    // Update is called once per frame
    void Update(){
        if (transform.childCount == 0){
            if (explodeOnce){
                StartCoroutine(Animate.CreateAnimation(explodeFrames, GetComponent<SpriteRenderer>(), 0.03f));
                explodeOnce = false;
            }
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0){
                RespawnObject();
                respawnTimer = respawnCooldown;
                explodeOnce = true;
            }
        }
    }

    void RespawnObject(){
        GameObject respawnedObject = Instantiate(toRespawn, transform.position, Quaternion.identity);
        respawnedObject.transform.parent = transform;
        if (transform.parent.name == "Cones"){
            respawnedObject.tag = "Obstacle";
            respawnedObject.layer = LayerMask.NameToLayer("Obstacle");
        }
        respawnedObject.transform.localPosition = Vector3.zero;
    }
}
