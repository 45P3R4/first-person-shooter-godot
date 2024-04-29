using Godot;
using System;

public partial class Animation : AnimationTree
{
    public void OnStateChanged(StateMachine machine) {

        Set("parameters/Transition/transition_request", machine.Name);

        Set("parameters/" + machine.Name + "/conditions/" + machine.PrevState.Name, 0);
        Set("parameters/" + machine.Name + "/conditions/" + machine.CurrentState.Name, 1);
    }
}
