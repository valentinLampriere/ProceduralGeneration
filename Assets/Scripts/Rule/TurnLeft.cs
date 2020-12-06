using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : Rule {
    public override void Run(Tree tree) {
        tree.vector.direction = Quaternion.Euler(Random.Range(-tree.angle, 0.0f), 0, Random.Range(-tree.angle/3, 0.0f)) * tree.vector.direction;
    }

    public override char Char() {
        return '-';
    }
}
