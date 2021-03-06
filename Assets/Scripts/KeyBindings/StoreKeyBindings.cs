using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public static class StoreKeyBindings
{
    private const string custom_path = "keybindings_custom.json";
    private const string default_resource = "keybindings_default";

    public static void SaveKeyBindings()
    {
        Dictionary<String, KeyCode> bindings = KeyBindings.Get();

        var content = JsonConvert.SerializeObject(bindings);
        File.WriteAllText(custom_path, content);
    }

    public static bool SetCustomBindings()
    {
        if (!File.Exists(custom_path))
        {
            return false;
        }
        var content = File.ReadAllText(custom_path);
        Dictionary<String, KeyCode> bindings =  JsonConvert.DeserializeObject<Dictionary<string, KeyCode>>(content);
        KeyBindings.Set(bindings);
        return true;
    }

    public static void RestoreDefaults()
    {
        var content = Resources.Load<TextAsset>(default_resource).text;
        Dictionary<String, KeyCode> bindings =  JsonConvert.DeserializeObject<Dictionary<string, KeyCode>>(content);
        KeyBindings.Set(bindings);
    }
    
}
