using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    [Header("Data's")]
    [SerializeField] private GateData _gateData;
    [SerializeField] private PlayerData _playerData;

    [Header("Variables")]
    public Material _materialPlus;
    public GameObject Gate;
    public GameObject Gate2;
    public GameObject Gate3;
    public TextMeshProUGUI _healthText;
    public GameObject[] Circles;
    public bool _isFireRate;
    public bool _isFireRange;

    private int _nowWeaponLevel;
    private int Damage;
    private int _interactionObjHealthPlus;
    private int _interactionObjHealthLess;
    private int _targetHealth;
    private float _healthTextLess;
    private float _healthTextPlus;
    public void Start()
    {
        HealthCheck();
    }

    private void Update()
    {
        WeaponLevelMaths();
        DamageNHealthCheck();
        GOSA();
        GateEffective();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("GateLess"))
        {
            if (other.gameObject.CompareTag("Ammo"))
            {
                if (_playerData._weaponLevel > 1)
                {
                    _interactionObjHealthLess += Damage / 2;
                }
                else if (_playerData._weaponLevel.Equals(1))
                {
                    _interactionObjHealthLess += Damage;
                }

                _healthTextLess = (_interactionObjHealthLess);
                _healthText.text = _healthTextLess.ToString();
            }

            if (other.gameObject.CompareTag("Player"))
            {
                if (_isFireRange)
                {
                    _healthTextLess = _healthTextLess / 100;
                    _playerData._fireRange += _healthTextLess;
                }
                else if (_isFireRate)
                {
                    _healthTextLess = _healthTextLess / 10;
                    _playerData._weaponsFireRate += _healthTextLess;
                }

                gameObject.SetActive(false);
            }
        }

        else if (gameObject.tag.Equals("GatePlus"))
        {
            if (other.gameObject.CompareTag("Ammo"))
            {
                if (_playerData._weaponLevel > 1)
                {
                    _interactionObjHealthPlus += Damage / 2;
                }

                else if (_playerData._weaponLevel.Equals(1))
                {
                    _interactionObjHealthPlus += Damage;
                }

                _healthTextPlus = _interactionObjHealthPlus;
                _healthText.text = _healthTextPlus.ToString();
            }

            if (other.gameObject.CompareTag("Player"))
            {
                if (_isFireRange)
                {
                    _healthTextPlus = _healthTextPlus / 100;
                    _playerData._fireRange += _healthTextPlus;
                }

                else if (_isFireRate)
                {
                    _healthTextPlus = _healthTextPlus / 10;
                    _playerData._weaponsFireRate += _healthTextPlus;
                }

                gameObject.SetActive(false);
            }
        }

        else if (gameObject.tag.Equals("Target"))
        {
            if (other.gameObject.CompareTag("Ammo"))
            {
                _targetHealth -= 1;
                TargetEffective();
            }

            if (other.gameObject.CompareTag("Player"))
            {
                _playerData._weaponsFireRate -= _playerData._fireRateSubstratorAdd;
            }
        }
    }

    private void GateEffective()
    {
        if (_interactionObjHealthLess > 0)
        {
            Gate.GetComponent<Renderer>().material.color = Color.green;
            Gate2.GetComponent<Renderer>().material.color = Color.green;
            Gate3.GetComponent<Renderer>().material.color = _materialPlus.color;
        }
    }

    private void HealthCheck()
    {
        _interactionObjHealthPlus = _gateData.gates[0]._interactionObjHealth;
        _interactionObjHealthLess = _gateData.gates[1]._interactionObjHealth;
        _targetHealth = _gateData.targets[0]._takenDamage;
    }

    private void TargetEffective()
    {
        Circles[_targetHealth].SetActive(false);
    }

    private void DamageNHealthCheck()
    {
        _nowWeaponLevel = (_playerData._weaponLevel - 1);
        Damage = _playerData.weapons[_nowWeaponLevel].Damage;

        if (_targetHealth < 0)
        {
            _targetHealth = 0;
        }
    }

    private void GOSA()
    {
        if (_targetHealth.Equals(0))
        {
            _playerData._weaponLevel += 1;
            gameObject.SetActive(false);
        }
    }

    private void WeaponLevelMaths()
    {
        FireRateCheck();
        FireRangeCheck();
    }

    private void FireRateCheck()
    {
        if (_playerData._weaponsFireRate < 0)
        {
            _playerData._weaponsFireRate = 1;
        }

        if (_playerData._weaponLevel.Equals(0))
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