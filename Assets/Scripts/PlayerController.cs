using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = -2.5f;
    public bool isGrounded = false;
    public int health = 100;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 2f;
    public float holdJumpTimer = 0.0f;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {       
        health = 100;
    }

    void Update()
    {
        Debug.Log(health);
        if(health <= 0)
        {
            Time.timeScale = 0f;
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        
        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.deltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }
            pos.y += velocity.y * Time.deltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.deltaTime;
            }
            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded=true;
                holdJumpTimer = 0;
            }
        }

        transform.position = pos;
    }
}
