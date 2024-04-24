using Godot;
using System;

public partial class PlayerWeaponFire : State
{
	[Export]
	RayCast3D raycast;

    public override void Process(float delta)
    {
		if(raycast.IsColliding()) {
			if (raycast.GetCollider() is Enemy e) {
				e.TakeDamage(10);
			}
		}
		Fsm.TransitionTo("PlayerWeaponCooldown");
    }
}
