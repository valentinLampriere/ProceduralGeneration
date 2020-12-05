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
    public List<RuleSet> allRules;
    private Axiom axiom;

    public static Dictionary<char, Rule> ExistingRules = new Dictionary<char, Rule> {
        { 'F', new DrawLine() },
        { 'G', new MoveForward() },
        { '+', new TurnRight() },
        { '-', new TurnLeft() },
        { '|', new Turn() },
        { '[', new SaveState() },
        { ']', new LoadState() },
        { '>', new Extend() },
        { '<', new Reduce() },
        { '^', new PitchUp() },
        { '&', new PitchDown() },
        { '\\', new RollLeft() },
        { '/', new RollRight() },
        { '*', new Leaf() },
        { '?', new If() }
    };

    public Vector vector { get; set; }
    public List<Vector> savedVectors { get; set; }

    public LineRenderer currentLine { get; set; }
    //public List<LineRenderer> savedLine { get; set; }

    public float sizeLine { get; set; } = 10f;
    public float widthLine { get; set; } = 3.3f;
    public float angle { get; set; } = 45;
    public float lengthScaleFactor { get; set; } = 0.98f;
    public float widthScaleFactor { get; set; } = 0.95f;

    //public bool enableAlea { get; set; } = true;
    public float AleaDegree { get; set; } = 0f;

    void Start() {

        vector = new Vector();
        savedVectors = new List<Vector>();
        //savedLine = new List<LineRenderer>();

        allRules = new List<RuleSet>();

        /* Tree */
        /*
        angle = 22.5f;
        AleaDegree = 0.01f;
        axiom = Rule.GetRulesFromString("F");
        rules.AddRule('F', "FF+[+F-F-F]-[-F+F+F]");
        */

        /*
        angle = 22.5f;
        AleaDegree = 0.00f;
        axiom = Rule.GetRulesFromString("A");
        rules.AddRule('A', "[&FL!A]/////’[&FL!A]///////’[&FL!A]");
        rules.AddRule('F', "S/////F");
        rules.AddRule('S', "FL");
        rules.AddRule('L', "[’’’^^{-G+G+G-|-G+G+G}]");
        */
        axiom = Rule.GetRulesFromString("T");

        widthLine = 6f;
        angle = 50f;
        widthScaleFactor = 0.97f;

        rules = new RuleSet();
        rules.AddRule('T', "FX");
        rules.AddRule('X', "[F[-F+F-XF]+F+FF-FX]");
        allRules.Add(rules);

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
            /*vector = new Vector();
            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }*/
            axiom = LSystem.Iterate(axiom, this);
            Debug.Log(axiom);
        }
    }

    void CreateLeaf() {

    }
}
