using Godot;
using System;

public partial class Enemy : CharacterBody3D
{
	int health = 100;

	public void TakeDamage(int damage) {
		health -= damage;
		GD.Print(health);
		if(health <= 0) {
			QueueFree();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		
	}
}
