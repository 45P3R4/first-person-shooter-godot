using Godot;
using System;

public partial class PlayerWeaponReload : State
{
	AnimationTree anim;
	public override void Enter()
    {
        timer(Player.CurrentWeapon.ReloadSpeed);
    }
	private async void timer(float time) 
	{
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);
		Player.CurrentWeapon.Reload();

		Fsm.TransitionTo("PlayerWeaponIdle");
		
	}
}
