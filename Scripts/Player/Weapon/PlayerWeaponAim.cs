using Godot;
using System;

public partial class PlayerWeaponAim : State
{
    public override void Enter()
    {
        Player.IsAiming = true;
    }

    public override void Process(float delta)
    {
		
        if (!Input.IsActionPressed("aim")) {
			Player.IsAiming = false;
			Fsm.TransitionTo("PlayerWeaponAimOut");
		}

		if (Input.IsActionPressed("fire")) {
			Player.CurrentWeapon.Shoot();
        	Fsm.TransitionTo("PlayerWeaponCooldown");
		}
    }
}
