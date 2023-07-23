using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
	IState currentState;
	private RunState runningState;
	private JumpState jumpingState;
	private SlideState slidingState;
	private float timeSinceSlide = 0f;

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
		if (currentState == slidingState)
		{
			timeSinceSlide += Time.deltaTime;
			if (timeSinceSlide >= 0.5f)
			{
				Invoke("ChangeToRunningState", 0f);
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (currentState == runningState)
			{
				ChangeState(jumpingState);
			}
		}
		else if (Input.GetKeyDown(KeyCode.V))
		{
			if (currentState == runningState)
			{
				timeSinceSlide = 0f;
				ChangeState(slidingState);
			}
		}

		currentState.UpdateState();
	}

	void ChangeToRunningState()
	{
		ChangeState(runningState);
	}

	public void ChangeState(IState newState)
	{
		currentState.OnExit();
		currentState = newState;
		currentState.OnEnter();
	}
}
