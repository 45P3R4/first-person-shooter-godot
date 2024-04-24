using Godot;
using System;

public partial class Animation : Node3D
{

		[Export]
        AnimationTree anim;

    //signal from PlayerMovementStateMachine
    public void StateChanged(State newState, State prevState, StateMachine machine) {
        GD.Print(newState.Name);
        anim.Set("parameters/" + machine.Name + "/conditions/" + prevState.Name, 0);
        anim.Set("parameters/" + machine.Name + "/conditions/" + newState.Name, 1);
    }

}
