using Godot;
using System;

public partial class PlayerWeaponReload : State
{
    public override void Start()
    {
        Player.Animation.AnimationFinished += OnAnimationEnd;
    }

    public override void Enter()
    {
        Player.IsReloading = true;
    }

    private void OnAnimationEnd(StringName animName)
    {
        Player.CurrentWeapon.Reload();
        UISingleton.SetAmmo(Player.CurrentWeapon.Ammo);
        Player.IsReloading = false;
		Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
