using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : Rule {
    public override void Run(TestTree tree) {
        Vector3 origin, end, direction;

        origin = tree.currentLine.GetPosition(tree.currentLine.positionCount - 2);
        end = tree.currentLine.GetPosition(tree.currentLine.positionCount - 1);
        direction = end - origin;
        direction = Quaternion.Euler(0, 0, 90) * direction;
        tree.currentLine.SetPosition(tree.currentLine.positionCount - 1, direction + origin);
        /*
        Vector3 dir = tree.position.second - tree.position.first;
        dir = Quaternion.Euler(0, 0, 45) * dir;
        tree.position.second = dir + tree.position.first;
        */
    }

    public override string ToString() {
        return "TurnLeft";
    }
}
