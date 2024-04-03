# DecisionRules
# Overview

DecisionRules is a lightweight framework for defining and evaluating decision trees and rule sets. It provides a simple yet powerful way to encapsulate business logic and decision-making processes in a structured and maintainable manner. This framework can be used in various applications, including business process automation, data validation, and dynamic content generation.

# Features

    Rule Engine: Allows defining and evaluating rules based on context data. Each rule consists of a condition and an action, where the action is executed if the condition evaluates to true.
    Decision Tree: Supports creating and traversing decision trees, where each node represents a decision or action based on the evaluation of a condition.
    Context Management: Provides a mechanism to store and manage context data, which is used for evaluating rules and decision trees.

# Use Cases

    Business Process Automation: Automate decision-making in business workflows, such as approval processes, pricing strategies, and eligibility checks.
    Data Validation: Define rules for validating input data in forms, APIs, or data processing pipelines.
    Dynamic Content Generation: Use decision trees to dynamically generate content or recommendations based on user input or behavior.

# Getting Started

To get started with DecisionRules, you can create a new instance of the RuleSet and Tree classes and define your rules and decision nodes. Then, create a Context object to hold your data and evaluate your rules and decision trees against this context.

```cs
var ruleSet = new RuleSet();
ruleSet.AddRule(new Rule(
    ctx => ctx.GetData<int>("Age") >= 18,
    ctx => Console.WriteLine("User is an adult.")));

var context = new Context();
context.SetData("Age", 25);

var ruleEvaluator = new RuleEvaluator(ruleSet);
ruleEvaluator.Evaluate(context);
```

# Missing Features

    Rule Persistence: Currently, there is no built-in mechanism to persist rules to a database or file system.
    Complex Rule Conditions: The framework supports basic condition evaluation but lacks support for more complex logical expressions.
    Rule Prioritization: There is no way to specify the order or priority in which rules should be evaluated.

# Contributing

Contributions to the DecisionRules project are welcome. If you have ideas for new features or improvements, feel free to open an issue or submit a pull request.