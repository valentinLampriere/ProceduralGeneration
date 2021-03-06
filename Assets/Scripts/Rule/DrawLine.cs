﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : Rule {

    public LineRenderer lr;

    public override void Run(Tree tree) {

        if (tree.currentLine == null) {
            GameObject line = new GameObject();
            line.transform.parent = tree.transform.GetChild(0);
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
            lineRenderer.startColor = new Color(0.557f, 0.447f, 0.404f);
            lineRenderer.endColor = new Color(0.557f, 0.447f, 0.404f);
            lineRenderer.widthMultiplier = tree.widthLine;
            lineRenderer.startWidth = tree.widthLine;
            lineRenderer.endWidth = tree.widthLine * tree.widthScaleFactor;
            tree.currentLine = lineRenderer;
        } else {
            tree.currentLine.positionCount++;
        }

        int pos0 = tree.currentLine.positionCount - 2;
        int pos1 = tree.currentLine.positionCount - 1;

        tree.currentLine.SetPosition(pos0, tree.vector.origin);

        tree.currentLine.SetPosition(pos1, tree.vector.origin + tree.vector.direction * tree.sizeLine + tree.vector.direction * (tree.sizeLine + Random.Range(-tree.sizeLine * tree.AleaDegree, tree.sizeLine * tree.AleaDegree)));

        tree.vector.origin = tree.currentLine.GetPosition(pos1);
    }

    public override char Char() {
        return 'F';
    }
}
