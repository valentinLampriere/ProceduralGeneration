using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : Rule {

    public LineRenderer lr;


    public override void Run(TestTree tree) {
        GameObject line = new GameObject();
        line.transform.parent = GameObject.Find("TestTree").transform;
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;        


        lineRenderer.SetPosition(0, tree.vector.origin);
        //if (tree.enableAlea) {
            lineRenderer.SetPosition(1, tree.vector.origin + tree.vector.direction + tree.vector.direction * (tree.sizeLine + Random.Range(-tree.sizeLine * tree.AleaDegree, tree.sizeLine * tree.AleaDegree)));
            lineRenderer.SetPosition(1, Quaternion.Euler(0, 0, Random.Range(-tree.angle * tree.AleaDegree, tree.angle * tree.AleaDegree) / (tree.sizeLine * tree.sizeLine * tree.sizeLine)) * lineRenderer.GetPosition(1));
        //} else {
        //    lineRenderer.SetPosition(1, tree.vector.origin + tree.vector.direction * tree.sizeLine);
        //}



        //tree.vector.origin = tree.vector.origin + tree.vector.direction * tree.sizeLine;
        tree.vector.origin = lineRenderer.GetPosition(1);
    }

    public override char Char() {
        return 'F';
    }
}
