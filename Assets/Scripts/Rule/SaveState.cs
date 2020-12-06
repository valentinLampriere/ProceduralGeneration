using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : Rule {
    public override void Run(Tree tree) {
        Vector v = new Vector(tree.vector.origin, tree.vector.direction);
        tree.savedVectors.Add(v);



        tree.sizeLine *= tree.lengthScaleFactor;
        tree.widthLine *= tree.widthScaleFactor;

        tree.currentLine = null;
    }

    public override char Char() {
        return '[';
    }
}
