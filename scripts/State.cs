using Godot;
using System;

public partial class State : Node3D
{
	public PlayerStateMachine fsm;

	public virtual void Enter() {}

	public virtual void Exit() {
	}

	public virtual void Ready() {}

	public virtual void Process(float delta) {}

	public virtual void PhysicsProcess(float delta) {

		if (!fsm.body.IsOnFloor()) {
			fsm.TransitionTo("InAir");
		}
	}

	public virtual void HandleInput(InputEvent @event) {}
}
