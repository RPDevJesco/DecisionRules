namespace DecisionRules
{
    /// <summary>
    /// Responsible for evaluating a set of rules in a given context.
    /// </summary>
    public class RuleEvaluator
    {
        /// <summary>
        /// The set of rules to be evaluated.
        /// </summary>
        private readonly RuleSet ruleSet;

        /// <summary>
        /// Initializes a new instance of the RuleEvaluator class.
        /// </summary>
        /// <param name="ruleSet">The set of rules to be evaluated.</param>
        public RuleEvaluator(RuleSet ruleSet)
        {
            this.ruleSet = ruleSet;
        }

        /// <summary>
        /// Evaluates the rules in the rule set against the given context.
        /// </summary>
        /// <param name="context">The context in which to evaluate the rules.</param>
        public void Evaluate(Context context)
        {
            // Sort rules by priority before evaluation
            var sortedRules = ruleSet.Rules.OrderBy(r => r.Priority).ToList();

            // Iterate through each rule in the rule set
            foreach (var rule in sortedRules)
            {
                // If the rule's condition evaluates to true, execute its action and stop processing further rules
                if (rule.Evaluate(context))
                {
                    rule.Action(context);
                    break;
                }
            }
        }
    }
}