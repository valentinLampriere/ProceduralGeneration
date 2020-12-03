using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : Rule {

    public LineRenderer lr;


    public override void Run(TestTree tree) {

        if (tree.currentLine == null) {
            GameObject line = new GameObject();
            line.transform.parent = GameObject.Find("TestTree").transform;
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
            lineRenderer.startWidth = 0.5f;
            lineRenderer.endWidth = 0.5f;
            tree.currentLine = lineRenderer;
        } else {
            tree.currentLine.positionCount++;
        }

        int pos0 = tree.currentLine.positionCount - 2;
        int pos1 = tree.currentLine.positionCount - 1;

        tree.currentLine.SetPosition(pos0, tree.vector.origin);

        tree.currentLine.SetPosition(pos1, tree.vector.origin + tree.vector.direction + tree.vector.direction * (tree.sizeLine + Random.Range(-tree.sizeLine * tree.AleaDegree, tree.sizeLine * tree.AleaDegree)));
        tree.currentLine.SetPosition(pos1, Quaternion.Euler(0, 0, Random.Range(-tree.angle * tree.AleaDegree, tree.angle * tree.AleaDegree) / (tree.sizeLine * tree.sizeLine * tree.sizeLine)) * tree.currentLine.GetPosition(pos1));

        tree.vector.origin = tree.currentLine.GetPosition(pos1);
    }

    public override char Char() {
        return 'F';
    }
}
