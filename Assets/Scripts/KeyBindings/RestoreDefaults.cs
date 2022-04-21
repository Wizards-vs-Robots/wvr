using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreDefaults : MonoBehaviour
{
    public void Restore()
    {
        StoreKeyBindings.RestoreDefaults();
    }
}
