using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : Rule {
    public override void Run(TestTree tree) {
        tree.sizeLine *= 1 / tree.lengthScaleFactor;
    }

    public override char Char() {
        return '<';
    }
}
