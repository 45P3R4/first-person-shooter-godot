using Godot;
using System;

public partial class Animation : Node3D
{

		[Export]
        AnimationTree anim;

    //signal from PlayerMovementStateMachine
    public void StateChanged(State new_state, State prev_state, string machine_name) {
        GD.Print(new_state.Name);
        anim.Set("parameters/" + machine_name + "/conditions/" + prev_state.Name, 0);
        anim.Set("parameters/" + machine_name + "/conditions/" + new_state.Name, 1);
    }

}
