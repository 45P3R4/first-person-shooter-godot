using Godot;
using System;

public partial class PlayerWeaponAimOut : State
{
    public override void Enter()
    {
        
    }

    public override void Process(float delta)
    {
        Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
