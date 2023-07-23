using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SlideState : IState
{
	public bool isGrounded = false;
	private bool hasChangedAnimation = false;
	public Animator animator;
	public void OnEnter(StateController controller)
	{
		isGrounded = true;
	}

	public void OnExit(StateController controller)
	{
		
	}

	public void UpdateState(StateController controller)
	{
		//if (!hasChangedAnimation)
		//{
		//	animator.SetTrigger("press");
		//	GetComponent<SpriteRenderer>().sprite = newSprite;
		//	hasChangedAnimation = true;
		//	aus.PlayOneShot(slide);
		//	StartCoroutine(ResetAnimation());
		//}
	}
}
