using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class Advance : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private float maxXpos;
    [SerializeField] private float minXpos;
    [SerializeField] private float maxZpos;
    [SerializeField] private float minZpos;
    [SerializeField] private float _speed;
    [SerializeField] private float _minSeqX;
    [SerializeField] private float _maxSeqX;

    [SerializeField] private PlayerData _playerData; 
    public static float _forwardSpeed;

    private void Start()
    {
        _forwardSpeed = _speed;
    }
    private void Update()
    {
        AdvanceTr();
    }

    private void AdvanceTr()
    {
        if (_playerData._normalMode)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXpos, maxXpos), transform.position.y, Mathf.Clamp(transform.position.z, minZpos, maxZpos));

            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _forwardSpeed);
        }

        //if (_playerData._thirdSequanceMode)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minSeqX, _maxSeqX), transform.position.y, transform.position.z);
        //}
    }
}