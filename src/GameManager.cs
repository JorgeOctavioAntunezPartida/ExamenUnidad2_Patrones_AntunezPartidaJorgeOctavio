using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform Playe;

    public Transform objectPoolMenu;
    public Transform zombieSpawner;

    public ZombiePool zombiePool;
    public BulletPool bulletPool;

    public float bulletSpeed = 10.0f;
    public float zombieZpeed = 3.5f;

    public InputActionAsset InputAction;
    private InputAction jumpAction;

    public bool canShot = true;
    public float Shotcooldown = 1;
    public float spawnCooldown = 3;

    public int cantidad = 0;

    void Awake()
    {
        jumpAction = InputAction.FindActionMap("Player").FindAction("Jump");

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        Debug.Log("Juego Empezo");
        StartCoroutine(Spawner());
    }

    void Update()
    {
        if (jumpAction.IsPressed() && canShot)
        {
            StartCoroutine(CanShot());
            Shoot();
        }

        cantidad = bulletPool.Count;
    }

    void SummonZombie()
    {
        GameObject zombie = zombiePool.GetZombie();
        if (zombie == null)
        {
            return;
        }

        float randomY = Random.Range(-2.5f, 2.5f);
        Vector3 spawnPosition = new Vector3(
            zombieSpawner.position.x,
            zombieSpawner.position.y + randomY,
            zombieSpawner.position.z
        );

        zombie.transform.position = spawnPosition;

        Rigidbody2D rb = zombie.GetComponent<Rigidbody2D>();
        rb.linearVelocityX = -zombieZpeed;
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();
        if (bullet == null)
        {
            Debug.LogWarning("No hay balas disponibles para disparar.");
            return;
        }

        bullet.transform.position = Playe.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocityX = bulletSpeed;
    }

    IEnumerator CanShot()
    {
        canShot = false;
        yield return new WaitForSeconds(Shotcooldown);
        canShot = true;
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Debug.Log("Genere Zombie");
            SummonZombie();
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}