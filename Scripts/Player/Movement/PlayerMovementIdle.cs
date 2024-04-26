using Godot;
using System;

public partial class PlayerMovementIdle : State
{
    public override void Start()
    {
        Player.WeaponStateMachine.Locked = false;
    }

    public override void Process(float delta) {

		if (Input.IsActionJustPressed("jump"))
			Fsm.TransitionTo("PlayerMovementJump");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementWalk");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero && Input.IsActionPressed("sprint"))
			Fsm.TransitionTo("PlayerMovementRun");

		if (!Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementInAir");
		}
	}
}
