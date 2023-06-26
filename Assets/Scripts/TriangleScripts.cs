using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleScripts : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.health -= 100;
            gameObject.SetActive(false);
        }
    }
}