using Godot;
using System;

public partial class PlayerWeaponFire : State
{
	[Signal]
	public delegate void OnFireEventHandler();

	[Export]
	RayCast3D raycast;

	[Export]
	Node3D fireNode;

    public override void Process(float delta)
    {
		if(raycast.IsColliding()) {
			if (raycast.GetCollider() is Enemy e) {
				e.TakeDamage(10);
			}
		}
		timer(0.05f);
		
		EmitSignal(SignalName.OnFire);
		Fsm.TransitionTo("PlayerWeaponCooldown");
    }

	private async void timer(float time) 
	{
		fireNode.Visible = true;
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);
		fireNode.Visible = false;
	}
}
