namespace DecisionRules
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class RuleSet
    {
        /// <summary>
        /// The list of rules in the rule set.
        /// </summary>
        private readonly List<Rule> rules = new List<Rule>();

        /// <summary>
        /// Adds a rule to the rule set.
        /// </summary>
        /// <param name="rule">The rule to add.</param>
        public void AddRule(Rule rule) => rules.Add(rule);

        /// <summary>
        /// Gets an enumerable of the rules in the rule set.
        /// </summary>
        public IEnumerable<Rule> Rules => rules.AsReadOnly();
    }
}