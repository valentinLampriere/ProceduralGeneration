using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTree : MonoBehaviour {
    [SerializeField] private Rule drawLine;
    [SerializeField] private Rule turnLeft;

    private Rules rules;
    private List<Rule> axiom;

    public static Vector3 origin = new Vector3(0, 0, 0);
    public static Vector3 end = new Vector3(0, 1, 0);

    public Vector3 _origin = new Vector3(0, 0, 0);
    public Vector3 _end = new Vector3(0, 1, 0);

    public static int iteration;

    void Start() {

        axiom = new List<Rule>();
        rules = new Rules();

        axiom.Add(drawLine);

        rules.Add(drawLine, new List<Rule>() { drawLine, turnLeft });
        rules.Add(turnLeft, new List<Rule>() { drawLine });
    }

    // Update is called once per frame
    void Update() {
        _origin = origin;
        _end= end;
        if (Input.GetKeyDown(KeyCode.Space)) {
            axiom = LSystem.Iterate(rules, axiom);
        }
    }
}
