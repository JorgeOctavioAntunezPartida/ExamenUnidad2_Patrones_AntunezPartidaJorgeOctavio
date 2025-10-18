using System.Collections.Generic;
using UnityEngine;

public class ZombiePool : MonoBehaviour
{
    public GameObject zombiePrefab;

    public Stack<GameObject> zombiePool = new Stack<GameObject>();

    public int stackCount = 10;

    public int Count
    {
        get { return zombiePool.Count; }
    }

    void Start()
    {
        for (int i = 0; i < stackCount; i++)
        {
            GameObject zombie = Instantiate(zombiePrefab);
            zombie.transform.parent = transform;
            zombie.SetActive(false);
            zombiePool.Push(zombie);
        }
    }

    public GameObject GetZombie()
    {
        if (zombiePool.Count > 0)
        {
            GameObject zombie = zombiePool.Pop();
            zombie.SetActive(true);
            return zombie;
        }
        else
        {
            return null;
        }
    }

    public void ReturnZombie(GameObject zombie)
    {
        zombie.SetActive(false);
        zombiePool.Push(zombie);
    }
}