using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : Rule {
    public override void Run() {
        Vector3 dir = TestTree.end - TestTree.origin;
        dir = Quaternion.Euler(0, 0, 45) * dir;
        TestTree.end = dir + TestTree.origin;
    }

    public override string ToString() {
        return "TurnLeft";
    }
}
