using Godot;
using System;

public partial class PlayerMovementCrouchIn : State
{
	Node3D root;

    public override void Enter()
    {
        root = Player.Body.GetParent() as Node3D;
    }

    public override void Process(float delta)
    {
		root.Position -= Vector3.Up * delta * Player.InCrouchSpeed;
		Player.Move(Player.CrouchedSpeed);

		CapsuleShape3D capsule = Player.Collision.Shape as CapsuleShape3D;
		if(capsule.Height > Player.CrouchedHeight) {
        	capsule.Height -= delta * Player.InCrouchSpeed;
		}
		else
			Fsm.TransitionTo("PlayerMovementCrouch");
    }
}
