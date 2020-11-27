using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : Rule {
    public override void Run(TestTree tree) {
        tree.vector.direction = Quaternion.Euler(0, 0, tree.angle) * tree.vector.direction;
    }

    public override char Char() {
        return '-';
    }
}
