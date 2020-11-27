using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : Rule {
    public override void Run(TestTree tree) {
        Vector v = new Vector(tree.vector.origin, tree.vector.direction);
        tree.savedVectors.Add(v);
    }

    public override char Char() {
        return '[';
    }
}
