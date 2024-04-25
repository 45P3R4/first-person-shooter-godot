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

	[Export]
	PackedScene holeScene;

    public override void Process(float delta)
    {
		if(raycast.IsColliding()) {
			BulletHole hole = holeScene.Instantiate<BulletHole>();
			GetTree().CurrentScene.AddChild(hole);
			hole.Position = raycast.GetCollisionPoint();
			if (raycast.GetCollisionNormal() != Vector3.Up)
				hole.LookAt(hole.GlobalPosition + raycast.GetCollisionNormal());

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
