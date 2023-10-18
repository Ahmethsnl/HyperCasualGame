using UnityEngine;

[CreateAssetMenu(menuName = "", fileName = "")]

public class EnemieData : ScriptableObject
{
    public GameObject enemie;
    public int Damage;
    public int _enemieHealth;
    public int _enemieCash;
    public int _enemieNum;
}