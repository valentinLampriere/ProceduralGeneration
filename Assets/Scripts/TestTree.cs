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
        { '>', new Extend() },
        { '<', new Reduce() }
    };

    public Vector vector { get; set; }
    public List<Vector> savedVectors { get; set; }

    public float sizeLine = 0.5f;
    public float angle { get; set; } = 45;
    public float lengthScaleFactor = 1.36f;

    void Start() {

        vector = new Vector();
        savedVectors = new List<Vector>();

        rules = new RuleSet();
        /* bushes
        axiom = Rule.GetRulesFromString("y");
        rules.AddRule('x', "x[-FFF][+FFF]Fx");
        rules.AddRule('y', "yFx[+y][-y]");
        */
        /* leaf
        axiom = Rule.GetRulesFromString("a");
        rules.AddRule('F', ">F<");
        rules.AddRule('a', "F[+x]Fb");
        rules.AddRule('b', "F[-y]Fa");
        rules.AddRule('x', "a");
        rules.AddRule('y', "b");
        */


        foreach (Rule r in axiom) {
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
            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }
            axiom = LSystem.Iterate(rules, axiom, this);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {

        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

        }
    }

    void CreateLeaf() {

    }
}
