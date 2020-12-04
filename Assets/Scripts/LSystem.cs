using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystem {

    public static Axiom Iterate(RuleSet rules, List<Rule> axiom, TestTree tree) {
        Axiom next = new Axiom();

        foreach (Rule r in axiom) {
            /*if (tree.buffers.Count == 0) {
                if (rules.ContainsKey(r)) {
                    foreach (Rule rn in rules[r]) {
                        next.Add(rn);
                        rn.Run(tree);
                    }
                } else {
                    next.Add(r);
                    r.Run(tree);
                }
                TryAddRules(rules, next, tree, r);
            } else {
                TryAddRules(rules, next, tree, r, false);
            }*/
            if (tree.buffers.Count == 0) {
                TryAddRules(rules, next, tree, r, tree.shouldRunStatement);
            } else {
                TryAddRules(rules, tree.buffers[tree.buffers.Count - 1], tree, r, tree.shouldRunStatement);
                //tree.buffers[tree.buffers.Count - 1], tree, r, tree.shouldRunStatement);
            }
        }
        return next;
    }
    private static void TryAddRules(RuleSet rules, Axiom next, TestTree tree, Rule r, bool shouldRun = true) {
        if (rules.ContainsKey(r)) {
            foreach (Rule rn in rules[r]) {
                next.Add(rn);
                rn.PreRun(tree);
                if (shouldRun)
                    rn.Run(tree);
            }
        } else {
            next.Add(r);
            r.PreRun(tree);
            if (shouldRun)
                r.Run(tree);
        }
    }
}
