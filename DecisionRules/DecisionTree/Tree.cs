namespace DecisionRules
{
    /// <summary>
    /// Represents a decision tree.
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Gets the root node of the tree.
        /// </summary>
        public Node Root { get; }

        /// <summary>
        /// Initializes a new instance of the Tree class.
        /// </summary>
        /// <param name="root">The root node of the tree.</param>
        public Tree(Node root)
        {
            Root = root;
        }

        /// <summary>
        /// Traverses the tree, starting from the specified node or the root node if no node is specified.
        /// </summary>
        /// <param name="context">The context used for evaluating conditions and executing actions.</param>
        /// <param name="node">The node from which to start traversing. If null, traversal starts from the root node.</param>
        public void Traverse(Context context, Node node = null)
        {
            node ??= Root; // Use the root node if no node is specified

            // Evaluate the node's condition, if any, and execute its action if the condition is true
            if (node.Condition == null || node.Condition(context))
            {
                node.Action?.Invoke(context);
                // Recursively traverse each child node
                foreach (var child in node.Children)
                {
                    Traverse(context, child);
                }
            }
        }
    }
}