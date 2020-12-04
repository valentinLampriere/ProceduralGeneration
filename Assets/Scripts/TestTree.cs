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

    public RuleSet rules { get; set; }
    private Axiom axiom;
    public List<Axiom> buffers;

    public static Dictionary<char, Rule> ExistingRules = new Dictionary<char, Rule> {
        { 'F', new DrawLine() },
        { 'G', new MoveForward() },
        { '+', new TurnRight() },
        { '-', new TurnLeft() },
        { '[', new SaveState() },
        { ']', new LoadState() },
        { '>', new Extend() },
        { '<', new Reduce() },
        { '^', new PitchUp() },
        { '&', new PitchDown() },
        { '\\', new RollLeft() },
        { '/', new RollRight() },
        { '(', new EnterBuffer() },
        { ')', new ExitBuffer() },
        { '?', new If() }
    };

    public Vector vector { get; set; }
    public List<Vector> savedVectors { get; set; }

    public LineRenderer currentLine { get; set; }

    public float sizeLine = 0.5f;
    public float angle { get; set; } = 45;
    public float lengthScaleFactor = 1.36f;

    public float AleaDegree { get; set; } = 0f;

    public bool shouldRunStatement { get; set; } = true;

    void Start() {

        vector = new Vector();
        savedVectors = new List<Vector>();
        buffers = new List<Axiom>();

        rules = new RuleSet();
        /* bushes
        axiom = Rule.GetRulesFromString("y");
        rules.AddRule('x', "x[-FFF][+FFF]Fx");
        rules.AddRule('y', "yFx[+y][-y]");
        */
        /* bushes */
        /*angle = 20;
        axiom = Rule.GetRulesFromString("VZFFF");
        rules.AddRule('V', "[+++W][---W]YV");
        rules.AddRule('W', "+X[-W]Z");
        rules.AddRule('X', "-W[+X]Z");
        rules.AddRule('Y', "YZ");
        rules.AddRule('Z', "[-FFF][+FFF]F");
        */
        /* leaf */
        /*
        angle = 45f;
        AleaDegree = 0.02f;
        axiom = Rule.GetRulesFromString("a");
        rules.AddRule('F', ">F<");
        rules.AddRule('a', "F[+x]Fb");
        rules.AddRule('b', "F[-y]Fa");
        rules.AddRule('x', "a");
        rules.AddRule('y', "b");
        */
        /*
        angle = 25.7f;
        axiom = Rule.GetRulesFromString("X");
        rules.AddRule('X', "F[+X][-X]FX");
        rules.AddRule('F', "FF");
        */

        /* Tree */
        
        angle = 22.5f;
        AleaDegree = 0.01f;
        axiom = Rule.GetRulesFromString("F");
        rules.AddRule('F', "FF+([+F-F-F])-([-F+F+F])");
        
        /*
        angle = 22.5f;
        AleaDegree = 0.00f;
        axiom = Rule.GetRulesFromString("FFFA");
        rules.AddRule('A', "[&FFFA]^////^[&FFFA]^////^[&FFFA]");
        */

        foreach (Rule r in axiom) {
            r.Run(this);
        }

        Debug.Log(axiom);
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

            Debug.Log(axiom);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {

        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

        }
    }
}
