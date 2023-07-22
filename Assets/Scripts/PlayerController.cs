using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite newSprite;
    public Sprite originalSprite;
    public Animator animator;
    private bool hasChangedAnimation = false;
    public Text distanceUI;
    public Text score;
    private float distance;
    public AudioSource aus;
    public AudioClip jump;
    public AudioClip slide;
    public AudioClip hitItem;
    public AudioClip vacham;
    public AudioClip health;
    public AudioClip die;

    public GameOverUI gameOverUI;
    public bool isDead;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        distanceUI.text = "Highest: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("F");
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
			aus.PlayOneShot(die);
		}

		if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                if( aus && jump)
                {
                    aus.PlayOneShot(jump);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.V) && !hasChangedAnimation)
        {
			animator.SetTrigger("press");
			GetComponent<SpriteRenderer>().sprite = newSprite;
			hasChangedAnimation = true;
			aus.PlayOneShot(slide);
			StartCoroutine(ResetAnimation());
		}
    }

    private void OnApplicationQuit()
    {
        if (distance > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", distance);
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
        score.text = "Distance: " + distance.ToString("F");
        distance += Time.deltaTime * 0.8f;
       
        if (!isGrounded)
        {
            pos.y += velocity.y * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded=true;
            }
        }

        transform.position = pos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCir"))
        {
            currentHealth -= 1;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);
			aus.PlayOneShot(vacham);

			collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("EnemyTri")){
            currentHealth -= 2;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);
			aus.PlayOneShot(vacham);

			collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("EnemySq"))
        {
            currentHealth -= 1;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);
			aus.PlayOneShot(vacham);

			collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("MinusScore"))
        {
            distance -= 5;
            distance = Mathf.Clamp(distance, 0, 9999999);
			aus.PlayOneShot(hitItem);

			collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("AddHealth"))
        {
            currentHealth += 1;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            GUIManager.Instance.DrawHpBarGrid(currentHealth, maxHealth);
			aus.PlayOneShot(health);

			collision.gameObject.SetActive(false);
        }
    }
}
