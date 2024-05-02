using Godot;
using System;

public partial class PlayerWeaponReload : State
{
    public override void Enter()
    {
        Player.Animation.AnimationFinished += OnAnimationEnd;
    }

    private void OnAnimationEnd(StringName animName)
    {
        Player.CurrentWeapon.Reload();
        UISingleton.SetAmmo(Player.CurrentWeapon.Ammo);
		Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
