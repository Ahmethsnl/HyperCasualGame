using UnityEngine;
using UnityEngine.UI;

public class Income : MonoBehaviour
{
    [SerializeField] private WalletData _walletData;
    [SerializeField] private float _incomePrice;

    public Button _incomeButton;

    public void AddIncome(WalletData walletData)
    {
        if (_incomePrice <= _walletData.money)
        {
            if (_walletData._incomeLevel < 20)
            {
                _walletData._incomeLevel += 1;
                _walletData.money -= _incomePrice;
                _walletData._income = _walletData._income * _walletData._incomePlus;
                _incomePrice *= 1.5f;
                _walletData.money += walletData._income;
            }

            else if (_incomeButton != null)
            {
                _incomeButton.interactable = false;
            }
        }

        else if (_incomePrice > _walletData.money || _walletData._incomeLevel > 20)
        {
            _incomeButton.interactable = false;
        }
    }

    private void OnEnable()
    {
        EventManager.onAddIncome += AddIncome;
    }

    private void OnDisable()
    {
        EventManager.onAddIncome -= AddIncome;
    }
}