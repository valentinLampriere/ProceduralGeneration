using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : Rule {
    public override void Run(TestTree tree) {
        tree.savedVectors.Add(tree.vector);
    }

    public override char Char() {
        return '[';
    }

    public override string ToString() {
        return "SaveState";
    }
}
