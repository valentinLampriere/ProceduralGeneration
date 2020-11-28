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
        lineRenderer.startWidth = 0.2f + Random.Range(0.0f, 0.1f);
        lineRenderer.endWidth = 0.2f + Random.Range(0.0f, 0.1f);


        lineRenderer.SetPosition(0, tree.vector.origin);
        lineRenderer.SetPosition(1, tree.vector.origin + tree.vector.direction * (tree.sizeLine + Random.Range(-tree.sizeLine / 3f, tree.sizeLine / 3f)));

        lineRenderer.SetPosition(1, Quaternion.Euler(0, 0, Random.Range(-tree.sizeLine/10f, tree.sizeLine/10f)) * lineRenderer.GetPosition(1));


        //tree.vector.origin = tree.vector.origin + tree.vector.direction * tree.sizeLine;
        tree.vector.origin = lineRenderer.GetPosition(1);
    }

    public override char Char() {
        return 'F';
    }
}
