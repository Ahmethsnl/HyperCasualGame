using System.Collections;
using UnityEngine;

namespace Objects.Script.WesaUtils.Enemies
{
    public class Enemie3Ammo : MonoBehaviour
    {
        [SerializeField] private float _ammoSpeed;

        private Vector3 currPos;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(.1f);
            Destroy(gameObject);
        }

        void Update()
        {
            Ammo();
        }

        private void Ammo()
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);

            currPos = new Vector3(transform.position.x, transform.position.y, -(transform.position.z + _ammoSpeed));
            transform.position = Vector3.Lerp(transform.position, currPos, .0025f);
        }
    }
}