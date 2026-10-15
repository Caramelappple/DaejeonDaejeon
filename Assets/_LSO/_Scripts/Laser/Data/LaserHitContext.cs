using _LSO._Scripts.Wall.Data;
using _TYU.Scripts.Player;
using UnityEngine;

public readonly struct LaserHitContext
{
    public readonly Collider other;
    public readonly Vector3 hitPoint;
    public readonly Vector3 normal;
    public readonly Vector3 direction;
    public readonly int damage;
    public readonly Player shooter;
    public readonly WallSO wallSo;

    public LaserHitContext(Collider other, Vector3 hitPoint, Vector3 normal, Vector3 direction, int damage, Player shooter, WallSO wallSo)
    {
        this.other = other;
        this.hitPoint = hitPoint;
        this.normal = normal;
        this.direction = direction;
        this.damage = damage;
        this.shooter = shooter;
        this.wallSo = wallSo;
    }
}