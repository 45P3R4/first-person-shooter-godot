using Godot;
using GodotPlugins.Game;
using System;

public partial class PlayerWeaponFire : State
{
	[Signal]
	public delegate void OnFireEventHandler();

	[Export]
	Camera cam;

	[Export]
	RayCast3D raycast;

	[Export]
	Node3D fireNode;

	[Export]
	PackedScene holeScene;

    public override void Process(float delta)
    {
		var rand = new RandomNumberGenerator();
		cam.RotateX(-rand.RandfRange(-0.05f, 0.05f));
		cam.RotateY(-rand.RandfRange(-0.05f, 0.05f));

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
