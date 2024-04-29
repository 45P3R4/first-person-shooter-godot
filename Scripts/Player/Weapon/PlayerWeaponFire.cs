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

	float maxRecoil = 0;

	Vector2 recoil = Vector2.Zero;

    public override void Process(float delta)
    {
		var rand = new RandomNumberGenerator();
		rand.Seed = Time.GetTicksMsec();

		maxRecoil = Weapon.recoil;

		recoil.X = rand.RandfRange(-maxRecoil, maxRecoil);
		recoil.Y = rand.RandfRange(-maxRecoil, maxRecoil);

		cam.Rotation += new Vector3(recoil.X, recoil.Y, 0);

		raycast.RotateObjectLocal(Vector3.Right, recoil.X);
		raycast.RotateObjectLocal(Vector3.Up, recoil.Y);

		if(raycast.IsColliding()) {
			BulletHole hole = holeScene.Instantiate<BulletHole>();
			GetTree().CurrentScene.AddChild(hole);
			Vector3 pos = raycast.GetCollisionPoint();
			hole.Position = pos;
			hole.LookAt(Vector3.Zero, raycast.GetCollisionNormal());

			if (raycast.GetCollider() is Enemy e) {
				e.TakeDamage(10);
			}
		}
		timer(Weapon.Cooldown);
		
		raycast.Rotation =  Vector3.Zero;

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
