using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScripts : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.currentHealth -= 2;
            gameObject.SetActive(false);
        }
    }
}
