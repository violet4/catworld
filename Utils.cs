namespace CatWorld;

using Godot;
using System;


public class Utils {
    public static string GameSaveDirPath() {
        return UserResourceDirPath();
    }
    public static string UserResourceDirPath(string path="") {
        return ProjectSettings.GlobalizePath("user://"+path);
    }

}
