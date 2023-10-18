using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Objects.Script.WesaUtils.Enemies;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Data's")]
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GateData _gateData;
    [SerializeField] private WalletData _walletData;
    [SerializeField] private EnemieData _enemieData;

    [Header("Variables")]
    [SerializeField] private float _yearPrice;
    [SerializeField] private float _fireRangePrice;

    [Header("UI and GameObjects")]
    public Button _yearButton;
    public Button _fireRangeButton;
    public GameObject ThirdSequanceEnemies;
    public GameObject SecondSequanceEnemies;

    private GameObject VirtualCam;
    private GameObject _camera;
    private bool _isStarted;
    private bool _must;

    private void Start()
    {
        _must = true;
        _playerData._normalMode = true;
        _playerData._sequanceMode = false;
    }

    private void Update()
    {
        SequanceProcess();
        TargetSequance();
    }

    private void TargetSequance()
    {
        if (EnemieManager._enemieNumerator.Equals(10) && _must)
        {
            _playerData._normalMode = true;
            _playerData._sequanceMode = false;
            _playerData._thirdSequanceMode = false;
        }
        else if (EnemieManager._enemieNumerator.Equals(10) && _must.Equals(false))
        {
            _playerData._sequanceMode = true;
            _playerData._normalMode = false;
            _playerData._thirdSequanceMode = false;
        }
        else if (EnemieManager._enemieNumerator.Equals(7) && _must)
        {
            _playerData._thirdSequanceMode = true;
            _playerData._sequanceMode = false;
            _playerData._normalMode = false;
        }
    }

    private void SequanceProcess()
    {
        if (_playerData._sequanceMode)
        {
            _playerData._thirdSequanceMode = false;
            _playerData._sequanceMode = true;
            _playerData._normalMode = false;

            RotationObjectSequance();

            if (EnemieManager._enemieNumerator < (_enemieData._enemieNum - 1))
            {
                Must();
            }

            else
            {
                _playerData._normalMode = false;
                _playerData._sequanceMode = true;
            }
        }

        else if (_playerData._normalMode)
        {
            RotationObjectNormal();
        }
    }

    private void Must()
    {
        if (EnemieManager._enemieNumerator < (_enemieData._enemieNum - 2))
        {
            _playerData._sequanceMode = false;
            _playerData._normalMode = true;

            ThirdSequance();
        }

        else
        {
            _playerData._sequanceMode = true;
            _playerData._normalMode = false;
        }
    }

    private void RotationObjectSequance()
    {
        if (_playerData._sequanceMode)
        {
            VirtualCam.SetActive(false);
            _camera.transform.SetParent(gameObject.transform);

            transform.rotation = Quaternion.Lerp(transform.rotation,
                (Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z)), .05f);
        }
    }

    private void RotationObjectNormal()
    {
        _playerData._sequanceMode = false;
        _playerData._normalMode = true;

        if (_playerData._normalMode)
        {
            if (!_isStarted)
            {
                return;
            }

            //VirtualCam.SetActive(true);
            //_camera.transform.SetParent(null);

            //transform.rotation = Quaternion.Lerp(transform.rotation,
            //    (Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z)), .05f);

            if (_playerData._thirdSequanceMode)
            {
                VirtualCam.SetActive(true);
                _camera.transform.SetParent(null);

                transform.rotation = Quaternion.Lerp(transform.rotation,
                    (Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z)), .05f);
            }
        }
    }

    private async void ThirdSequance()
    {
        _playerData._thirdSequanceMode = true;
        await UniTask.Delay(TimeSpan.FromSeconds(5f));
        ThirdSequanceEnemies.SetActive(true);
        SecondSequanceEnemies.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Siper"))
        {
            _must = false;
            _playerData._sequanceMode = true;
            _playerData._normalMode = false;
            _playerData._thirdSequanceMode = false;
        }

        else
        {
            _must = true;
            _playerData._normalMode = true;
        }
    }

    public void AddYear(PlayerData _playerData)
    {
        if (_playerData._weaponLevel <= 25)
        {
            if (_yearPrice <= _walletData.money)
            {
                _walletData.money -= _yearPrice;
                _playerData._weaponLevel += 1;
                _yearPrice *= 3;
            }

            else if (_yearButton != null)
            {
                _yearButton.interactable = false;
            }
        }

        else if (_playerData._weaponLevel > 25)
        {
            _yearButton.interactable = false;
        }
    }

    public void AddFireRange(PlayerData _myPlayerData)
    {
        if (_playerData._fireRange < 1)
        {
            if (_fireRangePrice <= _walletData.money)
            {
                _walletData.money -= _fireRangePrice;
                _playerData._fireRange += _playerData._fireRangeSubstratorAdd;
                _fireRangePrice *= 1.5f;
            }

            else if (_fireRangeButton != null)
            {
                _fireRangeButton.interactable = false;
            }
        }

        else
        {
            _fireRangeButton.interactable = false;
        }
    }

    private async void SetStart()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        VirtualCam = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
        _camera = Camera.main.gameObject;
        _isStarted = true;
    }

    private void OnEnable()
    {
        EventManager.onAddFireRange += AddFireRange;
        EventManager.onWeaponLevel += AddYear;
        SetStart();
    }

    private void OnDisable()
    {
        EventManager.onAddFireRange -= AddFireRange;
        EventManager.onWeaponLevel -= AddYear;
    }
}