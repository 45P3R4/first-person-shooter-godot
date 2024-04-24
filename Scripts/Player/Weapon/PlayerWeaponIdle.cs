using Godot;
using System;

public partial class PlayerWeaponIdle : State
{
	public override void Process(float delta)
	{
		if (Input.IsActionPressed("fire")) {
			Fsm.TransitionTo("PlayerWeaponFire");
		}
		else if (Input.IsActionPressed("reload")) {
			Fsm.TransitionTo("PlayerWeaponReload");
		}
		else if (Input.IsActionPressed("inspect")) {
			Fsm.TransitionTo("PlayerWeaponInspect");
		}
		else {
			Fsm.TransitionTo("PlayerMovementIdle");
		}
	}
}
