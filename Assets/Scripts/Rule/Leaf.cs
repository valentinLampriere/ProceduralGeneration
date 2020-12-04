using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Rule {

    public LineRenderer lr;


    public override void Run(TestTree tree) {

        GameObject line = new GameObject();
        line.transform.parent = GameObject.Find("TestTree").transform;
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        lineRenderer.startColor = new Color(0.345f, 0.529f, 0.086f);
        lineRenderer.endColor = new Color(0.345f, 0.529f, 0.086f);

        lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.5f, 2f, .5f);

        lineRenderer.positionCount = 3;

        lineRenderer.SetPosition(0, tree.vector.origin);
        lineRenderer.SetPosition(1, tree.vector.origin + tree.vector.direction * 0.5f);
        lineRenderer.SetPosition(2, tree.vector.origin + tree.vector.direction);
    }

    public override char Char() {
        return 'F';
    }
}
