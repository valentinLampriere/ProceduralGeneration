using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : MonoBehaviour {
    public virtual void Start() { }
    public abstract void Run();
}
