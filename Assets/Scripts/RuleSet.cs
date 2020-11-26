using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSet : Dictionary<Rule, List<Rule>> {
    public void AddRule(Rule r, List<Rule> rules) {
        this.Add(r, rules);
    }

    public void AddRule(char c, string sentence) {
        AddRule(TestTree.ExistingRules[c], Rule.GetRulesFromString(sentence));
    }
}
