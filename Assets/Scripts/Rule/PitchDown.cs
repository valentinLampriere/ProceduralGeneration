using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchDown   : Rule {
    public override void Run(Tree tree) {
        tree.vector.direction = Quaternion.Euler(Random.Range(0.0f, -tree.angle/3), 0, Random.Range(0.0f, -tree.angle)) * tree.vector.direction;

    }

    public override char Char() {
        return '&';
    }
}
