using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Effect : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    public GameObject[] Hands;

    void Update()
    {
        Hand_Effects();
    }

    private void Hand_Effects()
    {
        for (int i = 0; i < Hands.Length; i++)
        {
            Hands[i].SetActive(i.Equals(_playerData._weaponLevel - 1));
        }
    }
}