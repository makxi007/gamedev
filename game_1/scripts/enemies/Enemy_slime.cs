using Godot;
using System;

public class Enemy_slime : KinematicBody2D
{

	[Export]
	public int health = 3;
	public int gravity = 10;
	public int speed = 30;
	Vector2 velocity = new Vector2();
	Vector2 surface = new Vector2(0, -1);
	KinematicBody2D player = null;
	int direction = -1;
	AnimatedSprite animSprite;



	public override void _Ready()
	{
		animSprite = (AnimatedSprite)GetNode("AnimatedSprite");
	}

	public void IfDied(){
		if (this.health <= 0){
			QueueFree();
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		IfDied();
		animSprite.Play("walk");
		//If enemy hit the wall change moving direction
		if (IsOnWall()){
			direction = direction * -1;
		}

		velocity.y += gravity;

		velocity.x = speed * direction;
		// if (player != null){
		// 	velocity = (player.GlobalPosition - GlobalPosition).Normalized();		

		// }
		velocity = MoveAndSlide(velocity, surface);
	

		
	}

	public void TakeDamage(int damage){
		if (this.health > 0){
			this.health -= damage;
		}
	}

	private void _on_HitArea_area_entered(Node body){
		if (body.IsInGroup("bullet")){
			TakeDamage(1);
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









