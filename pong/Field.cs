using Godot;
using System;


public class Field : Node2D
{
    // GLOBAL global;
    Label score_left;
    Label score_right;
    private int scoreCountLeft = 0;
    private int scoreCountRight = 0;
    AudioStreamPlayer2D touchdown;
    public override void _Ready()
    {
        //GLOBAL global = (GLOBAL)Owner.GetNode("/root/GLOBAL");
        touchdown = (AudioStreamPlayer2D)GetNode("touchdownSound");
        score_left = (Label)GetNode("Score1Left");
        score_right = (Label)GetNode("Score2Right");
        VisualServer.SetDefaultClearColor(Color.Color8(80,59,188));

    }

    public override void _Process(float delta)
    {
        // score_left.Text = (global.ScoreLeft).ToString();
        // score_right.Text = (global.ScoreRight).ToString();

    }
    public void _on_Arealeft_body_entered(KinematicBody2D body){
        if (body.IsInGroup("ball")){
            // global.ScoreLeft += 1;
            scoreCountRight += 1;
            score_right.Text = scoreCountRight.ToString();
            touchdown.Play();
        }
    }

    public void _on_AreaRight_body_entered(KinematicBody2D body){
        if (body.IsInGroup("ball")){
            // global.ScoreRight += 1;
            scoreCountLeft += 1;
            score_left.Text = scoreCountLeft.ToString();
            touchdown.Play();
        }
    }
}
