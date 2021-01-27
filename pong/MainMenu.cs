using Godot;
using System;

public class MainMenu : Node2D
{

    public PackedScene game_scene;
    public string game_scene_path = "res://Main.tscn";


    public override void _Ready()
    {
        game_scene = (PackedScene)ResourceLoader.Load("res://Main.tscn");

    }



    public void _on_Play_pressed(){
        GetTree().ChangeScene(game_scene_path);
    }

    public void _on_Quit_pressed(){
        GetTree().Quit();
    }


}
