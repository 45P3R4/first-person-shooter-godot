using Godot;
using System;

public partial class PlayerWeaponIdle : State
{
	public override void Process(float delta)
	{
		if (Input.IsActionPressed("fire")) {
			Fsm.TransitionTo("PlayerWeaponFire");
		}
		else if (Input.IsActionJustPressed("reload")) {
			Fsm.TransitionTo("PlayerWeaponReload");
		}
		else if (Input.IsActionJustPressed("inspect")) {
			Fsm.TransitionTo("PlayerWeaponInspect");
		}
	}
}
