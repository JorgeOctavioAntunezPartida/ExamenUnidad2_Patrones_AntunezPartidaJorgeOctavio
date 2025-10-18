using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Stack<GameObject> bulletPool = new Stack<GameObject>();

    public int stackCount = 10;

    public int Count
    {
        get { return bulletPool.Count; }
    }

    void Start()
    {
        for (int i = 0; i < stackCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = transform;
            AccommodateBullets(bullet);
            bulletPool.Push(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullut = bulletPool.Pop();
            bullut.SetActive(true);
            return bullut;
        }
        else
        {
            return null;
        }
    }

    public void AccommodateBullets(GameObject bullet)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        Vector3 basePos = GameManager.Instance.objectPoolMenu.transform.position;

        int index = bulletPool.Count;
        float offsetX = 0.8f;

        bullet.transform.position = basePos + Vector3.right * offsetX * index;
    }

    public void ReturnBullet(GameObject bullet)
    {
        AccommodateBullets(bullet);
        bulletPool.Push(bullet);
    }
}