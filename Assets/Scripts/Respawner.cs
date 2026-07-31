using UnityEngine;
using System.Collections.Generic;
using System;

public class Respawner : MonoBehaviour
{
    [SerializeField] GameObject toRespawn;
    [SerializeField] List<Sprite> explodeFrames;
    float respawnCooldown = 5;
    float respawnTimer;
    public Action explode = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnTimer = respawnCooldown;
        RespawnObject();
        explode += Explosion;
    }

    // Update is called once per frame
    void Update(){
        if (transform.childCount == 0){
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0){
                RespawnObject();
                respawnTimer = respawnCooldown;
            }
        }
    }

    void RespawnObject(){
        GameObject respawnedObject = Instantiate(toRespawn, transform.position, Quaternion.identity);
        respawnedObject.transform.parent = transform;
        if (transform.parent.name == "Cones" || transform.parent.name == "Tires"){
            respawnedObject.tag = "Obstacle";
            respawnedObject.layer = LayerMask.NameToLayer("Obstacle");
        }
        respawnedObject.transform.localPosition = Vector3.zero;
    }

    void Explosion(){
        StartCoroutine(Animate.CreateAnimation(explodeFrames, GetComponent<SpriteRenderer>(), 0.03f));
    }
}
