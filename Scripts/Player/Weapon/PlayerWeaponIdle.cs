using Godot;

public partial class PlayerWeaponIdle : State
{
    public override void Process(float delta)
    {
        if (Player.CurrentWeapon.IsBurst) {
			if (Input.IsActionPressed("fire")) {
				Fsm.TransitionTo("PlayerWeaponFire"); 
			}
		}
		else {
			if (Input.IsActionJustPressed("fire")) {
				Fsm.TransitionTo("PlayerWeaponFire"); 
			}
		}
		if (Input.IsActionPressed("aim")) {
			Fsm.TransitionTo("PlayerWeaponAimIn");
		}
    }

    public override void HandleInput(InputEvent @event)
    {
		if (InputMap.EventIsAction(@event, "reload"))
			Fsm.TransitionTo("PlayerWeaponReload");

		if (InputMap.EventIsAction(@event, "inspect"))
			Fsm.TransitionTo("PlayerWeaponInspect");
		
		if (InputMap.EventIsAction(@event, "fire"))
			GD.Print("Action");
    }
}
