using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : Rule {
    public override void Run(TestTree tree) {
        tree.vector.direction = Quaternion.Euler(0, 0, 180 + tree.angle * Random.Range(-tree.angle * tree.AleaDegree, tree.angle * tree.AleaDegree)) * tree.vector.direction;
    }

    public override char Char() {
        return '+';
    }
}
