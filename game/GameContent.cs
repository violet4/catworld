namespace CatWorld;

using Godot;
using System;

public partial class GameContent : Node2D
{
    public override void _Process(double delta) {
    }


    public void SaveGame() {
        PackedScene packed_scene = new();
        packed_scene.Pack(GetTree().CurrentScene);
        string filename = "user://saved_game-2023-10-26.tscn";
        ResourceSaver.Save(packed_scene, filename);
    }
    public void LoadGame(string filename) {
        PackedScene loaded_game = (PackedScene)ResourceLoader.Load(filename);
        var my_scene = loaded_game.Instantiate();
        foreach (Node node in GetChildren())
            node.QueueFree();
        AddChild(my_scene);
        my_scene.Owner = this;
    }

}
