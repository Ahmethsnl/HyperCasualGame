using System.Collections;
using UnityEngine;

public class Gun_Meck : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private float _time;
    [SerializeField] private float _tAf;
    [SerializeField] private GameObject _bulletPrefab;

    private bool isSpawned;

    private void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            StopCoroutine(AmmoSpawning());
            return;
        }
        if (!isSpawned)
        {
            StartCoroutine(AmmoSpawning());
        }
    }

    private IEnumerator AmmoSpawning()
    {
        _tAf = _time * _playerData._weaponsFireRate;

        if (gameObject != null)
        {
            isSpawned = true;

            Instantiate(_bulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(_time / _tAf);
            isSpawned = false;
        }
    }

    private void OnEnable()
    {
        isSpawned = false;
    }
}