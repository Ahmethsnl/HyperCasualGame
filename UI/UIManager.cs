using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void AddFireRangeButton(PlayerData myData)
    {
        EventManager.AddFireRange(myData);
    }

    public void AddIncomeButton(WalletData myWalletData)
    {
        EventManager.AddIncome(myWalletData);
    }

    public void AddWeaponYearButton(PlayerData Data)
    {
        EventManager.AddYear(Data);
    }
}
