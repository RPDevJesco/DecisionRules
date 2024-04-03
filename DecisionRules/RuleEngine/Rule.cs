namespace DecisionRules
{
    /// <summary>
    /// Represents a single rule in a rule set.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Gets the condition to evaluate for this rule.
        /// </summary>
        public Func<Context, bool> Condition { get; }

        /// <summary>
        /// Gets the action to perform if the condition is true.
        /// </summary>
        public Action<Context> Action { get; }

        /// <summary>
        /// Initializes a new instance of the Rule class.
        /// </summary>
        /// <param name="condition">The condition to evaluate for this rule.</param>
        /// <param name="action">The action to perform if the condition is true.</param>
        public Rule(Func<Context, bool> condition, Action<Context> action)
        {
            Condition = condition;
            Action = action;
        }

        /// <summary>
        /// Evaluates the rule's condition in the given context.
        /// </summary>
        /// <param name="context">The context in which to evaluate the rule.</param>
        /// <returns>True if the condition is true, false otherwise.</returns>
        public bool Evaluate(Context context) => Condition(context);
    }
}