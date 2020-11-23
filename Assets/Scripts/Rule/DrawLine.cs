using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : Rule {

    public LineRenderer lr;


    public override void Run() {

        Instantiate(gameObject, TestTree.origin, Quaternion.identity);

        lr.SetPosition(0, TestTree.origin);
        lr.SetPosition(1, TestTree.end);

        TestTree.origin = TestTree.end;
    }

    public override string ToString() {
        return "DrawLine";
    }
}
