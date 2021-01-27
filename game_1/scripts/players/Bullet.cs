using Godot;
using System;


public class Bullet : Area2D
{
    public int speed = 300;
    public float maxDistance = 100f;
    private Vector2 velocity = new Vector2();
    private Vector2 originalPosition;
    public int direction = 1;
    public Sprite bullet_sprite;

    [Signal]
    public delegate void TakeDamage(int damage);

    public override void _Ready()
    {
        GD.Print("Bullet shooted!");
        bullet_sprite = (Sprite)GetNode("Sprite");

    }

    public void SetBulletDirection(int dir){
        this.direction = dir;
        if (this.direction == -1){
            bullet_sprite.FlipH = true;
        }
        if (this.direction == 1){
            bullet_sprite.FlipH = false;
        }

    }


    public override void _PhysicsProcess(float delta)
    {
        velocity.x = speed * direction * delta;
        Translate(velocity);
        //How long bullet will fly;
        // float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
        // if (distanceTravelled > maxDistance){
        //    this.QueueFree();
        // }
    }

    private void _on_Bullet_body_entered(Node body){
        if (!body.IsInGroup("player")){
            QueueFree();
        }
        if (body.IsInGroup("enemy")){
            
        }
    }
}
