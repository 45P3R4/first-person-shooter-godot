using Godot;
using System;

public partial class PlayerWeaponCooldown : State
{

    public override void Enter()
    {
        timer();
    }

	private async void timer() 
	{
		await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
		if (Input.IsActionPressed("fire")) {
			fsm.TransitionTo("PlayerWeaponFire");
		}
		else {
			fsm.TransitionTo("PlayerWeaponIdle");
		}
	}
}
