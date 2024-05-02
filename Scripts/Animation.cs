using Godot;
using System;

public partial class Animation : AnimationTree
{

    public override void _Ready()
    {
         Set("parameters/WeaponTimeScale/scale", Player.CurrentWeapon.ReloadSpeed);
    }

    public void OnStateChanged(StateMachine machine) {

        Set("parameters/Transition/transition_request", machine.Name);

        Set("parameters/" + machine.Name + "/conditions/" + machine.PrevState.Name, 0);
        Set("parameters/" + machine.Name + "/conditions/" + machine.CurrentState.Name, 1);
    }
}
