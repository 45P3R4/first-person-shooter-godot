using Godot;
using System;

public partial class PlayerWeaponInspect : State
{
    public override void Process(float delta)
    {
        Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
