using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : Rule {
    public override void Run(Tree tree) {
        if (tree.savedVectors.Count == 0) return;
        Vector v = tree.savedVectors[tree.savedVectors.Count - 1];
        tree.vector = new Vector(v.origin, v.direction);
        tree.savedVectors.RemoveAt(tree.savedVectors.Count - 1);

        tree.currentLine = null;
    }

    public override char Char() {
        return ']';
    }
}
