using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Rule {
    public override void Run(TestTree tree) {
        /*Vector3 origin, end, direction;

        origin = tree.position.second;
        direction = (tree.position.second - tree.position.first).normalized;
        end = origin + direction * tree.sizeLine;
        tree.position.first = origin;
        tree.position.second = end;
        */
    }

    public override string ToString() {
        return "MoveForward";
    }
}
