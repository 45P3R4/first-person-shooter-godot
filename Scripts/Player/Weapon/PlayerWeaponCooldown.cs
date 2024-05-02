using Godot;
using System;

public partial class PlayerWeaponCooldown : State
{

    public override void Enter()
    {
        timer(Player.CurrentWeapon.Cooldown);
    }

	private async void timer(float time) 
	{
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);

		Fsm.TransitionTo("PlayerWeaponIdle");
	}
}
