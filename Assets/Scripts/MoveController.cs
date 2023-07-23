using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public void OnJump()
    {
        PlayerController.Instance.OnJump();
    }

	public void OnSlide()
	{
		PlayerController.Instance.OnSlide();
	}
}
