using Godot;
using System;

public partial class WeaponComponent : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AreaEntered += (Area2D area) => AttackPlayer(area);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AttackPlayer(Area2D area){
		if(area is HitBoxComponent){
			HitBoxComponent hitbox = (HitBoxComponent)area;
			hitbox.TakeDamage();

		}
	}
}
