namespace CatWorld;

using Godot;
using System;


public partial class MainWindow : Node2D
{

    public override void _Ready() {
        MainMenu.OnLoadGameEvent += SwitchFromMainToLoad;
        LoadMenu.OnClose += SwitchFromLoadToMain;
    }

    void SwitchFromMainToLoad(object sender, string eventArgs) {
        if (GetNode("MainMenu") is CanvasLayer mm)
            mm.Hide();
        if (GetNode("LoadMenu") is CanvasLayer lm)
            lm.Show();
    }
    void SwitchFromLoadToMain(object sender, string eventArgs) {
        if (GetNode("LoadMenu") is CanvasLayer lm)
            lm.Hide();
        if (GetNode("MainMenu") is CanvasLayer mm)
            mm.Show();
    }

    public override void _Process(double delta) {}



}
