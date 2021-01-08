using Godot;
using System;

public class Enemy_slime : KinematicBody2D
{
	public int gravity = 700;
	public int speed = 500;
	Vector2 velocity = new Vector2();
	Vector2 surface = new Vector2(0, -1);
	Node2D player = null;


	public override void _Ready()
	{
		GD.Print(Position);
	}

	public override void _PhysicsProcess(float delta)
	{
		

		if (player != null){
				var direction = (player.GlobalPosition - GlobalPosition).Normalized();
				velocity = MoveAndSlide(speed * direction * delta);
		}

	}

	private void _on_Area2D_body_entered(KinematicBody2D body)
	{
		if (body.IsInGroup("player")){
			player = body;
		}
	}
	
	private void _on_Area2D_body_exited(KinematicBody2D body)
	{
		if (body.IsInGroup("player")){
			player = null;
		}
	}

}









