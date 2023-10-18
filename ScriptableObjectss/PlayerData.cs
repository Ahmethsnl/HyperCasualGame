using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "", fileName = "")]

public class PlayerData : ScriptableObject
{
    public float _weaponsFireRate;
    public float _fireRange;
    public float _fireRateSubstratorAdd;
    public float _fireRangeSubstratorAdd;
    public int _weaponLevel;
    public bool _sequanceMode;
    public bool _normalMode;
    public bool _thirdSequanceMode;
    public List<Weapons> weapons;
}

[Serializable]
public class Weapons
{
    public GameObject Weapon;
    public int Damage;
}