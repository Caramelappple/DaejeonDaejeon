using System;
using System.Linq;
using _LSO._Scripts;
using _TYU.Scripts.Interface;
using UnityEngine;

namespace _TYU.Scripts.JeOngiJang
{
    public class ElectronicField : MonoBehaviour
    {
    [SerializeField] private float electronicDistance;
    [SerializeField] private ContactFilter2D whatIsTarget;
    [SerializeField] private ElectronicType myType;
    [SerializeField] private int gauge;
    [SerializeField] private float pushPower;
    [SerializeField] private bool debug;
    [SerializeField] private int bufferSize = 5;

    private Collider[] results;

    private void Awake()
    {
        results = new Collider[bufferSize];
    }

    private void ElectricField()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, electronicDistance, results, whatIsTarget.layerMask);
        if (cnt < 1) return;
        
        foreach (var target in results)
        {
            if(target == null) continue;
            if (target.TryGetComponent(out Player.Player player))
            {
                Vector3 pushDir = player.transform.position - transform.position;
                pushDir.y = 0;
                pushDir = pushDir.normalized;
                if (player.ElectronicType == myType)
                {
                    player.Push(pushDir, pushPower, ForceMode.Force);
                }
                else
                {
                    player.Push(-pushDir, pushPower, ForceMode.Force);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        ElectricField();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            if (player.ElectronicType == myType)
            {
                player.Gauge.Up(gauge);
            }
            else
            {
                player.Gauge.Down(gauge);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!debug) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, electronicDistance);
    }
    }
}