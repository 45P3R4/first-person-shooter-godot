using Godot;
using System;

public partial class PlayerWeaponAimIn : State
{
	public override void Enter()
    {
        
    }

    public override void Process(float delta)
    {
        Fsm.TransitionTo("PlayerWeaponAim");
    }
}
