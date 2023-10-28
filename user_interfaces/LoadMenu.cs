namespace CatWorld;

using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class LoadMenu : CanvasLayer
{

    public static event EventHandler<string> OnClose;
    public static event EventHandler<string> OnLoadFile;

    private List<string> files = new();
    public void Initialize() {
        files.Clear();
        if (GetNode("ItemList") is ItemList list){
            list.Clear();
            foreach (string filename in System.IO.Directory.GetFiles(ProjectSettings.GlobalizePath("user://"))) {
                if (!filename.EndsWith(".json")) continue;
                list.AddItem(filename);
                files.Add(filename);
                GD.Print("file added:", filename);
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (Visible && Input.IsActionJustPressed("esc"))
            OnClose?.Invoke(this, "");
    }

    public void _on_close_button_pressed() {
        OnClose?.Invoke(this, "");
    }
    public void _on_load_button_pressed() {
        Node node = GetNode("ItemList");
        if (node is not ItemList) return;
        ItemList list = (ItemList)node;
        int index = (int)list.GetSelectedItems().GetValue(0);
        string filename = files[index];
        OnLoadFile?.Invoke(this, filename);
    }

}
