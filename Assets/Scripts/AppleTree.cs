using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("inscribed")]

    public GameObject applePrefab;
    public GameObject bombPrefab;

    public float speed = 1f;

    public float edgeDist = 10f;

    public float flipChance = 0.02f;

    public float appleSpawnRate = 1f;

    public float appleDropDelay = 2f;

    public float bombSpawnRate = 1f;
    public float bombSpawnRateChance = 0.02f;

    public float bombDropDelay = 2f;

    void Start()
    {
        // Initalize object and begin dropping apples
        Invoke(nameof(DropApple), 2f);
        Invoke(nameof(DropBomb), 4f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), appleDropDelay);
    }

    void DropBomb()
    {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = transform.position;
        Invoke(nameof(DropBomb), bombDropDelay);
    }

    void Update()
    {
        // Make tree move
        Vector3 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        transform.position = newPos;

        // Possibly flip direction
        if (newPos.x < -edgeDist)
        {
            speed = Mathf.Abs(speed);
        }
        else if (newPos.x > edgeDist)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    void FixedUpdate()
    {
        if (Random.value < flipChance)
        {
            speed *= -1;
        }
        //  else if (Random.value < bombSpawnRateChance)
        //  {
        //      GameObject bomb = Instantiate<GameObject>(bombPrefab);
        //      bomb.transform.position = transform.position;
        //  }
    }
}
