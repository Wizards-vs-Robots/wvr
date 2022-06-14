using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Robot;
using UnityEngine;
using UnityEngine.TestTools;

public class MinionConstellationTest
{
    [Test]
    public void TestMinionConstellation()
    {
        var manager = GameObject
                        .FindGameObjectsWithTag("WaveManager")[0]
                        .GetComponent<WaveManager>();
        manager.Start();

        List<Tuple<float, Attacker>> pattern = manager.GenerateSpawnPattern();
        int firstRobotCount = 0;
        foreach (Tuple<float, Attacker> entry in pattern) {
            Assert.IsTrue(entry.Item2.strength == 10);
            firstRobotCount++;
        }

        Assert.IsTrue(firstRobotCount == 10);
    }
}
