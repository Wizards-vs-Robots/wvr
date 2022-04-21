using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public static class StoreKeyBindings
{
    private const string custom_path = "keybindings_custom.json";
    private const string default_path = "keybindings_default.json";

    static StoreKeyBindings()
    {
      
    }
        
    public static void SaveKeyBindings()
    {
        Dictionary<String, KeyCode> bindings = KeyBindings.Get();

        var content = JsonConvert.SerializeObject(bindings);
        File.Delete(custom_path);
        File.WriteAllText(custom_path, content);
    }

    public static bool SetDefaultBindings()
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
        if (!File.Exists(default_path))
        {
            return;
        }
        var content = File.ReadAllText(default_path);
        Dictionary<String, KeyCode> bindings =  JsonConvert.DeserializeObject<Dictionary<string, KeyCode>>(content);
        KeyBindings.Set(bindings);
    }
    
}
