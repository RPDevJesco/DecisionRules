using DecisionRules;
using NUnit.Framework.Legacy;

namespace DecisionRulesTests
{
    [TestFixture]
    public class RuleEvaluatorTests
    {
        private RuleSet CreateTestRuleSet()
        {
            return new RuleSet();
        }

        private Rule CreateTestRule(Func<Context, bool> condition, Action<Context> action)
        {
            return new Rule(condition, action);
        }

        [Test]
        public void Evaluate_ExecutesOnlyFirstMatchingRuleAction()
        {
            // Arrange
            var context = new Context();
            context.SetData("AlexFriendship", 0);
            context.SetData("JamieFriendship", 0);
            bool helpedAlex = true;
            bool spentTimeWithJamie = false;

            var ruleSet = CreateTestRuleSet();
            ruleSet.AddRule(CreateTestRule(
                ctx => helpedAlex,
                ctx => ctx.SetData("AlexFriendship", ctx.GetData<int>("AlexFriendship") + 10)));
            ruleSet.AddRule(CreateTestRule(
                ctx => spentTimeWithJamie,
                ctx => ctx.SetData("JamieFriendship", ctx.GetData<int>("JamieFriendship") + 10)));

            var evaluator = new RuleEvaluator(ruleSet);

            // Act
            evaluator.Evaluate(context);

            // Assert
            ClassicAssert.AreEqual(10, context.GetData<int>("AlexFriendship"), "AlexFriendship should be increased by 10.");
            ClassicAssert.AreEqual(0, context.GetData<int>("JamieFriendship"), "JamieFriendship should not be changed.");
        }

        [Test]
        public void Evaluate_DoesNotExecuteAnyActionIfNoConditionsMatch()
        {
            // Arrange
            var context = new Context();
            context.SetData("AlexFriendship", 0);
            context.SetData("JamieFriendship", 0);
            bool helpedAlex = false;
            bool spentTimeWithJamie = false;

            var ruleSet = CreateTestRuleSet();
            ruleSet.AddRule(CreateTestRule(
                ctx => helpedAlex,
                ctx => ctx.SetData("AlexFriendship", ctx.GetData<int>("AlexFriendship") + 10)));
            ruleSet.AddRule(CreateTestRule(
                ctx => spentTimeWithJamie,
                ctx => ctx.SetData("JamieFriendship", ctx.GetData<int>("JamieFriendship") + 10)));

            var evaluator = new RuleEvaluator(ruleSet);

            // Act
            evaluator.Evaluate(context);

            // Assert
            ClassicAssert.AreEqual(0, context.GetData<int>("AlexFriendship"), "AlexFriendship should not be changed.");
            ClassicAssert.AreEqual(0, context.GetData<int>("JamieFriendship"), "JamieFriendship should not be changed.");
        }
    }
}