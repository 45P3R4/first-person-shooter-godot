using Godot;
using System;

public partial class PlayerMovementCrouchOut : State
{
	Node3D root;

	CapsuleShape3D capsule;

    public override void Enter()
    {
        root = Player.Body.GetParent() as Node3D;
		capsule = Player.Collision.Shape as CapsuleShape3D;
    }

    public override void Process(float delta)
    {
		root.Position -= Vector3.Up * delta * Player.InCrouchSpeed;
		Player.Move(Player.CrouchedSpeed);

		if(capsule.Height < Player.NormalHeight) {
        	capsule.Height += delta * Player.InCrouchSpeed;
		}
		else {
			capsule.Height = Player.NormalHeight;
			Fsm.TransitionTo("PlayerMovementIdle");
		}
    }
}
