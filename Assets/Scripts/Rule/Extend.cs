using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : Rule {
    public override void Run(TestTree tree) {
        Vector v = new Vector(tree.vector.origin, tree.vector.direction);
        tree.sizeLine *= tree.lengthScaleFactor;
    }

    public override char Char() {
        return '>';
    }
}
