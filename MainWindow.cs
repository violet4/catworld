namespace CatWorld;

using Godot;
using System;


public partial class MainWindow : Node2D
{

    public override void _Ready() {
        MainMenu.OnLoadGameEvent += (object sender, string eventArgs) => SwitchTo("LoadMenu");
        LoadMenu.OnClose += (object sender, string eventArgs) => SwitchTo("MainMenu");
        MainMenu.OnNewGameEvent += (object sender, string eventArgs) => SwitchTo("Game");
        Game.ExitButton += (object sender, string eventArgs) => SwitchTo("MainMenu");
    }

    void HideAll() {
        string[] all_node_names = {"MainMenu", "LoadMenu"};
        foreach (string node_name in all_node_names)
            if (GetNode(node_name) is CanvasLayer cl)
                cl.Hide();
    }

    void SwitchTo(string eventArgs) {
        // GD.Print("Switching to '", eventArgs, "'");
        HideAll();
        if (GetNode(eventArgs) is CanvasLayer cl)
            cl.Show();
    }

    public override void _Process(double delta) {}



}
