using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node3D
{
	[Signal]
	public delegate void StateChangedEventHandler(State new_state, State prev_state, string machine_name);

	[Export]
	public State initialState;

	private Dictionary<string, State> _states;
	public State currentState;
	public State prevState;

    public override void _Ready()
    {
        _states = new Dictionary<string, State>();
		foreach (Node node in GetChildren()) {
			if(node is State s) {
				_states[node.Name] = s;
				s.fsm = this;
				s.Start();
				s.Exit();
			}
		}

		currentState = initialState;
		currentState.Enter();
    }

    public override void _Process(double delta) {
        currentState.Process((float) delta);
    }

    public override void _PhysicsProcess(double delta) {
        currentState.PhysicsProcess((float) delta);
    }

    public override void _UnhandledInput(InputEvent @event) {
        currentState.HandleInput(@event);
    }

	public void TransitionTo (string key) {
		if (!_states.ContainsKey(key) || currentState == _states[key])
			return;

		prevState = currentState;

		currentState.Exit();
		currentState = _states[key];
		currentState.Enter();


		EmitSignal(SignalName.StateChanged, currentState, prevState, Name);
	}

	public State GetCurrentState() {
		return currentState;
	}
}
