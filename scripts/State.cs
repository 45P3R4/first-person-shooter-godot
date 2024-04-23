using Godot;
using System;

public partial class State : Node3D
{
	public StateMachine fsm;

	public virtual void Enter() {}

	public virtual void Exit() {}

	public virtual void Start() {}

	public virtual void Process(float delta) {}

	public virtual void PhysicsProcess(float delta) {}

	public virtual void HandleInput(InputEvent @event) {}
}
