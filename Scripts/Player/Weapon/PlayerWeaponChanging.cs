using Godot;
using System;

public partial class PlayerWeaponChanging : State
{
	Weapon currentWeapon;
	Weapon nextWeapon;

	[Export]
	float changingSpeed = 1;

	public override void Enter() {

		GetTree().CurrentScene.GetNode("Player").GetNode<Weapon>("WeaponSingleton");

		timer(changingSpeed);
	}

	private async void timer(float time) 
	{
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);

		currentWeapon = nextWeapon;
	}
}
