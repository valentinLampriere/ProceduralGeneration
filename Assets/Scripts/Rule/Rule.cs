﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule {

    public abstract void Run(TestTree tree);
    public abstract char Char();


    public static List<Rule> GetRulesFromString(string sentence) {
        List<Rule> rules = new List<Rule>();
        foreach (char _c in sentence) {
            Rule r;
            if (TestTree.ExistingRules.ContainsKey(_c)) {
                r = TestTree.ExistingRules[_c];
            } else {
                r = new UnknownRule(_c);
                TestTree.ExistingRules[_c] = r;
            }
            rules.Add(r);
        }
        return rules;
    }


    public override string ToString() {
        return Char().ToString();
    }
}

public class UnknownRule : Rule {

    char c;

    public UnknownRule(char _c) {
        c = _c;
    }

    public override void Run(TestTree tree) {}

    public override char Char() {
        return c;
    }
}
