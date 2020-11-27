﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystem {
    public static List<Rule> Iterate(RuleSet rules, List<Rule> axiom, TestTree tree) {
        List<Rule> next = new List<Rule>();
        foreach (Rule r in axiom) {
            if (rules.ContainsKey(r)) {
                foreach (Rule rn in rules[r]) {
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
