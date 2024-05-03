using Godot;
using System;

public partial class PlayerMovementIdle : State
{
    public override void Process(float delta) {

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementWalk");


		if (!Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementInAir");
		}
	}

    public override void HandleInput(InputEvent @event)
    {
        if (InputMap.EventIsAction(@event, "jump"))
			Fsm.TransitionTo("PlayerWeaponJump");

		if (InputMap.EventIsAction(@event, "crouch"))
			Fsm.TransitionTo("PlayerMovementCrouchIn");
    }
}
