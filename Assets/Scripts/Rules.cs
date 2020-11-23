using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : Dictionary<char, string> {
    public void AddRule(char c, string s) {
        this.Add(c, s);
    }
}
