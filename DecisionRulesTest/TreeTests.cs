using DecisionRules;
using NUnit.Framework.Legacy;

namespace DecisionRulesTests
{
    [TestFixture]
    public class TreeTests
    {
        private Node CreateTestNode(Func<Context, bool> condition = null, Action<Context> action = null)
        {
            return new Node(condition, action);
        }

        [Test]
        public void Tree_Instantiation_WithValidRootNode()
        {
            // Arrange
            var rootNode = CreateTestNode();

            // Act
            var tree = new Tree(rootNode);

            // Assert
            Assert.That(tree.Root, Is.EqualTo(rootNode), "Root property should match the provided root node.");
        }

        [Test]
        public void Traverse_ExecutesAction_WhenConditionIsNull()
        {
            // Arrange
            bool actionExecuted = false;
            var rootNode = CreateTestNode(action: ctx => { actionExecuted = true; });
            var tree = new Tree(rootNode);
            var context = new Context(); // Assuming Context is a valid class in your project

            // Act
            tree.Traverse(context);

            // Assert
            ClassicAssert.IsTrue(actionExecuted, "Action should be executed when the condition is null.");
        }

        [Test]
        public void Traverse_ExecutesAction_WhenConditionIsTrue()
        {
            // Arrange
            bool actionExecuted = false;
            var rootNode = CreateTestNode(condition: ctx => true, action: ctx => { actionExecuted = true; });
            var tree = new Tree(rootNode);
            var context = new Context(); // Assuming Context is a valid class in your project

            // Act
            tree.Traverse(context);

            // Assert
            ClassicAssert.IsTrue(actionExecuted, "Action should be executed when the condition is true.");
        }

        [Test]
        public void Traverse_DoesNotExecuteAction_WhenConditionIsFalse()
        {
            // Arrange
            bool actionExecuted = false;
            var rootNode = CreateTestNode(condition: ctx => false, action: ctx => { actionExecuted = true; });
            var tree = new Tree(rootNode);
            var context = new Context(); // Assuming Context is a valid class in your project

            // Act
            tree.Traverse(context);

            // Assert
            ClassicAssert.IsFalse(actionExecuted, "Action should not be executed when the condition is false.");
        }

        // Additional tests can be written to verify traversal through child nodes,
        // handling of multiple child nodes, and correct application of conditions and actions.
    }
}