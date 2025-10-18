using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            return;

        // Regresar la bala a la pool
        if (GameManager.Instance != null && GameManager.Instance.bulletPool != null)
        {
            GameManager.Instance.bulletPool.ReturnBullet(gameObject); // Uso de Singleton
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
            //return;

        if (GameManager.Instance != null && GameManager.Instance.bulletPool != null)
        {
            GameManager.Instance.bulletPool.ReturnBullet(gameObject);
        }
    }
}