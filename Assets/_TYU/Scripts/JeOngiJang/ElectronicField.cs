using System;
using _LSO._Scripts.Wall;
using DevLib.ServiceLocator;
using DevLib.SoundSystem.Runtime;
using UnityEngine;

namespace _TYU.Scripts.JeOngiJang
{
    public class ElectronicField : MonoBehaviour
    {
    [SerializeField] private ContactFilter2D whatIsTarget;
    [SerializeField] private ElectronicType myType;
    [SerializeField] private bool debug;
    [SerializeField] private int bufferSize = 5;
    [SerializeField] private RuntimeAnimatorController minus;
    [SerializeField] private RuntimeAnimatorController plus;
    [SerializeField] private SoundClipSO clip;
    private Animator _anim;
    private float _electronicDistance;
    private int _gauge;
    private float _pushPower;
    private bool _isReady;
    private SphereCollider _collider;
    private Collider[] results;

    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
        results = new Collider[bufferSize];
    }

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }

    public void Init(ElectricSO data, ElectronicType type)
    {
        _electronicDistance = data.ElectronicDistance;
        _gauge = data.Gauge;
        _pushPower = data.PushPower;
        myType = type;
        if (type == ElectronicType.Negative)
            _anim.runtimeAnimatorController = minus;
        else
            _anim.runtimeAnimatorController = plus;
        _isReady = true;
    }

    private void ElectricField()
    {
        int cnt = Physics.OverlapSphereNonAlloc(transform.position, _electronicDistance, results, whatIsTarget.layerMask);
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
                    player.Push(pushDir, _pushPower, ForceMode.Force);
                }
                else
                {
                    player.Push(-pushDir, _pushPower, ForceMode.Force);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        IsWall();
        ElectricField();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isReady) return;
        if (other.TryGetComponent(out Player.Player player))
        {
            ServiceLocator.Get<IAudioService>()?.PlaySfx(clip);
            
            if (player.ElectronicType == myType)
            {
                player.Gauge.Up(_gauge);
            }
            else
            {
                player.Gauge.Down(_gauge);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (!debug) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _electronicDistance);
    }

    private void IsWall()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _collider.radius);
        if (colliders.Length > 0)
        {
            foreach (var target in colliders)
            {
                if (target.TryGetComponent(out Wall wall) || target.CompareTag("Wall"))
                    Destroy(gameObject);
            }
        }
    }
    }
}