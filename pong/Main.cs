using Godot;
using System;

public class Main : Node
{

    Position2D first_start_position;
    Position2D second_start_position;
    Platform platform_first;
    Platform platform_second;
    PlatformKinematic platformKinematic1;
    PlatformKinematic platformKinematic2;
    Ball ball;
    Position2D ball_position; 
    public string main_menu_path = "res://MainMenu.tscn";
    

    public void platformArea2DStart(Position2D first_position, Position2D second_position){

        platform_first = (Platform)GetNode("Platform1");
        platform_second = (Platform)GetNode("Platform2");

        platform_first.Start(first_position.Position, "wasd");
        platform_second.Start(second_position.Position, "arrows");
    }

    public void platformKinematic2DStart(Position2D first_position, Position2D second_position){

        platformKinematic1 = (PlatformKinematic)GetNode("PlatformKinematic1");
        platformKinematic2 = (PlatformKinematic)GetNode("PlatformKinematic2");

        platformKinematic1.Start(first_position.Position, "wasd");
        platformKinematic2.Start(second_position.Position, "arrows");
    }
    public override void _Ready()
    {
        first_start_position = (Position2D)GetNode("Platform1Position");
        second_start_position = (Position2D)GetNode("Platform2Position");
        first_start_position.Position = new Vector2(50, 300);
        second_start_position.Position = new Vector2(950, 300);

        platformKinematic2DStart(first_start_position, second_start_position);

        ball = (Ball)GetNode("Ball");
        ball_position = (Position2D)GetNode("BallPosition");
        ball.Start(ball_position.Position);
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("to_main_menu")){
            GetTree().ChangeScene(main_menu_path);
        }
    }

    

}
