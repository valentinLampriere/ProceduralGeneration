using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : Rule {
    public override void Run(TestTree tree) {
        tree.savedLine.Add(tree.currentLine);
        tree.currentLine = tree.createNewLine(tree.currentLine);
    }

    public override string ToString() {
        return "SaveState";
    }
}
