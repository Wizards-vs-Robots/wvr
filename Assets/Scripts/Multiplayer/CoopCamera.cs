using System;
using UnityEngine;

namespace Multiplayer
{
    public class CoopCamera : MonoBehaviour
    {
        public GameObject mainPlayer;
        public GameObject coopPlayer;

        public void Start()
        {
            if (Statics.gameMode == GameMode.SINGLEPLAYER)
            {
                this.gameObject.transform.parent = mainPlayer.transform;
            }
        }

        public void Update()
        {
            if (Statics.gameMode != GameMode.LOCAL_MULTIPLAYER) return;
            
            SetCameraToMiddle();
        }

        private void SetCameraToMiddle()
        {
            var mainPos = mainPlayer.transform.position;
            var diff = coopPlayer.transform.position - mainPos;
            var plane = 0.5f * diff + mainPos ;
            transform.position = new Vector3(plane.x, plane.y, transform.position.z);
        }
    }
}