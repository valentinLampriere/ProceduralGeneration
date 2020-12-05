using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : Rule {
    public override void Run(TestTree tree) {
        Vector v = new Vector(tree.vector.origin, tree.vector.direction);
        tree.savedVectors.Add(v);



        tree.sizeLine *= tree.lengthScaleFactor;
        tree.widthLine *= tree.widthScaleFactor;
        /*GameObject line = new GameObject();
        line.transform.parent = GameObject.Find("TestTree").transform;
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.positionCount = tree.currentLine.positionCount;
        Vector3[] positions = new Vector3[tree.currentLine.positionCount];
        tree.currentLine.GetPositions(positions);
        lr.SetPositions(positions);
        lr.material = tree.currentLine.material;
        lr.startColor = tree.currentLine.startColor;
        lr.endColor = tree.currentLine.endColor;
        lr.startWidth = tree.currentLine.startWidth;
        lr.endWidth = tree.currentLine.endWidth;
        tree.savedLine.Add(tree.currentLine);*/
        tree.currentLine = null;
    }

    public override char Char() {
        return '[';
    }
}
