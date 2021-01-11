using Godot;
using System;


public class Bullet : Area2D
{
    public int speed = 10;
    public float maxDistance = 100f;
    private Vector2 velocity = new Vector2();
    private Vector2 originalPosition;
    public int direction = 1;
    public Sprite bullet_sprite;


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
        // float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
        // if (distanceTravelled > maxDistance){
        //    this.QueueFree();
        // }
    }

    private void _on_Bullet_body_entered(Node body){
        GD.Print("Body entered");
    }
}
