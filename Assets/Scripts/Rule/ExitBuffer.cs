using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBuffer : Rule {
    public override void PreRun(TestTree tree) {
        if (tree.buffers.Count == 0) return;
        int index = tree.buffers.Count - 1;
        tree.shouldRunStatement = true;
        // Remove the last rule (the ")" character)
        //tree.buffers[index].Remove(this);
        tree.buffers[index].RemoveAt(tree.buffers[index].Count - 1);
        Debug.Log("ExitBuffer :");
        Debug.Log(tree.buffers[index]);
        //LSystem.Iterate(tree.rules, tree.buffers[index], tree);
        tree.buffers.RemoveAt(index);
    }
    public override void Run(TestTree tree) {
    }

    public override char Char() {
        return ')';
    }
}
