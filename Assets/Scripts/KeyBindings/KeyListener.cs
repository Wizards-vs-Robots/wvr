using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * listens to all keys and stores which got pressed last.
 * Use carefully, should not take to much performence but still has > 200 listeners
 * Should only be active in pause menu
 */
public class KeyListener : MonoBehaviour
{
    private int[] values;
    private KeyCode lastPressed;
 
    void Awake()
    {
        values = (int[]) System.Enum.GetValues(typeof(KeyCode)); // der BS könnte noch spez. oder erweitert werden
    }
 
    void Update() {
        for (int i = 0; i < values.Length; i++)
        {
            if (Input.GetKey((KeyCode) values[i]))
            {
                lastPressed = (KeyCode) values[i];
            }
        }
    }

    public KeyCode getLastPressed()
    {
        return lastPressed;
    }
}
