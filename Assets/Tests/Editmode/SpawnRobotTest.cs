using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Robot;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnRobotTest
{
    [Test]
    public void TestSpawnRobot()
    {
        var manager = GameObject
                        .FindGameObjectsWithTag("WaveManager")[0]
                        .GetComponent<WaveManager>();
        manager.Start();

        // Spawn attacker
        var spawnVector = new Vector3(0F, 0F, 0F);
        var firstAttacker = manager.attackers[0];
        manager.Spawn(firstAttacker, spawnVector);

        // Retrieve instance
        var attackerInstance = manager.minions[0];
        var difVector = attackerInstance.transform.position - spawnVector;
        var distance = difVector.magnitude;

        // Check if in valid range
        Assert.IsTrue(distance >= WaveManager.MIN_SPAWN_RADIUS &&
                      distance <= WaveManager.MAX_SPAWN_RADIUS);
    }
}
