using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystem {
    public static Axiom Iterate(List<Rule> axiom, TestTree tree) {
        Axiom next = new Axiom();
        foreach (Rule r in axiom) {
            int roll = Random.Range(0, tree.allRules.Count);
            if (tree.allRules[roll].ContainsKey(r)) {
                foreach (Rule rn in tree.allRules[roll][r]) {
                    next.Add(rn);
                    rn.Run(tree);
                }
            } else {
                next.Add(r);
                r.Run(tree);
            }
        }

        return next;
    }
}
