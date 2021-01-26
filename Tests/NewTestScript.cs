using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
             Assert.IsTrue(1,1);
        }
     
    }
}
