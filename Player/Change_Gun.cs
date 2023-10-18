using UnityEngine;

public class Change_Gun : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public GameObject[] Weapons;

    void Update()
    {
        WeaponChange();
    }

    private void WeaponChange()
    {
        FireRangeCheck();
        FireRateProcess();
        WeaponLevelMathf();
        GunObjChange();
    }

    private void GunObjChange()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(i.Equals(_playerData._weaponLevel - 1));
        }
    }

    private void WeaponLevelMathf()
    {
        if (_playerData._weaponLevel < 0 || _playerData._weaponLevel.Equals(0))
        {
            _playerData._weaponLevel = 1;
        }

        else if (_playerData._weaponLevel > 25)
        {
            _playerData._weaponLevel = 25;
        }
    }

    private void FireRateProcess()
    {
        if (_playerData._weaponsFireRate.Equals(0))
        {
            _playerData._weaponsFireRate = 1;
            _playerData._weaponLevel = 1;
        }
    }

    private void FireRangeCheck()
    {
        if (_playerData._fireRange.Equals(.1f) || _playerData._fireRange < .1f)
        {
            Check();
        }

        else if (_playerData._fireRange > 1)
        {
            _playerData._fireRange = 1;
        }
    }

    private void Check()
    {
        _playerData._fireRange = .2f;
    }
}