namespace CatWorld;

using Godot;
using System;

public partial class MainMenu : CanvasLayer
{

    public override void _Ready() {}

    public override void _Process(double delta) {}

    public static event EventHandler<string> OnNewGameEvent;
    public static event EventHandler<string> OnGotoLoadWindow;

    public void _on_load_game_button_pressed() {
        GD.Print("load game");
        OnGotoLoadWindow?.Invoke(this, "");
    }
    public void _on_quit_button_pressed() {
        GetTree().Quit();
    }
    void _on_new_game_button_pressed() {
        OnNewGameEvent?.Invoke(this, "");
    }

}
