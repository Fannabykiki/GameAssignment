﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = -2.93f;
    public bool isGrounded = false;
    public int maxHealth = 4;
    public int currentHealth;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 2f;
    public float holdJumpTimer = 0.0f;
    public Sprite newSprite;
    public Sprite originalSprite;
    public Animator animator;
    private bool hasChangedAnimation = false;
	private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
		animator = GetComponent<Animator>();
		originalSprite = GetComponent<SpriteRenderer>().sprite;
		currentHealth = maxHealth;
		GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 0)
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

        if (Input.GetKeyDown(KeyCode.V) && !hasChangedAnimation)
        {
			animator.SetTrigger("press");
			GetComponent<SpriteRenderer>().sprite = newSprite;
			hasChangedAnimation = true;
			StartCoroutine(ResetAnimation());
		}
    }

    IEnumerator ResetAnimation()
    {
		yield return new WaitForSeconds(0.3f);
		hasChangedAnimation = false;
		animator.SetTrigger("reset");
		GetComponent<SpriteRenderer>().sprite = originalSprite;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCir"))
        {
            currentHealth -= 2;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("EnemyTri")){
            currentHealth -= 4;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("EnemySq"))
        {
            currentHealth -= 2;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);

            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("MinusScore"))
        {
            Debug.Log("Minus score");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("AddHealth"))
        {
            currentHealth += 2;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);

            collision.gameObject.SetActive(false);
        }
    }
}
