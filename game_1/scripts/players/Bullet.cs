using Godot;
using System;


public class Bullet : Area2D
{
    public int speed = 10;
    public float maxDistance = 1000;

    private Vector2 originalPosition;
    public override void _Ready()
    {
        GD.Print("Bullet shooted!");
    }
    public void BulletShot(){
        originalPosition = this.Position;

        Position += new Vector2(speed, 0);
    }
    public override void _PhysicsProcess(float delta)
    {
        BulletShot();
       float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
       if (distanceTravelled > this.maxDistance){
           this.QueueFree();
       }
    }

    private void _on_Bullet_body_entered(Node body){
        GD.Print("Body entered");
    }
}
