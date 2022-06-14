using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Robot;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MinionConstellationTest
{
    [Test]
    public void TestMinionConstellation()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");
        
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
