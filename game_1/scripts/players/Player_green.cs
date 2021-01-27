using Godot;
using System;

public class Player_green : KinematicBody2D
{
	//Movement variables;
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


	//Shot variables;
	private bool can_fire = true;
	public float bullet_delay = 0.5F;
	public PackedScene bullet;
	private Bullet bullet_instance;
	private Position2D bullet_position;
	private Vector2 bullet_pos;
	private Vector2 bullet_global_pos;
	private int shot_direction = 1;

	



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animSprite = (AnimatedSprite)GetNode("AnimatedSprite");
		bullet = GD.Load<PackedScene>("res://scenes/players/Bullets/Bullet.tscn");



		bullet_position = (Position2D)GetNode("Position2D");
		bullet_pos = bullet_position.Position;
		bullet_global_pos = bullet_position.GlobalPosition;


	}
	
	public void getInput(){
		velocity.x = 0;
		direction = 0;

		if (Input.IsActionPressed("d_right")){
			animSprite.FlipH = false;
			shot_direction = 1;

			direction = 1;
		}
		if (Input.IsActionPressed("a_left")){
			animSprite.FlipH = true;
			shot_direction = -1;

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

	public async void Shot(){
		bullet_instance = (Bullet)bullet.Instance();
		
		bullet_position.Position = new Vector2(20*shot_direction, 5);
		GetParent().AddChild(bullet_instance);
		bullet_instance.Position = bullet_position.GlobalPosition;
		bullet_instance.SetBulletDirection(shot_direction);

		can_fire = false;
		await ToSignal(GetTree().CreateTimer(bullet_delay), "timeout");
		can_fire = true;

	}

	public void Jump(){
		if (IsOnFloor()){
			velocity.y = jumpForce;
		}
	}

	public override void _PhysicsProcess(float delta){
		getInput();
		velocity.y += gravity * delta;
	
		velocity = MoveAndSlide(velocity , surface);

		if (Input.IsActionPressed("jump")){
			Jump();
		}

		if (Input.IsActionPressed("fire")){
			if (can_fire){
				Shot();
			}

		}

	}

}
