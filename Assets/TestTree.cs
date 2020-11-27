using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vector {

    public Vector3 origin;
    public Vector3 direction;

    public Vector() {
        origin = new Vector3(0,0,0);
        direction = new Vector3(0, 1, 0);
    }
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

    public float sizeLine = 0.5f;
    public float angle { get; set; } = 60;

    void Start() {

        vector = new Vector();
        savedVectors = new List<Vector>();

        rules = new RuleSet();
        axiom = Rule.GetRulesFromString("F++F++F");
        // tree
        //rules.AddRule('F', "FF+[+F-F-F]-[-F+F+F]");
        //rules.AddRule('F', "FF+F-F+F+FF");

        // star
        rules.AddRule('F', "F-F++F-F");


        foreach(Rule r in axiom) {
            r.Run(this);
        }
    }

    public void OnDrawGizmos() {
        if (vector == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(vector.origin, 0.25f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(vector.origin + vector.direction * sizeLine, 0.25f);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            vector = new Vector();
            foreach(Transform t in transform) {
                Destroy(t.gameObject);
            }
            axiom = LSystem.Iterate(rules, axiom, this);
        }

        string print = "";
        foreach(Rule r in axiom) {
            print += r.ToString();
        }
        Debug.Log(print);
    }
}
