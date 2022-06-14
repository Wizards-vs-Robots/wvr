using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Robot;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class ReportDeathTest
{
    [Test]
    public void TestDeathAlreadyReported()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");

        Statics.Initialize();
        var manager = GameObject
                        .FindGameObjectsWithTag("WaveManager")[0]
                        .GetComponent<WaveManager>();
        manager.Start();

        // Simulate spawning
        var spawnVector = new Vector3(0F, 0F, 0F);
        var firstAttacker = manager.attackers[0];
        manager.Spawn(firstAttacker, spawnVector);

        // Take first minion
        var firstMinion = manager.minions[0];
        var strength = (int) firstMinion.GetComponent<Attacker>().GetStrength();

        // Report death first time
        var sizeBefore = manager.minions.Count;
        manager.ReportDeath(firstMinion);
        var currentSize = manager.minions.Count;

        // Assert functioning first report
        Assert.IsTrue(currentSize < sizeBefore);
        Assert.IsTrue(Statics.GetScoreModel().GetScore() == strength);

        // Report death as second time (should be ignored)
        sizeBefore = currentSize;
        manager.ReportDeath(firstMinion);
        currentSize = manager.minions.Count;

        // Assert ignored death report
        Assert.IsTrue(currentSize == sizeBefore);
        Assert.IsTrue(Statics.GetScoreModel().GetScore() == strength);
    }
}
