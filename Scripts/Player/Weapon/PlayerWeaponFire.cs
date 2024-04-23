using Godot;
using System;

public partial class PlayerWeaponFire : State
{
	[Export]
	RayCast3D raycast;

    public override void Enter()
    {
		if(raycast.IsColliding()) {
			if (raycast.GetCollider() is Enemy e) {
				e.TakeDamage(10);
			}
		}
			GD.Print("Fire");
		fsm.TransitionTo("PlayerWeaponCooldown");
    }
}
