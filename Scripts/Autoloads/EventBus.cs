using Godot;
using System;

public partial class EventBus : Node
{

	private static EventBus eventBus;

    public static EventBus Signals
    {
        get
        {
            if (eventBus == null)
            {
                eventBus = new EventBus();
            }
            return eventBus;
        }
	}
	
	[Signal] public delegate void PlayerDiedEventHandler();
	[Signal] public delegate void GetScoreEventHandler(int currentScore);

    public void Emitter(StringName signal){
        EmitSignal(signal);
    }
    
}
