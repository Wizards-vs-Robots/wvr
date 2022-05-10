using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Statics.gameMode != Statics.GameMode.LOCAL_MULTIPLAYER) this.gameObject.SetActive(false);
    }
}
