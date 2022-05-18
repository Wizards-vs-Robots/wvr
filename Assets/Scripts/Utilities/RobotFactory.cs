using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;

public class RobotFactory : MonoBehaviour
{
    public static GameObject make(GameObject corpus, Vector3 offset, WaveManager manager)
    {
        // Generate robot instance
        GameObject robot = Instantiate(corpus, offset, Quaternion.identity);
        
        // Define targets 
        EnemyAggro aggro = robot.GetComponent<EnemyAggro>();
        aggro.AddPossibleTarget(manager.mainPlayer);

        if (Statics.gameMode == GameMode.LOCAL_MULTIPLAYER)
        {
            aggro.AddPossibleTarget(manager.coopPlayer);
        }

        return robot;
    }
}
