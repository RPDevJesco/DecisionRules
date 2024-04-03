namespace DecisionRules
{
    // Context, Rule, RuleSet, RuleEvaluator, Node, and Tree classes remain the same as previously defined.

    public class Program
    {
        public static void Main()
        {
            VisualNovelExample();
        }

        public static void VisualNovelExample()
        {
            bool helpedAlex = false;
            bool spentTimeWithJamie = false;
            var context = new Context();
            context.SetData("AlexFriendship", 0);
            context.SetData("JamieFriendship", 0);

            // Example player choices
            Random rand = new Random();

            if (rand.Next(0, 100) >= 49)
            {
                helpedAlex = true;
                spentTimeWithJamie = false;
            }
            else
            {
                helpedAlex = false;
                spentTimeWithJamie = true;
            }

            // Rule Engine Phase: Apply early game choices
            var ruleSet = new RuleSet();
            ruleSet.AddRule(new Rule(
                ctx => helpedAlex,
                ctx => ctx.SetData("AlexFriendship", ctx.GetData<int>("AlexFriendship") + 10)));
            ruleSet.AddRule(new Rule(
                ctx => spentTimeWithJamie,
                ctx => ctx.SetData("JamieFriendship", ctx.GetData<int>("JamieFriendship") + 10)));

            var ruleEvaluator = new RuleEvaluator(ruleSet);
            ruleEvaluator.Evaluate(context);

            // Decision Tree Phase: Navigate story branches
            var rootNode = new Node();

            var alexStoryNode = new Node(
                ctx => ctx.GetData<int>("AlexFriendship") > 5,
                ctx => Console.WriteLine("Proceeding with Alex's storyline."));
            rootNode.AddChild(alexStoryNode);

            var jamieStoryNode = new Node(
                ctx => ctx.GetData<int>("JamieFriendship") > 5,
                ctx => Console.WriteLine("Proceeding with Jamie's storyline."));
            rootNode.AddChild(jamieStoryNode);

            var neutralStoryNode = new Node(
                ctx => true, // This ensures that if no other conditions are met, the neutral path is chosen
                ctx => Console.WriteLine("Proceeding with the neutral storyline."));
            rootNode.AddChild(neutralStoryNode);

            var tree = new Tree(rootNode);
            tree.Traverse(context);
        }
        
        public static void CreditExample()
        {
            var context = new Context();
            context.SetData("Age", 25);
            context.SetData("MonthlyIncome", 3500);
            context.SetData("CreditScore", 720);
            context.SetData("LoanAmount", 95000);

            // Rule Engine Phase
            var ruleSet = new RuleSet();
            ruleSet.AddRule(new Rule(
                ctx => ctx.GetData<int>("Age") >= 18,
                ctx => Console.WriteLine("Applicant meets the age requirement.")));
            ruleSet.AddRule(new Rule(
                ctx => ctx.GetData<int>("MonthlyIncome") >= 3000,
                ctx => Console.WriteLine("Applicant meets the income requirement.")));

            var ruleEvaluator = new RuleEvaluator(ruleSet);
            ruleEvaluator.Evaluate(context);

            // Decision Tree Phase
            var rootNode = new Node(
                ctx => true, // Always true for the root node
                null); // No action at the root

            var creditScoreNode = new Node(
                ctx => ctx.GetData<int>("CreditScore") > 700,
                ctx => Console.WriteLine("Applicant has a good credit score."));
            rootNode.AddChild(creditScoreNode);

            var loanAmountNode = new Node(
                ctx => ctx.GetData<int>("LoanAmount") <= 100000,
                ctx => Console.WriteLine("Loan amount is within acceptable limits."));
            creditScoreNode.AddChild(loanAmountNode);

            var rejectNode = new Node(
                ctx => ctx.GetData<int>("LoanAmount") > 100000,
                ctx => Console.WriteLine("Loan amount exceeds the acceptable limits."));
            rootNode.AddChild(rejectNode); // This node is directly added to the root for simplicity

            var tree = new Tree(rootNode);
            tree.Traverse(context);
        }
    }
}