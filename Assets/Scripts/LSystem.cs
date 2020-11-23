using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystem {
    public static List<Rule> Iterate(Rules rules, List<Rule> axiom) {
        List<Rule> next = new List<Rule>();

        Debug.Log(TestTree.iteration++);
        foreach(Rule r in axiom) {
            foreach (Rule rn in rules[r]) {
                next.Add(rn);

                rn.Run();
            }
            Debug.Log(r);
        }
        return next;
    }
}
