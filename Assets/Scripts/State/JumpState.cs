using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
	public float gravity;
	public Vector2 velocity;
	public float jumpVelocity = 20;
	public float groundHeight = -2.93f;
	public bool isGrounded = false;
	public void OnEnter(StateController controller)
	{
		isGrounded = true;
	}

	public void OnExit(StateController controller)
	{
		
	}


	public void UpdateState(StateController sc)
	{
		Vector3 pos = sc.transform.position;

		if (isGrounded)
		{
			pos.y += velocity.y * Time.deltaTime;
			velocity.y += gravity * Time.deltaTime;
			if (pos.y <= groundHeight)
			{
				pos.y = groundHeight;
				isGrounded = true;
			}
		}
		else
		{
			sc.ChangeState(sc.runState);
		}

		sc.transform.position = pos;
	}
}
