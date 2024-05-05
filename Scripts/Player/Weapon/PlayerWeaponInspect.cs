using Godot;
using System;

public partial class PlayerWeaponInspect : State
{
    public override void Enter()
    {
        Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
