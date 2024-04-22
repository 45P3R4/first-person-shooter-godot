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
            anim.Set("parameters/StateMachine/conditions/" + prev_state, 0);
        }

        if(Input.IsActionJustPressed("reload")) {
            anim.Set("parameters/StateMachine/conditions/Reload", 1);
        }
        else {
            anim.Set("parameters/StateMachine/conditions/Reload", 0);
        }

        if(Input.IsActionJustPressed("fire")) {
            anim.Set("parameters/StateMachine/conditions/Fire", 1);
        }
        else {
            anim.Set("parameters/StateMachine/conditions/Fire", 0);
        }
        
        anim.Set("parameters/StateMachine/conditions/" + sm.GetCurrentState().Name, 1);
        prev_state = sm.GetCurrentState().Name;
    }

}
