using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : Rule {

    public LineRenderer lr;


    public override void Run(TestTree tree) {
        Vector3 origin, end, direction;

        if (tree.currentLine == null)
            tree.currentLine = tree.createNewLine();
        else {
            origin = tree.currentLine.GetPosition(tree.currentLine.positionCount - 2);
            end = tree.currentLine.GetPosition(tree.currentLine.positionCount - 1);

            direction = (end - origin).normalized;

            tree.currentLine.positionCount += 1;

            tree.currentLine.SetPosition(tree.currentLine.positionCount - 1, end + direction * tree.sizeLine);
        }
        /*Instantiate(gameObject, tree.position.first, Quaternion.identity);

        lr.SetPosition(0, tree.position.first);
        lr.SetPosition(1, tree.position.second);

        origin = tree.position.second;
        direction = (tree.position.second - tree.position.first).normalized;
        end = origin + direction * tree.sizeLine;
        tree.position.first = origin;
        tree.position.second = end;
        */
    }

    public override string ToString() {
        return "DrawLine";
    }
}
