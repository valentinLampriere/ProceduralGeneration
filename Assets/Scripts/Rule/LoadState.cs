using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : Rule {
    public override void Run(TestTree tree) {
        if (tree.savedVectors.Count == 0) return;
        Vector v = tree.savedVectors[tree.savedVectors.Count - 1];
        tree.vector = new Vector(v.origin, v.direction);
        tree.savedVectors.RemoveAt(tree.savedVectors.Count - 1);
        /*if (tree.savedLine.Count == 0) return;
        int index = tree.savedLine.Count - 1;
        tree.currentLine = tree.savedLine[index];
        tree.savedLine.RemoveAt(index);*/
        tree.currentLine = null;
    }

    public override char Char() {
        return ']';
    }
}
