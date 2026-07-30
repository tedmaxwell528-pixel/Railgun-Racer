using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GunFiringMechanic : MonoBehaviour
{
    [SerializeField] Transform leftGun, rightGun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip shootSfx;
    [SerializeField] float bulletSpeed = 100;
    [SerializeField] List<Sprite> fireFrames;
    float shootCooldown = 0.25f;
    float shootTimer = 0;
    SpriteRenderer animation;
    Color active = new Color(1,1,1,1);
    Color inactive = new Color(1,1,1,0);
    bool fireFromLeft = true;

    void Awake(){
        animation = GetComponent<SpriteRenderer>();
    }

    void Start(){
        animation.color = inactive;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (shootTimer > shootCooldown){
                AudioController.playSfx.Invoke(shootSfx);
                GameObject bullet;
                if (fireFromLeft){
                    bullet = Instantiate(bulletPrefab, leftGun.position, transform.rotation);
                } else {
                    bullet = Instantiate(bulletPrefab, rightGun.position, transform.rotation);
                }
                fireFromLeft = !fireFromLeft;
                bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.up * bulletSpeed;
                shootTimer = 0;
                StartCoroutine(AnimateFiring());
            }
        }
    }

    IEnumerator AnimateFiring(){
        animation.color = active;
        foreach (Sprite s in fireFrames){
            animation.sprite = s;
            yield return new WaitForSeconds(0.02f);
        }
        animation.color = inactive;
    }
}
