using Godot;
using System;
using static Enums;

public partial class Character : CharacterBody2D
{
	[Export] public HitBoxComponent hit_box_component {get;set;}
	[Export] public MovementComponent movement_component {get;set;}
	[Export] public TileMapInteractionComponent tilemap_interaction {get; set;}
	[Export] public int grid_size_int {get;set;}
	private Vector2 direction {get;set;} = Vector2.Zero;
	private bool can_move {get; set;} = true;

    public override void _Ready()
    {
        // hit_box_component.b +=  (Node2D tilemap) => CheckTile((TileMap)tilemap);
    }

    public override void _PhysicsProcess(double delta)
    {
		Vector2 originalPosition = GlobalPosition;
		Vector2 input = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(can_move && input != Vector2.Zero){
			can_move = false;
			movement_component.Run(this, GlobalPosition + input * grid_size_int);
			movement_component.tween.Finished += () => MovementFinished(originalPosition);
		}
    }

	public void MovementFinished(Vector2 originalPosition){
		tilemap_interaction.CheckTileType(GlobalPosition);
		
		switch (tilemap_interaction.CheckTileType(GlobalPosition)){
			case (int)tile_type.Water: 
				GlobalPosition = originalPosition;
			break;
			case (int)tile_type.End: 
				QueueFree();
			break;
		}
		can_move = true;
	}

	
}
