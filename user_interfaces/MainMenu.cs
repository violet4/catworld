namespace CatWorld;

using Godot;
using System;

public partial class MainMenu : CanvasLayer
{

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }

    public static event EventHandler<String> OnLoadGameEvent;

    public void _on_load_game_button_pressed() {
        OnLoadGameEvent?.Invoke(this, "");
    }
    public void _on_quit_button_pressed() {
        GetTree().Quit();
    }

}
