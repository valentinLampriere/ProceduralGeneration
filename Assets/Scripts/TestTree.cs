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

    private RuleSet rules { get; set; }
    public List<RuleSet> allRules { get; set; }
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

    public GameObject leaves;

    public Vector vector { get; set; }
    public List<Vector> savedVectors { get; set; }

    public LineRenderer currentLine { get; set; }

    public float sizeLine { get; set; } = 10f;
    public float widthLine { get; set; } = 3.3f;
    public float angle { get; set; } = 45;
    public float lengthScaleFactor { get; set; } = 0.98f;
    public float widthScaleFactor { get; set; } = 0.95f;

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

        axiom = Rule.GetRulesFromString("I");

        sizeLine = Random.Range(2f, 7.5f);
        widthLine = Random.Range(sizeLine/3, sizeLine/1.5f);
        /*sizeLine = Random.Range(6f, 20f);
        widthLine = Random.Range(5f, 10f);*/
        angle = Random.Range(40f, 80f);
        widthScaleFactor = Random.Range(0.90f, 1f);

        rules = new RuleSet();
        rules.AddRule('I', "FS");
        rules.AddRule('S', "[[-F&F+F+^SF*]-F&SF+^[&F+F-FS]]");
        allRules.Add(rules);
        
        rules = new RuleSet();
        rules.AddRule('I', "FFS");
        rules.AddRule('S', "F+&[+F&-F+F-F^F*]-^[-^&F+[F-F^F&+^F*]*]");
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
