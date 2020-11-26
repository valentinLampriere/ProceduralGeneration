using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : Rule {
    public override void Run(TestTree tree) {
        LineRenderer lr = tree.savedLine[tree.savedLine.Count - 1];
        if (lr != null) {
            tree.currentLine = tree.savedLine[tree.savedLine.Count - 1];
        }
    }

    public override string ToString() {
        return "LoadState";
    }
}
