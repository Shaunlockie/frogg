using Godot;
using System;

public partial class HitBoxComponent : Area2D
{
	[Export] public HealthComponent health_component {get; set;}

	public void TakeDamage(){
		if(health_component is HealthComponent && health_component != null){
			health_component.TakeDamage(1);
		}
	}
}
