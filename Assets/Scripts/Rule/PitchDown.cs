using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchDown   : Rule {
    public override void Run(TestTree tree) {
        //tree.vector.direction = Quaternion.Euler(tree.angle + tree.angle * Random.Range(-tree.angle * 0.2f * tree.AleaDegree, tree.angle * 0.2f * tree.AleaDegree), 0, 0) * tree.vector.direction;
        tree.vector.direction = Quaternion.Euler(Random.Range(0.0f, tree.angle/3), 0, Random.Range(0.0f, tree.angle)) * tree.vector.direction;

    }

    public override char Char() {
        return '&';
    }
}
