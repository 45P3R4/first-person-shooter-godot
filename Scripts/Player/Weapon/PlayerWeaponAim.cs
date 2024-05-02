using Godot;
using System;

public partial class PlayerWeaponAim : State
{
    public override void Process(float delta)
    {
        if (!Input.IsActionPressed("aim")) {
			Fsm.TransitionTo("PlayerWeaponIdle");
		}

		if (Input.IsActionPressed("fire")) {
			Player.CurrentWeapon.Shoot();
        	Fsm.TransitionTo("PlayerWeaponCooldown");
		}
    }
}
