using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystem {
    public static string Iterate(Rules rules, string axiom) {
        StringBuilder next = new StringBuilder(axiom);
        foreach (char c in axiom) {
            next.Append(rules[c]);
        }
        return next.ToString();
    }
}
