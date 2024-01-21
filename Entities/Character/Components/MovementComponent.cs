

using Godot;
using System;

public partial class MovementComponent : Node
{
	public Vector2 current_velocity {get; set;}
	public int speed {get; private set;} = 100;

	[Export] public float move_time {get;set;}
	[Export] public int transition_index {get; set;}
	[Export] public int ease_index {get; set;}
	public Tween tween {get; set;}

	public enum transition {TRANS_LINEAR,TRANS_SINE, TRANS_QUINT, TRANS_QUART, TRANS_QUAD, TRANS_EXPO, TRANS_ELASTIC, TRANS_CUBIC, TRANS_CIRC, TRANS_BOUNCE, TRANS_BACK}
	public enum easing {EASE_IN, EASE_OUT, EASE_IN_OUT, EASE_OUT_IN}

    public override void _Notification(int what)
    {
        // this.WireNodes();
    }

	public void Run(CharacterBody2D characterBody, Vector2 endPosition){
		tween = GetTree().CreateTween().BindNode(this);
		tween.SetTrans((Tween.TransitionType)transition_index);
		tween.SetEase((Tween.EaseType)ease_index);
		tween.TweenProperty(characterBody, "global_position", endPosition, move_time);
	}

	// public void ChangeVelocity(Vector2 newVelocity){
	// 	// velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed); 
	// 	Vector2 newsts = new Vector2();

	// 	newsts.X = newVelocity.X * (float)10;
	// 	current_velocity = newsts;
		
	// }

	// public void Move(CharacterBody2D characterBody){
	// 	characterBody.Velocity = current_velocity;
	// 	characterBody.MoveAndSlide();
	// }

}
