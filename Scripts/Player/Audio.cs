using Godot;
using System;

public partial class Audio : AudioStreamPlayer3D
{
	//signal
	public void OnFire() {
		Play();
	}
}
