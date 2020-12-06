using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Rule {

    public LineRenderer lr;


    public override void Run(Tree tree) {

        if (tree.currentLine == null)
            return;

        float x = Random.Range(0.0f, 360.0f);
        float y = Random.Range(0.0f, 360.0f);
        float z = Random.Range(0.0f, 360.0f);


        AddLeaves(tree, Quaternion.Euler(90f, 0, 0), x, y, z);
        AddLeaves(tree, Quaternion.Euler(0, 90f, 0), x, y, z);
        AddLeaves(tree, Quaternion.Euler(0, 0, 90f), x, y, z);
    }

    private void AddLeaves(Tree tree, Quaternion offset, float x, float y, float z) {
        GameObject l = GameObject.Instantiate(tree.leaves, tree.currentLine.GetPosition(tree.currentLine.positionCount - 1), Quaternion.Euler(x, y, z) * offset);
        l.transform.localScale = new Vector3(tree.sizeLine, tree.sizeLine, tree.sizeLine);
        l.transform.parent = tree.transform.GetChild(1);
    }

    public override char Char() {
        return 'F';
    }
}
