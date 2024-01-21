using Godot;
using System;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EventBus.Signals.PlayerDied += () => GD.Print("platerDied");
	}
}
