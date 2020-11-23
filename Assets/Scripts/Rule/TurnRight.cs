using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight: Rule {
    public override void Run() {
        TestTree.end = Quaternion.Euler(0, 0, -90) * TestTree.end;
    }

    public override string ToString() {
        return "TurnRight";
    }
}
