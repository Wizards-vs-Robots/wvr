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
                bindings.Add("player1_change_spell", KeyCode.E);
                bindings.Add("player1_shoot_up", KeyCode.F);
                bindings.Add("player1_shoot_left", KeyCode.C);
                bindings.Add("player1_shoot_right", KeyCode.B);
                bindings.Add("player1_shoot_down", KeyCode.V);
                bindings.Add("player1_cooldown_action", KeyCode.X);
                bindings.Add("pause_button", KeyCode.P);


                // player 2
                bindings.Add("player2_move_up", KeyCode.Semicolon);
                bindings.Add("player2_move_left", KeyCode.BackQuote);
                bindings.Add("player2_move_right", KeyCode.Quote);
                bindings.Add("player2_move_down", KeyCode.Slash);
                bindings.Add("player2_change_spell", KeyCode.Equals);
                bindings.Add("player2_shoot_up", KeyCode.UpArrow);
                bindings.Add("player2_shoot_left", KeyCode.LeftArrow);
                bindings.Add("player2_shoot_right", KeyCode.RightArrow);
                bindings.Add("player2_shoot_down", KeyCode.DownArrow);
                bindings.Add("player2_cooldown_action", KeyCode.Minus);
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
