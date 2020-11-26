using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : Rule {
    public override void Run(TestTree tree) {
        Vector v = tree.savedVectors[tree.savedVectors.Count - 1];
        if (v != null) {
            tree.vector = tree.savedVectors[tree.savedVectors.Count - 1];
            tree.savedVectors.RemoveAt(tree.savedVectors.Count - 1);
        }
    }

    public override char Char() {
        return ']';
    }

    public override string ToString() {
        return "LoadState";
    }
}
