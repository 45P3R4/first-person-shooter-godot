using Godot;
using System;

public partial class PlayerWeaponReload : State
{
	AnimationTree anim;
	public override void Process(float delta)
	{
		Fsm.TransitionTo("PlayerWeaponIdle");
		anim = GetNode<AnimationTree>("../../AnimationTree");
		// anim.AnimationFinished += OnAnimationFinished;
	}

    private void OnAnimationFinished(StringName animName)
    {
        Fsm.TransitionTo("PlayerWeaponIdle");
    }
}
