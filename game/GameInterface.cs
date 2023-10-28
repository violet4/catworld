namespace CatWorld;

using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class GameInterface : Node2D {
    public static event EventHandler<String> OnQuit;
    public PlayerCamera playerCamera;
    public override void _Ready(){
        playerCamera = (PlayerCamera)GetNode("PlayerCamera");
        GD.Print("visibility from within game interface: ", Visible);
    }
    public override void _Process(double delta) {
        // Vector2 velocity = new();
        // velocity.X += 1;

        // if (Input.IsActionJustPressed("")) {}
    }
    public void _on_save_button_pressed() {
        SaveGame();
    }
    public void SaveGame(string filename = "user://saved_game-2023-10-27.json") {
        var cameraSerialized = GetSerializableProperties();
        string pc = JsonSerializer.Serialize(cameraSerialized);
        using var file = FileAccess.Open(filename, FileAccess.ModeFlags.Write);
        file.StoreString(pc);
    }
    public void LoadGame(string filename = "saved_game-2023-10-27.json") {
        // string full_filename = Utils.GameSaveDirPath()+filename;
        using FileAccess file = FileAccess.Open(filename, FileAccess.ModeFlags.Read);
        string data_string = file.GetAsText();
        Dictionary<string, object> pc = JsonSerializer.Deserialize<Dictionary<string, object>>(data_string);
        Load(pc);
    }
    public Dictionary<string, object> GetSerializableProperties() {
        return new Dictionary<string, object> {
            {"X", playerCamera.Position.X},
            {"Y", playerCamera.Position.Y},
        };
    }
    public void Load(Dictionary<string, object> data) {
        if (data.TryGetValue("X", out object X) && X is JsonElement XElem)
            playerCamera.X = (float)XElem.GetDouble();
        if (data.TryGetValue("Y", out object Y) && Y is JsonElement YElem)
            playerCamera.Y = (float)YElem.GetDouble();
    }

    public void _on_exit_button_pressed() {
        OnQuit?.Invoke(this, "");
        Visible = false;
        if (GetNode("PlayerCamera") is CharacterBody2D camera) {
            camera.Position = new Vector2(0,0);
            camera.Velocity = new Vector2(0,0);
        }
    }


}
