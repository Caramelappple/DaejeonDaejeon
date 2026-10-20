using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _TYU.Scripts.JeOngiJang
{
    public class KashimoHajime : MonoBehaviour
    {
        [SerializeField] private List<ElectricSO> dataList;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int firstSpawn;
        [SerializeField] private int reSpawn;
        [SerializeField] private float coolTime;
        private BoxCollider _collider;
        private float _lastTime;
        private Vector3 _maxPoint;
        private Vector3 _minPoint;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _maxPoint = transform.position + _collider.size/2;
            _minPoint = transform.position - _collider.size/2;
            if (!prefab.TryGetComponent(out ElectronicField field))
            {
                Debug.LogError("프리팹 고쳐 병신아");
                return;
            }
            for (int i = 0; i < firstSpawn; i++)
            {
                var ranPos = new Vector3(Random.Range(_minPoint.x, _maxPoint.x), 0f,
                    Random.Range(_minPoint.z, _maxPoint.z));
                var ob = Instantiate(prefab);
                ob.transform.position = ranPos;
                var fd = ob.GetComponent<ElectronicField>();
                
                fd.Init(dataList[Random.Range(0,dataList.Count)], Random.Range(-50,51) >0 ? ElectronicType.Negative : ElectronicType.Positive);
            }

            _lastTime = Time.time;
        }

        private void Update()
        {
            if (_lastTime + coolTime < Time.time)
            {
                for (int i = 0; i < reSpawn; i++)
                {
                    var ranPos = new Vector3(Random.Range(_minPoint.x, _maxPoint.x), 0f,
                        Random.Range(_minPoint.z, _maxPoint.z));
                    var ob = Instantiate(prefab);
                    ob.transform.position = ranPos;
                    var fd = ob.GetComponent<ElectronicField>();
                
                    fd.Init(dataList[Random.Range(0,dataList.Count)], Random.Range(0,2) == 1 ? ElectronicType.Negative : ElectronicType.Positive);
                }

                _lastTime = Time.time;
            }
        }
    }
}