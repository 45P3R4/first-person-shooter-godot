using Godot;
using System;

public partial class PlayerWeaponCooldown : State
{

    public override void Enter()
    {
        timer(1f);
    }

	private async void timer(float time) 
	{
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);

		fsm.TransitionTo("PlayerWeaponIdle");
	}
}
