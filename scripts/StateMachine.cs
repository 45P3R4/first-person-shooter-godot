using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node3D
{
	[Signal]
	public delegate void OnStateChangedEventHandler(StateMachine machine);

	[Export]
	public State initialState;

	private Dictionary<string, State> states;
	public State CurrentState;
	public State PrevState;
	public bool Locked = false;

    public override void _Ready()
    {
        states = new Dictionary<string, State>();
		foreach (Node node in GetChildren()) {
			if(node is State s) {
				states[node.Name] = s;
				s.Fsm = this;
				s.Start();
				s.Exit();
			}
		}

		CurrentState = initialState;
		CurrentState.Enter();
    }

    public override void _Process(double delta) {
        CurrentState.Process((float) delta);
    }

    public override void _PhysicsProcess(double delta) {
        CurrentState.PhysicsProcess((float) delta);
    }

    public override void _UnhandledInput(InputEvent @event) {
        CurrentState.HandleInput(@event);
    }

	public void TransitionTo (string key) {
		if (!Locked) {

			if (!states.ContainsKey(key) || CurrentState == states[key])
				return;

			PrevState = CurrentState;

			CurrentState.Exit();
			CurrentState = states[key];
			CurrentState.Enter();

			GD.Print(CurrentState.Name);

			EmitSignal(SignalName.OnStateChanged, this);
		}
		else {
			CurrentState = initialState;
		}
	}

	public State GetCurrentState() {
		return CurrentState;
	}
}
