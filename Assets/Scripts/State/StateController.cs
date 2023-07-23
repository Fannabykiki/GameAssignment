using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
	IState currentState;
	public JumpState jumpState = new JumpState();
	public RunState runState = new RunState();
	public SlideState slideState = new SlideState();


	private void Start()
	{
		ChangeState(runState);
	}

	void Update()
	{
		if (currentState != null)
		{
			currentState.UpdateState(this);
		}
	}

	public void ChangeState(IState newState)
	{
		if (currentState != null)
		{
			currentState.OnExit(this);
		}
		currentState = newState;
		currentState.OnEnter(this);
	}
}
