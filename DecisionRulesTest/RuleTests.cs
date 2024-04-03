using DecisionRules;

namespace DecisionRulesTests
{
    [TestFixture]
    public class RuleTests
    {
        [Test]
        public void Rule_Instantiation_WithValidParameters()
        {
            // Arrange
            Func<Context, bool> condition = ctx => true;
            Action<Context> action = ctx => { };
            int priority = 1;

            // Act
            var rule = new Rule(condition, action, priority);

            // Assert
            Assert.That(rule.Condition, Is.EqualTo(condition), "Condition property should match the provided condition delegate.");
            Assert.That(rule.Action, Is.EqualTo(action), "Action property should match the provided action delegate.");
            Assert.That(rule.Priority, Is.EqualTo(priority), "Priority property should match the provided priority value.");
        }

        [Test]
        public void Evaluate_ReturnsTrue_WhenConditionIsTrue()
        {
            // Arrange
            Context context = new Context(); // Assuming Context is a valid class in your project
            Func<Context, bool> condition = ctx => true;
            var rule = new Rule(condition, action: ctx => { });

            // Act
            bool result = rule.Evaluate(context);

            // Assert
            Assert.That(result, Is.True, "Evaluate should return true when the condition delegate returns true.");
        }

        [Test]
        public void Evaluate_ReturnsFalse_WhenConditionIsFalse()
        {
            // Arrange
            Context context = new Context(); // Assuming Context is a valid class in your project
            Func<Context, bool> condition = ctx => false;
            var rule = new Rule(condition, action: ctx => { });

            // Act
            bool result = rule.Evaluate(context);

            // Assert
            Assert.That(result, Is.False, "Evaluate should return false when the condition delegate returns false.");
        }
    }
}