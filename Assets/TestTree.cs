using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pair<T> {

    public T first;
    public T second;

    public Pair(T first, T second) {
        this.first = first;
        this.second = second;
    }
}

public class TestTree : MonoBehaviour {

    private Rules rules;
    private List<Rule> axiom;

    public GameObject line;

    //public Pair<Vector3> position;

    public LineRenderer currentLine;
    public List<LineRenderer> savedLine;

    public float sizeLine = 0.5f;

    void Start() {

        DrawLine dl = new DrawLine();
        TurnLeft tl = new TurnLeft();
        TurnRight tr = new TurnRight();
        MoveForward mf = new MoveForward();
        SaveState ss = new SaveState();
        LoadState ls = new LoadState();

        //position = new Pair<Vector3>(new Vector3(0, 0, 0), new Vector3(0, 1 * sizeLine, 0));
        savedLine = new List<LineRenderer>();

        /* 
        axiom = new List<Rule>() { dl };
        rules = new Rules() {
            { dl, new List<Rule>() { dl, dl, tr, ss, tr, dl, tl, dl, tl, dl,  ls, tl, ss, tl, dl, tr, dl, tr, dl, ls } },
        };*/
        /* sponge */
        axiom = new List<Rule>() { dl, tl, dl, tl, dl, tl, dl, tl };
        rules = new Rules() {
            { dl, new List<Rule>() { dl, ss, dl, ls, tl, dl, tr, dl, ss, tl, tl, dl, ls, tr, dl, tl, dl } },
        };

        foreach (Rule r in axiom) {
            r.Run(this);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            axiom = LSystem.Iterate(rules, axiom, this);
        }
    }

    public LineRenderer createNewLine(LineRenderer lr = null) {
        GameObject g = Instantiate(line, transform);
        //LineRenderer lineRenderer = g.AddComponent<LineRenderer>();
        LineRenderer lineRenderer = g.GetComponent<LineRenderer>();
        if (lr != null) {
            lineRenderer.SetPosition(0, lr.GetPosition(lr.positionCount - 2));
            lineRenderer.SetPosition(0, lr.GetPosition(lr.positionCount - 1));
        }
        return lineRenderer;
    }
}
