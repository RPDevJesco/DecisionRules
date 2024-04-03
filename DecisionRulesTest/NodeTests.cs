using DecisionRules;

namespace DecisionRulesTests
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void Node_Instantiation_WithNoArguments()
        {
            var node = new Node();
    
            // Using the Constraint Model to assert that the Condition delegate is null
            Assert.That(node.Condition, Is.Null, "Condition should be null upon instantiation.");
    
            // Using the Constraint Model to assert that the Action delegate is null
            Assert.That(node.Action, Is.Null, "Action should be null upon instantiation.");
    
            // Asserting that the Children collection is empty
            Assert.That(node.Children, Is.Empty, "Children collection should be empty upon instantiation.");
        }

        [Test]
        public void Node_AddChild_AddsSuccessfully()
        {
            var parentNode = new Node();
            var childNode = new Node();

            parentNode.AddChild(childNode);

            Assert.That(parentNode.Children, Is.Not.Empty);
            Assert.That(parentNode.Children.Count, Is.EqualTo(1));
            Assert.That(parentNode.Children[0], Is.SameAs(childNode));
        }

        [Test]
        public void Node_EvaluateConditionAndExecuteAction_Success()
        {
            bool conditionMet = false;
            var node = new Node(
                condition: ctx => ctx.GetData<int>("Age") > 10, // Ensure Context has a SomeValue property
                action: ctx => { conditionMet = true; }
            );

            var context = new Context(); // Assuming Context class has a SomeValue property
            context.SetData("Age", 25);
            bool result = node.Condition(context);

            if (result)
            {
                node.Action(context);
            }

            Assert.That(result, Is.True);
            Assert.That(conditionMet, Is.True);
        }
    }
}