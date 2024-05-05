using Godot;
using GodotPlugins.Game;
using System;

public partial class PlayerWeaponFire : State
{
    public override void Enter()
    {
        Player.CurrentWeapon.Shoot();
        Fsm.TransitionTo("PlayerWeaponCooldown");
    }
}
