using Godot;
using System;

public partial class PlayerWeaponIdle : State
{
	public override void Process(float delta)
	{
		if (Input.IsActionPressed("fire")) {
			fsm.TransitionTo("PlayerWeaponFire");
		}

		if (Input.IsActionPressed("reload")) {
			fsm.TransitionTo("PlayerWeaponReload");
		}
	}
}
