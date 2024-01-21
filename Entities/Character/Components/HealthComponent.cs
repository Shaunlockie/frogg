using Godot;
using System;

public partial class HealthComponent : Node2D
{
	[Export] public float max_health {get;set;}
	private float current_health {get;set;}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		current_health = max_health;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TakeDamage(int incomingDamage){
		current_health -= incomingDamage;

		if (current_health <= 0){
			EventBus.Signals.Emitter(EventBus.SignalName.PlayerDied);
			GetParent().QueueFree();

		}
	}
}
