using UnityEngine;

public class GunFiringMechanic : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 100;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
