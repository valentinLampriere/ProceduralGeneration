using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSet : Dictionary<Rule, List<Rule>> {
    public void AddRule(Rule r, List<Rule> rules) {
        this.Add(r, rules);
    }

    public void AddRule(char c, string sentence) {
        Rule r;
        if (TestTree.ExistingRules.ContainsKey(c))
            r = TestTree.ExistingRules[c];
        else {
            r = new UnknownRule(c);
            TestTree.ExistingRules[c] = r;
        }
        AddRule(r, Rule.GetRulesFromString(sentence));
    }
}
