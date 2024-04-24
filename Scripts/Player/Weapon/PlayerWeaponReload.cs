using Godot;
using System;

public partial class PlayerWeaponReload : State
{
	public override void Enter()
	{
		Fsm.TransitionTo("PlayerWeaponIdle");
	}
}
