using Godot;
using System;

public partial class InputComponent : Node
{
	[Export] public MovementComponent movement_component {get; set;}
	[Export] public CharacterBody2D characterBody {get;set;}

	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// CheckInput();
	}

	private void CheckInput(){
	
		// Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		// if(direction != Vector2.Zero)
		// {
		
		// 	movement_component.ChangeVelocity(direction);
		// }

		// movement_component.Move(characterBody);
	}
}

