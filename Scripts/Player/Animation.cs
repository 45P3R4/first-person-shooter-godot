using Godot;
using System;

public partial class Animation : State
{
		[Export]
        AnimationTree anim;

        [Export]
        StateMachine sm;

        string prev_state = "PlayerMovementIdle";

    public override void _PhysicsProcess(double delta)
    {
        if (prev_state != sm.GetCurrentState().Name){
            anim.Set("parameters/StateMachine/conditions/" + prev_state, 0);
        }
        
        anim.Set("parameters/StateMachine/conditions/" + sm.GetCurrentState().Name, 1);
        prev_state = sm.GetCurrentState().Name;
    }

}
