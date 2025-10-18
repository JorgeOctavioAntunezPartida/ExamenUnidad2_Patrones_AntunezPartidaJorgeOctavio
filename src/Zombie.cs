using UnityEngine;

public class Zombie : MonoBehaviour
{
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            return;

        // Regresar la bala a la pool
        if (GameManager.Instance != null && GameManager.Instance.zombiePool != null)
        {
            GameManager.Instance.zombiePool.ReturnZombie(gameObject); // Uso de Singleton
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
            return;

        if (GameManager.Instance != null && GameManager.Instance.zombiePool != null)
        {
            GameManager.Instance.zombiePool.ReturnZombie(gameObject); // Uso de Singleton
        }
    }
}