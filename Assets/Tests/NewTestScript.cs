using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method

        public GameObject gameobbject;

        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
            gameobbject = new GameObject("Name");
            gameobbject.AddComponent<Orbit_Behaviour>();
            Assert.True(true);
            Object.Destroy(gameobbject);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
