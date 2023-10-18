using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "", fileName = "")]

public class GateData : ScriptableObject
{
    public float _gateIncome;

    public List<Gates> gates;
    public List<Targets> targets;
}

[Serializable]
public class Gates
{
    public GameObject Gate;

    public float _fireGate;
    public int _interactionObjHealth;
}

[Serializable]
public class Targets
{
    public GameObject Target;

    public int _takenDamage;
}