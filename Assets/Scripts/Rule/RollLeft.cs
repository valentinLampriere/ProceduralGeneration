using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLeft : Rule {
    public override void Run(TestTree tree) {
        //if (tree.enableAlea) {
            tree.vector.direction = Quaternion.Euler(0, tree.angle + tree.angle * Random.Range(-tree.angle * tree.AleaDegree, tree.angle * tree.AleaDegree), 0) * tree.vector.direction;
        //} else {
        //    tree.vector.direction = Quaternion.Euler(0, 0, -tree.angle) * tree.vector.direction;
        //}
    }

    public override char Char() {
        return '\\';
    }
}
