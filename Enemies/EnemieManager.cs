using UnityEngine;

namespace Objects.Script.WesaUtils.Enemies
{
    public class EnemieManager : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerDatas;
        [SerializeField] private EnemieData _enemieData;
        [SerializeField] private WalletData _walletData;
        [SerializeField] private int _health;

        private int _enemiesHealth;
        private int _playerWeaponLevel;
        private int _playerDamage;
        private bool _isFour = false;
        public static int _enemieNumerator;

        private void Start()
        {
            _enemiesHealth = _enemieData._enemieHealth;
            _enemieNumerator = _enemieData._enemieNum;
        }

        private void Update()
        {
            GOSA();
            DamageCheck();

            if (_enemiesHealth.Equals(_health))
            {
                _isFour = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ammo"))
            {
                _enemiesHealth -= _playerDamage;
            }

            else if (other.gameObject.CompareTag("Player"))
            {
                _playerDatas._weaponsFireRate -= _playerDatas._fireRateSubstratorAdd;

                if (_enemieData.Damage.Equals(1))
                {
                    _playerDatas._weaponsFireRate -= _enemieData.Damage;
                }
            }
        }

        private void DamageCheck()
        {
            _playerWeaponLevel = (_playerDatas._weaponLevel - 1);
            _playerDamage = _playerDatas.weapons[_playerWeaponLevel].Damage;
        }

        private void GOSA()
        {
            if (_enemiesHealth < 0 || _enemiesHealth.Equals(0))
            {
                _walletData._income += _enemieData._enemieCash;

                gameObject.SetActive(false);

                if (_isFour)
                {
                    _enemieNumerator -= 1;
                }

                if(_enemieNumerator < 0)
                {
                    _enemieNumerator = 0;
                }
            }
        }
    }
}