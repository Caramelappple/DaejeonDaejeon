using UnityEngine;

namespace _LSO._Scripts.Laser
{
    public class LaserShooter : MonoBehaviour
    {
        public Transform firePoint;
        [SerializeField] private LaserProjectile laserPrefab;
        [SerializeField] private LaserSO laserData;

        public void Shoot()
        {
            var laser =  Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            //laser.Init();
        }
    }
}