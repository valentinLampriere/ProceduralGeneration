using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : Dictionary<Rule, List<Rule>> {
    public void AddRule(Rule r, List<Rule> rules) {
        this.Add(r, rules);
    }
}
