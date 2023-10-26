using Godot;
using System;

public partial class Game : Node2D
{
    public static event EventHandler<String> ExitButton;
    public override void _Ready(){}
    public override void _Process(double delta){
        // Vector2 velocity = new();
        // velocity.X += 1;

        // if (Input.IsActionJustPressed("")) {}
    }
    public void _on_exit_button_pressed() {
        ExitButton?.Invoke(this, "");
    }



}
