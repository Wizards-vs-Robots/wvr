using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Robot;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class ParameterGrowthTest
{
    [Test]
    public void TestParameterGrowth()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");

        float eta = 10e-4F;
        float[] cooldowns = new float[3]{1F, 0.9950125F, 0.9900498F};
        float[] durations = new float[3]{5F, 4.900993F, 4.803947F};
        float[] strengths = new float[3]{100F, 104.0811F, 108.3287F};
        var manager = GameObject
                        .FindGameObjectsWithTag("WaveManager")[0]
                        .GetComponent<WaveManager>();
        manager.cooldown = 1F;
        manager.duration = 5F;
        manager.strength = 100F;
        manager.wave = 1;

        for (int i = 0; i < 3; i++) {
            Assert.IsTrue(Mathf.Abs(manager.cooldown - cooldowns[i]) < eta);
            Assert.IsTrue(Mathf.Abs(manager.duration - durations[i]) < eta);
            Assert.IsTrue(Mathf.Abs(manager.strength - strengths[i]) < eta);

            manager.wave += 1;
            manager.Strengthen();
        }
    }
}
