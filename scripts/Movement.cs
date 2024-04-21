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
        float walk_speed;

        [Export]
        float sprint_speed;

        [Export]
        float jump_force = 5;

        [Export]
        float gravity = -5;

        public enum State
        {
            Idle,
            Walk,
            Run,
            Jump
        }

        State state;
        Vector2 input_dir;
        Vector3 dir;
        Vector3 velocity;


        public Vector3 Get_velocity() {
            return body.Velocity;
        }

        public State Get_state() {
            return state;
        }

        private void set_state(State new_state) {
            state = new_state;
        }

        public override void _Ready()
        {
            velocity.Y = gravity;
        }

        public override void _PhysicsProcess(double delta) //TODO to void _Input
        {
            input_dir = Input.GetVector("left", "right", "up", "down");

            if (input_dir != Vector2.Zero) {
                walk();
            }
            else {
                idle();
            }
            
            if (Input.IsActionPressed("sprint") && state == State.Walk) {
                    run();
                }

            if(body.IsOnFloor()) {                
                if (Input.IsActionJustPressed("jump")) {
                    jump();
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

        public void Change_state(State new_state) {
            state = new_state;
        }

        private void idle() {
            Change_state(State.Idle);
            velocity.X = 0;
            velocity.Z = 0;
        }

        private void walk() {
            Change_state(State.Walk);
            dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
            velocity.X = dir.X * speed;
            velocity.Z = dir.Z * speed;
        }

        private void run() {
            Change_state(State.Run);
            dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
            velocity.X = dir.X * sprint_speed;
            velocity.Z = dir.Z * sprint_speed;
        }

        private void jump() {
            Change_state(State.Jump);
            velocity.Y = jump_force;
        }
    }
}
