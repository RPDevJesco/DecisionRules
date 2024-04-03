using DecisionRules;

namespace DecisionRulesTests
{
    [TestFixture]
    public class RuleSetTests
    {
        private Rule CreateTestRule(Func<Context, bool> condition, Action<Context> action)
        {
            return new Rule(condition, action, priority: 1); // Assuming Rule has a constructor that accepts a condition, an action, and a priority.
        }

        [Test]
        public void AddRule_AddsRuleToRuleSet()
        {
            // Arrange
            var ruleSet = new RuleSet();
            var rule = CreateTestRule(ctx => true, ctx => { });

            // Act
            ruleSet.AddRule(rule);

            // Assert
            Assert.That(ruleSet.Rules.Contains(rule), "The rule should be added to the rule set.");
        }

        [Test]
        public void Rules_ReturnsAllAddedRules()
        {
            // Arrange
            var ruleSet = new RuleSet();
            var rule1 = CreateTestRule(ctx => true, ctx => { });
            var rule2 = CreateTestRule(ctx => false, ctx => { });

            // Act
            ruleSet.AddRule(rule1);
            ruleSet.AddRule(rule2);

            // Assert
            Assert.That(ruleSet.Rules.Contains(rule1), "The rule set should contain the first added rule.");
            Assert.That(ruleSet.Rules.Contains(rule2), "The rule set should contain the second added rule.");
        }

        [Test]
        public void Rules_ReturnsReadOnlyCollection()
        {
            // Arrange
            var ruleSet = new RuleSet();
            var rule = CreateTestRule(ctx => true, ctx => { });
            ruleSet.AddRule(rule);

            // Act
            var rules = ruleSet.Rules;

            // Assert
            Assert.Throws<NotSupportedException>(() => (rules as System.Collections.IList).Add(CreateTestRule(ctx => false, ctx => { })), "The rules collection should be read-only.");
        }
    }
}