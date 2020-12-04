using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuffer : Rule {

    public override void Run(TestTree tree) {
        tree.buffers.Add(new Axiom());
        tree.shouldRunStatement = false;
    }

    public override char Char() {
        return '(';
    }
}
