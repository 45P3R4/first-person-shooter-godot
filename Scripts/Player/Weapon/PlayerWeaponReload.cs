using Godot;
using System;

public partial class PlayerWeaponReload : State
{
    public override void _Ready()
    {
        Player.Animation.AnimationFinished += OnAnimationEnd;
    }

    private void OnAnimationEnd(StringName animName)
    {
        Player.CurrentWeapon.Reload();
		Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
