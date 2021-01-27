using Godot;
using System;

public class Platform : Area2D
{

    public int speed = 1;
    public string input_settings;
    public Vector2 velocity = new Vector2();

    private Vector2 _screenSize;

    private Sprite sprite;
    private Rect2 sprite_rect;

    public void Start(Vector2 start_pos, string inp_sets){
        Position = start_pos;
        input_settings = inp_sets;
        Show();
    }
    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        sprite = (Sprite)GetNode("Sprite");
        sprite_rect = (Rect2)sprite.GetRect();
        Hide();
    }

    public void StabilizeVelocity(int maxVelocity){
        if (velocity.y >= maxVelocity){
            velocity.y = maxVelocity;
        }
        if (velocity.y <= -maxVelocity){
            velocity.y = -maxVelocity;
        }
    }

    public void WASD_Input(){
        if (Input.IsActionPressed("w_up")){
            velocity.y -= speed;
        }
        if (Input.IsActionPressed("s_down")){
            velocity.y += speed;
        }
        //Translate(velocity);
        Position += velocity;   

        StabilizeVelocity(2);

    }

    public void ARROWS_Input(){
        if (Input.IsActionPressed("ui_up")){
            velocity.y -= speed;
        }
        if (Input.IsActionPressed("ui_down")){
            velocity.y += speed;
        }
        
        StabilizeVelocity(2);

        //Translate(velocity);
        Position += velocity;   
    }

    public override void _PhysicsProcess(float delta)
    {
        if (input_settings == "wasd"){
            WASD_Input();
        }
        if (input_settings == "arrows"){
            ARROWS_Input();
        }
        
        //It doesn't allow platform go off the game screen
        Position = new Vector2(
            x:Mathf.Clamp(Position.x,0-sprite_rect.Position.x,_screenSize.x+sprite_rect.Position.x),
            y:Mathf.Clamp(Position.y,0-sprite_rect.Position.y,_screenSize.y+sprite_rect.Position.y)
            );

    }

    // public override void _Process(float delta)
    // {
    //     Position = new Vector2(
    //         x:Mathf.Clamp(Position.x,0,_screenSize.x),
    //         y:Mathf.Clamp(Position.y,0,_screenSize.y)
    //         );
    // }




    
}  





