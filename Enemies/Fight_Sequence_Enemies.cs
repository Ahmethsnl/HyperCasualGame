using UnityEngine;

namespace Objects.Script.WesaUtils.Enemies
{
    public class Fight_Sequence_Enemies : MonoBehaviour
    {
        [Header("Transform")]
        [SerializeField] private float minZpos;
        [SerializeField] private float maxZpos;
        [SerializeField] private float _forwardSpeed;

        private void Update()
        {
            Fight_Sequence_EnemiesTr();
        }

        private void Fight_Sequence_EnemiesTr()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, minZpos, maxZpos));

            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _forwardSpeed);
        }
    }
}
