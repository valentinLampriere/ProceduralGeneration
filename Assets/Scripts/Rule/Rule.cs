using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule {

    public abstract void Run(TestTree tree);
    public abstract char Char();


    public static List<Rule> GetRulesFromString(string sentence) {
        List<Rule> rules = new List<Rule>();
        foreach (char _c in sentence) {
            if (TestTree.ExistingRules.ContainsKey(_c)) {
                Rule r = TestTree.ExistingRules[_c];
                if (r != null) {
                    rules.Add(r);
                }
            }
        }
        return rules;
    }


    public override string ToString() {
        return Char().ToString();
    }
}
