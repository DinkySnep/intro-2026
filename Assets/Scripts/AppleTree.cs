using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("inscribed")]

    public GameObject applePrefab;

    public float speed = 1f;

    public float edgeDist = 10f;

    public float flipChance = 0.02f;

    public float appleSpawnRate = 1f;

    public float appleDropDelay = 2f;

    void Start()
    {
        // Initalize object and begin dropping apples
        Invoke(nameof(DropApple), 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), appleDropDelay);
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
    }
}
