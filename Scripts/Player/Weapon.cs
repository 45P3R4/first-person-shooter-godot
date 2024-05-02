using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Weapon : State
{
	public Node3D FireEffectScenePoint;

	public bool IsBurst = true;
	public float Cooldown = 0.11f;
	public float ReloadSpeed = 2f;
	public Vector2 Recoil = new Vector2(0.5f, 0.5f);
	public int MaxAmmo = 60;

	private int ammo = 60;

	private Vector2 currentRecoil = Vector2.Zero;
	private PackedScene holeScene = ResourceLoader.Load<PackedScene>("res://Scenes/BulletHole.tscn");
	private Node3D fireEffect = ResourceLoader.Load<PackedScene>("res://Scenes/FireEffect.tscn").Instantiate<Node3D>();

    public override void _Ready()
    {
		FireEffectScenePoint = Player.CurrentWeapon.GetParent().GetNode<Node3D>("./FireEffectPoint");

		FireEffectScenePoint.AddChild(fireEffect);
		fireEffect.Visible = false;
    }

    public virtual void Shoot() {
		if (ammo > 0) {
			ammo--;
			UISingleton.SetAmmo(ammo);

			var rand = new RandomNumberGenerator();
			rand.Seed = Time.GetTicksMsec();

			currentRecoil.X = rand.RandfRange(-Recoil.X, Recoil.X);
			currentRecoil.Y = rand.RandfRange(-Recoil.Y, Recoil.Y);

			Player.Camera.Rotation += new Vector3(Recoil.X * 0.1f, Recoil.Y * 0.1f, 0);
			Player.Raycast.RotateObjectLocal(Vector3.Right, Recoil.X);
			Player.Raycast.RotateObjectLocal(Vector3.Up, Recoil.Y);

			if(Player.Raycast.IsColliding()) {
				BulletHole hole = holeScene.Instantiate<BulletHole>();
				GetTree().CurrentScene.AddChild(hole);
				Vector3 pos = Player.Raycast.GetCollisionPoint();
				hole.Position = pos;
				hole.LookAt(Vector3.Zero, Player.Raycast.GetCollisionNormal());

				foreach (CpuParticles3D item in hole.Particles) {
					item.Emitting = true;
				}

				if (Player.Raycast.GetCollider() is Enemy e) {
					e.TakeDamage(10);
				}
			}
		
			ShowEffect(0.04f, fireEffect);
			Player.Raycast.Rotation =  Vector3.Zero;
		}
	}

	public virtual void Reload() {
		ammo = MaxAmmo;
	}

	public int GetAmmo() {
		return ammo;
	}

	private async void ShowEffect(float time, Node3D effect) 
	{
		effect.Visible = true;
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);
		effect.Visible = false;
	}
}
