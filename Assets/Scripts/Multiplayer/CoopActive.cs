using UnityEngine;

namespace Multiplayer
{
    public class CoopActive : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (Statics.gameMode != GameMode.LOCAL_MULTIPLAYER) this.gameObject.SetActive(false);
        }
    }
}
