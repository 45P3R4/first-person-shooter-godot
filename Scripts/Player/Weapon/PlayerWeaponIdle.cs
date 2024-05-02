using Godot;
using System;

public partial class PlayerWeaponIdle : State
{
	public override void Process(float delta)
	{
		if (Player.CurrentWeapon.IsBurst) {
			if (Input.IsActionPressed("fire")) {
				Fsm.TransitionTo("PlayerWeaponFire"); }
		}
		else {
			if (Input.IsActionJustPressed("fire")) {
				Fsm.TransitionTo("PlayerWeaponFire"); }
		}

		if (Input.IsActionJustPressed("reload")) {
			Fsm.TransitionTo("PlayerWeaponReload"); }
			
		if (Input.IsActionJustPressed("inspect")) {
			Fsm.TransitionTo("PlayerWeaponInspect"); }
	}
}
