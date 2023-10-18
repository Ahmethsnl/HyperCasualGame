using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletText : MonoBehaviour
{
    [SerializeField] WalletData WalletData;
    [SerializeField] private TextMeshProUGUI moneyText;

    void FixedUpdate()
    {
        moneyText.text = "Money => " + WalletData.money.ToString();
    }
}
