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
            if (!StoreKeyBindings.RestoreDefaults())
            {
                bindings.Add("player1_move_up", KeyCode.W);
                bindings.Add("player1_move_left", KeyCode.A);
                bindings.Add("player1_move_right", KeyCode.D);
                bindings.Add("player1_move_down", KeyCode.S);
                bindings.Add("player1_change_spell", KeyCode.Q);
                bindings.Add("player1_shoot_up", KeyCode.UpArrow);
                bindings.Add("player1_shoot_left", KeyCode.LeftArrow);
                bindings.Add("player1_shoot_right", KeyCode.RightArrow);
                bindings.Add("player1_shoot_down", KeyCode.DownArrow);
                bindings.Add("pause_button", KeyCode.P);
                bindings.Add("cooldown_action", KeyCode.Space);
            }
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
