using Godot;
using System;

public partial class Animation : AnimationTree
{
    public void OnStateChanged(StateMachine machine) {
        if(machine.CurrentState.Name == "PlayerReload") {
            Set("parameters/TimeScale/scale", Player.CurrentWeapon.ReloadSpeed);
        }
        if(machine.PrevState.Name == "PlayerReload") {
            Set("parameters/TimeScale/scale", 1);
        }

        if(machine.CurrentState.Name == "PlayerAimIn" || machine.CurrentState.Name == "PlayerAimOut") {
            Set("parameters/TimeScale/scale", Player.AimInSpeed);
        }
        if(machine.PrevState.Name == "PlayerAimIn" || machine.CurrentState.Name == "PlayerAimOut") {
            Set("parameters/TimeScale/scale", 1);
        }

        Set("parameters/PlayerStateMachine/conditions/" + machine.PrevState.Name, 0);
        Set("parameters/PlayerStateMachine/conditions/" + machine.CurrentState.Name, 1);
    }
}
