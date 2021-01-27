using Godot;
using System;

public class Ball : KinematicBody2D
{
    public int initial_ball_speed = 200;
    public int ball_speed;
    public int speed_commulator = 50;
    public int hitCounter = 0;
    public int maxHitCounter = 12;
    public Vector2 direction = new Vector2();
    public RandomNumberGenerator random_number = new RandomNumberGenerator();

   // KinematicCollision2D collision;
    CollisionShape2D shape2D;

    AudioStreamPlayer2D hitSound;

    public void Start(Vector2 pos){
        Position = pos;

        Show();
        ball_speed = initial_ball_speed;
        GD.Randomize();
        SetStartDirection();
        //shape2D.Disabled = false;
    }

    public override void _Ready(){
        shape2D = (CollisionShape2D)GetNode("CollisionShape2D");
        hitSound = (AudioStreamPlayer2D)GetNode("HitPlatformSound");
        //shape2D.Disabled = true;

        Hide();

    }

    public void SetStartDirection(){
        var random_x = 0;

        if (GD.Randi()%10 < 5){
            random_x = 1;
        }
        else{
            random_x = -1;
        }

        direction = new Vector2(random_x, random_number.RandfRange(-1,1));
        direction = direction.Normalized() * ball_speed;
        
    }

    public override void _PhysicsProcess(float delta){
        var collision = MoveAndCollide(direction * delta);

        if (collision != null){

            direction = direction.Bounce(collision.Normal);
            hitSound.Play();
            if (((Node) collision.Collider).IsInGroup("racket")){

                var y = direction.y / 2 + collision.ColliderVelocity.y;
                
 
                direction = new Vector2(direction.x, y).Normalized() * (ball_speed + hitCounter * speed_commulator);
                direction = direction.Normalized() * (ball_speed);

                if (hitCounter < maxHitCounter){
                    hitCounter += 1;
                }
            }
        }






    }

    

  
}
