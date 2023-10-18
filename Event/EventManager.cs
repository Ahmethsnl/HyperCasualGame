using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<PlayerData> onAddFireRange;
    public static void AddFireRange(PlayerData pd) => onAddFireRange?.Invoke(pd);

    public static event Action<WalletData> onAddIncome;
    public static void AddIncome(WalletData wd) => onAddIncome?.Invoke(wd);

    public static event Action<PlayerData> onWeaponLevel;
    public static void AddYear(PlayerData md) => onWeaponLevel?.Invoke(md);
}
