using Godot;
using System;

public partial class Animation : State
{
		[Export]
        AnimationTree anim;

        [Export]
        PlayerStateMachine sm;

        string prev_state = "Idle";

    public override void _PhysicsProcess(double delta)
    {
        if (prev_state != sm.GetCurrentState().Name){
            GD.Print("current " + sm.GetCurrentState().Name + " prev " + prev_state);
            anim.Set("parameters/StateMachine/conditions/" + prev_state, 0);
        }
            
        anim.Set("parameters/StateMachine/conditions/" + sm.GetCurrentState().Name, 1);
        prev_state = sm.GetCurrentState().Name;
    }

}
