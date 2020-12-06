using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule {

    public abstract void Run(Tree tree);
    public abstract char Char();


    public static Axiom GetRulesFromString(string sentence) {
        Axiom rules = new Axiom();
        foreach (char _c in sentence) {
            Rule r;
            if (Tree.ExistingRules.ContainsKey(_c)) {
                r = Tree.ExistingRules[_c];
            } else {
                r = new UnknownRule(_c);
                Tree.ExistingRules[_c] = r;
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

    public override void Run(Tree tree) {}

    public override char Char() {
        return c;
    }
}
