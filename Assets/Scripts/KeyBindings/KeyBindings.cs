using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public static class KeyBindings
{
    private static Dictionary<String, KeyCode> bindings = new Dictionary<string, KeyCode>();
    static KeyBindings(){
        bindings.Add("player1_move_up", KeyCode.W);
        bindings.Add("player1_move_left", KeyCode.A);
        bindings.Add("player1_move_right", KeyCode.D);
        bindings.Add("player1_move_down", KeyCode.S);
        bindings.Add("player1_shoot_up", KeyCode.UpArrow);
        bindings.Add("player1_shoot_left", KeyCode.LeftArrow);
        bindings.Add("player1_shoot_right", KeyCode.RightArrow);
        bindings.Add("player1_shoot_down", KeyCode.DownArrow);
        bindings.Add("pause_button", KeyCode.P);
    }

    public static KeyCode GetKeyBinding(string key) {
        return bindings[key]; 
    }
    
    public static void SetKeyBinding(string key, KeyCode binding) {
        bindings.Remove(key);
        bindings.Add(key, binding);
    }
}
