using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class Testtest
{
    
    [UnityTest]
    public IEnumerator TesttestWithEnumeratorPasses()
    {
        GameObject gameObject= new GameObject();
        var wavemanager = gameObject.AddComponent<WaveManager>();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        MethodInfo methodInfo = typeof(WaveManager).GetMethod("Strengthen()");
        float strengthBefore = wavemanager.strength;
        methodInfo.Invoke(wavemanager, null);
        yield return new WaitForSeconds(1);
        Assert.GreaterOrEqual(strengthBefore,wavemanager.strength);
        
    }
}
