using Godot;
using System;

public partial class State : Node3D
{
	PlayerSingleton s;

	public StateMachine fsm;

	public virtual void Enter() {
		GD.Print(fsm.GetCurrentState().Name);
	}

	public virtual void Exit() {
	}

	public virtual void Ready() {}

	public virtual void Process(float delta) {}

	public virtual void PhysicsProcess(float delta) {
	}

	public virtual void HandleInput(InputEvent @event) {}
}
