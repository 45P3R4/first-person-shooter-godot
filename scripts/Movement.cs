using Godot;
using System;

namespace player_movement {

    public partial class Movement : Node3D
    {
        [Export]
        CharacterBody3D body;

        [Export]
        float speed;

        [Export]
        float jump_force = 5;

        [Export]
        float gravity = -5;

        Vector2 input_dir;
        Vector3 dir;
        Vector3 velocity;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            velocity.Y = gravity;
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta)
        {
            input_dir = Input.GetVector("left", "right", "up", "down");
            dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();

            velocity.X = dir.X * speed;
            velocity.Z = dir.Z * speed;

            if(body.IsOnFloor()) {
                if (Input.IsActionJustPressed("jump")) {
                    velocity.Y = jump_force;
                }
            }
            else {
                velocity.Y += gravity * (float)delta;
            }

            if(body.IsOnCeiling()) {
                velocity.Y = gravity * (float)delta;
            }
            
            body.Velocity = velocity;
            body.MoveAndSlide();
            
        }
    }
}
