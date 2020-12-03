using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchUp : Rule {
    public override void Run(TestTree tree) {
        //if (tree.enableAlea) {
            tree.vector.direction = Quaternion.Euler(-tree.angle + tree.angle * Random.Range(-tree.angle * 0.2f * tree.AleaDegree, tree.angle * 0.2f * tree.AleaDegree), 0, 0) * tree.vector.direction;
        //} else {
        //    tree.vector.direction = Quaternion.Euler(0, 0, tree.angle) * tree.vector.direction;
        //}
    }

    public override char Char() {
        return '^';
    }
}
