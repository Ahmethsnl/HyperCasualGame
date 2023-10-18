using System.Collections;
using UnityEngine;

namespace Objects.Script.WesaUtils.Player
{
    public class Ammo_sc : MonoBehaviour
    {

        [SerializeField] private float _ammoSpeed;
        [SerializeField] private PlayerData _playerData;

        private Vector3 currPos;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_playerData._fireRange);
            Destroy(gameObject);
        }

        void Update()
        {
            Ammo();
        }

        private void Ammo()
        {
            if (_playerData._normalMode)
            {
                transform.rotation = Quaternion.Euler(90, 0, 0);

                currPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + _ammoSpeed);
                transform.position = Vector3.Lerp(transform.position, currPos, .25f);
            }

            else if (_playerData._sequanceMode)
            {
                transform.rotation = Quaternion.Euler(-90,0,0);

                currPos = new Vector3(transform.position.x, transform.position.y, -(transform.position.z + _ammoSpeed));
                transform.position = Vector3.Lerp(transform.position, currPos, .0025f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("GateLess"))
            {
                Destroy(gameObject);
            }

            else if (other.gameObject.CompareTag("GatePlus"))
            {
                Destroy(gameObject);
            }

            else if (other.gameObject.CompareTag("Target"))
            {
                Destroy(gameObject);
            }

            else if (other.gameObject.CompareTag("Enemie"))
            {
                Destroy(gameObject);
            }
        }
    }
}