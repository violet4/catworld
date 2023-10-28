namespace CatWorld;

using Godot;
using System;


public partial class MainWindow : Node2D
{

    public override void _Ready() {
        if (GetNode("GameInterface") is Node2D n)
            GD.Print("visibility from main window: ", n.Visible);
        LoadMenu.OnClose += (object sender, string eventArgs) => SwitchTo("MainMenu", true);
        MainMenu.OnNewGameEvent += (object sender, string eventArgs) => {
            SwitchTo("GameInterface", false);
        };
        GameInterface.OnQuit += (object sender, string eventArgs) => {
            SwitchTo("MainMenu", true);
        };
        MainMenu.OnGotoLoadWindow += (object sender, string eventArgs) => SwitchTo("LoadMenu", false);
        LoadMenu.OnLoadFile += (object sender, string filename) => {
            if (GetNode("GameInterface") is GameInterface gi)
                gi.LoadGame(filename);
            SwitchTo("GameInterface", false);
        };
    }

    void HideAll() {
        string[] all_node_names = {"MainMenu", "LoadMenu"};
        foreach (string node_name in all_node_names)
            if (GetNode(node_name) is CanvasLayer cl)
                cl.Hide();
    }

    void SwitchTo(string eventArgs, bool background_show) {
        if (GetNode("MainMenuBackground") is Sprite2D bg)
            bg.Visible = background_show;
        // GD.Print("Switching to '", eventArgs, "'");
        HideAll();
        if (eventArgs == "LoadMenu" && GetNode("LoadMenu") is LoadMenu menu)
            menu.Initialize();
        if (GetNode(eventArgs) is CanvasLayer cl)
            cl.Show();
        else if (GetNode(eventArgs) is Node2D node)
            node.Visible = true;
    }

    public override void _Process(double delta) {}



}
