using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Rule {
    public override void Run(TestTree tree) {
        tree.vector.origin = tree.vector.origin + tree.vector.direction * tree.sizeLine;
    }

    public override char Char() {
        return 'G';
    }
}
