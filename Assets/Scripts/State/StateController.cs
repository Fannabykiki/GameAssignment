using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
	IState currentState;
	private RunState runningState;
	private JumpState jumpingState;
	private SlideState slidingState;

	private void Awake()
	{
		runningState = new RunState();
		jumpingState = new JumpState();
		slidingState = new SlideState();
	}

	private void Start()
	{
		currentState = runningState;
		currentState.OnEnter();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (currentState == runningState)
			{
				ChangeState(jumpingState);
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (currentState == runningState)
			{
				ChangeState(slidingState);
			}
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			if (currentState == jumpingState)
			{
				ChangeState(runningState);
			}
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			if (currentState == slidingState)
			{
				ChangeState(runningState);
			}
		}

		currentState.UpdateState();
	}
	public void ChangeState(IState newState)
	{
		currentState.OnExit();
		currentState = newState;
		currentState.OnEnter();
	}
}
