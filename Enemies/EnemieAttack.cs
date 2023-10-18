using System.Collections;
using UnityEngine;

namespace Objects.Script.WesaUtils.Enemies
{
    public class EnemieAttack : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject _ammoPrefab;
        [SerializeField] private float _fireRate;

        private void Update()
        {
            if (!isSpawned)
            {
                StartCoroutine(AmmoSpawning());
            }
        }

        private bool isSpawned;
        private IEnumerator AmmoSpawning()
        {
            isSpawned = true;
            Instantiate(_ammoPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f / _fireRate);

            isSpawned = false;
        }
    }
}
