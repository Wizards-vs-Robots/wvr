using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/**
 * Maintain more key bindings here, this gets modified via the key bindings menu UI
 */
public static class KeyBindings
{
    private static Dictionary<String, KeyCode> bindings = new Dictionary<string, KeyCode>();
    static KeyBindings(){
        if (!StoreKeyBindings.SetCustomBindings())
        {
            StoreKeyBindings.RestoreDefaults();
        }
    }

    public static KeyCode GetKeyBinding(string key) {
        return bindings[key]; 
    }
    
    public static bool SetKeyBinding(string key, KeyCode binding)
    {
        KeyCode oldkey = bindings[key];
        bindings.Remove(key);
        if (!bindings.ContainsValue(binding))
        {
            bindings.Add(key, binding);
            return true;
        }
        else
        {
            bindings.Add(key,oldkey);
            return false;
        }
    }
    public static Dictionary<String, KeyCode> Get()
    {
        return bindings;
    }
    
    public static void Set(Dictionary<String, KeyCode> dic)
    {
        bindings = dic;
    }
}
