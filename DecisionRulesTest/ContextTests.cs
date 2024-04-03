using DecisionRules;
using NUnit.Framework.Legacy;

namespace DecisionRulesTests
{
    [TestFixture]
    public class ContextTests
    {
        [Test]
        public void SetData_AddsOrUpdateDataByKey()
        {
            // Arrange
            var context = new Context();
            string key = "testKey";
            object value = "testValue";

            // Act
            context.SetData(key, value);

            // Assert
            ClassicAssert.IsTrue(context.ContainsKey(key), "The key should exist in the context.");
            ClassicAssert.AreEqual(value, context.GetData(key), "The value should match the set value.");
        }

        [Test]
        public void GetData_RetrievesDataByKey()
        {
            // Arrange
            var context = new Context();
            string key = "testKey";
            object value = "testValue";
            context.SetData(key, value);

            // Act
            var retrievedValue = context.GetData(key);

            // Assert
            ClassicAssert.AreEqual(value, retrievedValue, "The retrieved value should match the set value.");
        }

        [Test]
        public void GetData_Typed_RetrievesTypedDataByKey()
        {
            // Arrange
            var context = new Context();
            string key = "testKey";
            int value = 42;
            context.SetData(key, value);

            // Act
            var retrievedValue = context.GetData<int>(key);

            // Assert
            ClassicAssert.AreEqual(value, retrievedValue);
        }

        [Test]
        public void ContainsKey_ChecksForKeyExistence()
        {
            // Arrange
            var context = new Context();
            string key = "testKey";
            context.SetData(key, "testValue");

            // Act & Assert
            ClassicAssert.IsTrue(context.ContainsKey(key), "The context should contain the key.");
            ClassicAssert.IsFalse(context.ContainsKey("nonexistentKey"), "The context should not contain a nonexistent key.");
        }

        [Test]
        public void RemoveData_RemovesDataByKey()
        {
            // Arrange
            var context = new Context();
            string key = "testKey";
            context.SetData(key, "testValue");

            // Act
            bool removed = context.RemoveData(key);

            // Assert
            ClassicAssert.IsTrue(removed, "The data should be removed.");
            ClassicAssert.IsFalse(context.ContainsKey(key), "The key should no longer exist in the context.");
        }

        [Test]
        public void Clear_RemovesAllData()
        {
            // Arrange
            var context = new Context();
            context.SetData("key1", "value1");
            context.SetData("key2", "value2");

            // Act
            context.Clear();

            // Assert
            ClassicAssert.IsFalse(context.ContainsKey("key1"), "The context should be cleared of all data.");
            ClassicAssert.IsFalse(context.ContainsKey("key2"), "The context should be cleared of all data.");
        }
    }
}