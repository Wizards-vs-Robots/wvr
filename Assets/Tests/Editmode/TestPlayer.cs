using NUnit.Framework;
using UnityEngine;

namespace Tests.Editmode
{
    public class TestMovement
    {
        [Test]
        public void TestManaUse()
        {
            GameObject gameObject = new GameObject();
            var manaModel = gameObject.AddComponent<ManaModel>();
            manaModel.maxManaPoints = 100;
            manaModel.currentManaPoints = 100;
            manaModel.Use(10);
            Assert.AreEqual(90, manaModel.currentManaPoints);
        }

        [Test]
        public void TestPlayerMovement()
        {
            //TODO
        }
    }
}
