using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : Rule {
    public override void Run(TestTree tree) {
        /*tree.vector.direction = Quaternion.Euler(0, 0, tree.angle + tree.angle * Random.Range(-tree.angle * 0.2f * tree.AleaDegree, tree.angle * 0.2f * tree.AleaDegree)) * tree.vector.direction;*/
        tree.vector.direction = Quaternion.Euler(Random.Range(-tree.angle, 0.0f), 0, Random.Range(-tree.angle, 0.0f)) * tree.vector.direction;
    }

    public override char Char() {
        return '-';
    }
}
