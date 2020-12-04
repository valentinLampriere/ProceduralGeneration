using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axiom : List<Rule> {
    public override string ToString() {
        string s = "";
        if (this.Count == 0)
            return "Empty Axiom";
        foreach (var item in this) {
            s += item.ToString();
        }
        return s;
    }
}
