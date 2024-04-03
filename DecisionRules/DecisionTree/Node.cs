namespace DecisionRules
{
    /// <summary>
    /// Represents a node in a decision tree.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets the condition to evaluate at this node.
        /// </summary>
        public Func<Context, bool> Condition { get; }

        /// <summary>
        /// Gets the action to perform if the condition is true.
        /// </summary>
        public Action<Context> Action { get; }

        /// <summary>
        /// Gets the list of child nodes.
        /// </summary>
        public List<Node> Children { get; } = new List<Node>();

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="condition">The condition to evaluate at this node.</param>
        /// <param name="action">The action to perform if the condition is true.</param>
        public Node(Func<Context, bool> condition = null, Action<Context> action = null)
        {
            Condition = condition;
            Action = action;
        }

        /// <summary>
        /// Adds a child node to this node.
        /// </summary>
        /// <param name="node">The child node to add.</param>
        public void AddChild(Node node) => Children.Add(node);
    }
}