using Godot;
using System;

public partial class UISingleton : Control
{
	public UISingleton UI;

	public static Label ammoLabel;

    public override void _Ready()
    {
		ammoLabel = GetNode<Label>("./Ammo");
		SetAmmo(Player.CurrentWeapon.GetAmmo());
    }

    public static void SetAmmo(int ammo) {
		ammoLabel.Text = ammo.ToString();
	}
}
