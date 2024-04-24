using Godot;
using System;

public partial class PlayerWeaponIdle : State
{
	public override void Process(float delta)
	{
		if (Input.IsActionPressed("fire")) {
			Fsm.TransitionTo("PlayerWeaponFire");
		}

		if (Input.IsActionPressed("reload")) {
			Fsm.TransitionTo("PlayerWeaponReload");
		}
	}
}
