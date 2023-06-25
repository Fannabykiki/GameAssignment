using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private SpawnObject spawnObject;
    // Start is called before the first frame update

    void Awake()
    {
        spawnObject = FindObjectOfType<SpawnObject>(); // Tìm đối tượng SpawnObject trong scene
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (spawnObject != null)
        {
            speed = spawnObject.IncreaseSpeed();
        }
    }

    void Update()
    {
        rb.velocity = Vector2.left * speed;
        Debug.Log(speed);
    }
}
