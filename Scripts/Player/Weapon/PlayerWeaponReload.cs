using Godot;
using System;

public partial class PlayerWeaponReload : State
{
	public override void Enter()
	{
		fsm.TransitionTo("PlayerWeaponIdle");
	}
}
