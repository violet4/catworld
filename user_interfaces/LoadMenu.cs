using Godot;
using System;

public partial class LoadMenu : CanvasLayer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public static event EventHandler<String> OnClose;

    public void _on_close_button_pressed() {
        OnClose?.Invoke(this, "");
    }


}
