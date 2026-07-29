using UnityEngine;

public class GunFiringMechanic : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip shootSfx;
    [SerializeField] float bulletSpeed = 100;
    float shootCooldown = 0.25f;
    float shootTimer = 0;

    void Update()
    {
        shootTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (shootTimer > shootCooldown){
                AudioController.playSfx.Invoke(shootSfx);
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;
                shootTimer = 0;
            }
        }
    }
}
