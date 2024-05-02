using Godot;
using GodotPlugins.Game;
using System;

public partial class PlayerWeaponFire : State
{
    public override void Process(float delta)
    {
        Player.CurrentWeapon.Shoot();
        Fsm.TransitionTo("PlayerWeaponCooldown");
    }
}
