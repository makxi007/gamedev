using Godot;
using System;

public class Player_green : KinematicBody2D
{
	public int speed = 1000;
	public int jumpForce = -400;
	public int gravity = 700;
	private bool isJump = false;

	private float friction = 0.1F;
	private float acceleration = 0.2F;

	private int direction = 0;
	Vector2 velocity = new Vector2();
	Vector2 surface = new Vector2(0, -1);

	AnimatedSprite animSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animSprite = (AnimatedSprite)GetNode("AnimatedSprite");
	}
	
	public void getInput(){
		velocity.x = 0;
		direction = 0;

		if (Input.IsActionPressed("d_right")){
			animSprite.FlipH = false;
			direction = 1;
		}
		if (Input.IsActionPressed("a_left")){
			animSprite.FlipH = true;
			direction = -1;
		}

		if (direction != 0){
			animSprite.Play("walk");
			velocity.x = Mathf.Lerp(velocity.x, direction * speed, acceleration);
		}
		else{
			animSprite.Play("stand");
			velocity.x = Mathf.Lerp(velocity.x, 0, friction);
		}
		

	}

	public override void _PhysicsProcess(float delta){
		getInput();
		velocity.y += gravity * delta;

		velocity = MoveAndSlide(velocity , surface);

		if (Input.IsActionPressed("jump")){
			if (IsOnFloor()){
				velocity.y = jumpForce;
				
			}
		}

	}

}
