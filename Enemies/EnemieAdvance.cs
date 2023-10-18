using UnityEngine;

namespace Objects.Script.WesaUtils.Enemies
{
    public class EnemieAdvance : MonoBehaviour
    {
        [Header("Transform")]

        [SerializeField] private float maxZpos;
        [SerializeField] private float minZpos;
        [SerializeField] private float _forwardSpeed;

        void Update()
        {
            EnemieAdvanceTr();
        }

        private void EnemieAdvanceTr()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, minZpos, maxZpos));

            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * -_forwardSpeed);
        }
    }
}
