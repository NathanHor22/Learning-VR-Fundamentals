using UnityEngine;

public class Pistol : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 5f;

    public AudioClip Clip;
    private AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        source.PlayOneShot(Clip);

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
            Debug.DrawRay(firePoint.position, firePoint.forward * 2f, Color.red, 2f);
        }

        Destroy(bullet, bulletLifetime);
    }
}
