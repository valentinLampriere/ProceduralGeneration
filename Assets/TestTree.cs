using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vector {

    public Vector3 origin;
    public Vector3 direction;

    public Vector(Vector3 origin, Vector3 direction) {
        this.origin = origin;
        this.direction = direction;
    }
}

public class TestTree : MonoBehaviour {

    private RuleSet rules;
    private List<Rule> axiom;

    public static Dictionary<char, Rule> ExistingRules = new Dictionary<char, Rule> {
        { 'F', new DrawLine() },
        { 'G', new MoveForward() },
        { '+', new TurnRight() },
        { '-', new TurnLeft() },
        { '[', new SaveState() },
        { ']', new LoadState() },
    };

    public GameObject line;

    public Vector vector { get; set; }
    public List<Vector> savedVectors { get; set; }
    //public LineRenderer currentLine;
    //public List<LineRenderer> savedLine;

    public float sizeLine = 0.5f;
    public float angle { get; set; } = 90;

    void Start() {

        vector = new Vector(new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        savedVectors = new List<Vector>();

        rules = new RuleSet();

        axiom = Rule.GetRulesFromString("F");
        rules.AddRule('F', "FF+[+F-F-F]-[-F+F+F]");

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            axiom = LSystem.Iterate(rules, axiom, this);
        }
    }

    public void createNewLine(Vector vector = null) {
        GameObject g = Instantiate(line, transform);
        LineRenderer lineRenderer = g.GetComponent<LineRenderer>();
        if (vector != null) {
            lineRenderer.SetPosition(0, vector.origin);
            lineRenderer.SetPosition(1, vector.origin + vector.direction * sizeLine);
        }
    }
}
