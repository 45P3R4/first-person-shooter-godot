using Godot;
using System;

public partial class PlayerWeaponAim : State
{
    public override void Process(float delta)
    {
		Player.IsAiming = true;
        if (!Input.IsActionPressed("aim")) {
			Player.IsAiming = false;
			Fsm.TransitionTo("PlayerWeaponIdle");
		}

		if (Input.IsActionPressed("fire")) {
			Player.CurrentWeapon.Shoot();
        	Fsm.TransitionTo("PlayerWeaponCooldown");
		}
    }
}
