using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTree : MonoBehaviour
{
    string axiom = "A";
    Rules rules = new Rules();
    // Start is called before the first frame update
    void Start() {
        rules.AddRule('A', "ABA");
        rules.AddRule('B', "B");
        
        Debug.Log(axiom);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            axiom = LSystem.Iterate(rules, axiom);
            Debug.Log(axiom);
        }
    }
}
