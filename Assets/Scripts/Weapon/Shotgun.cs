using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Shotgun")]
public class Shotgun : Weapon
{
    [SerializeField] private int _bulletCount;

    private const float _maxShootAngle = 20;

    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            float bulletAngle = Random.Range(-_maxShootAngle, _maxShootAngle);
            Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, bulletAngle));
        }
    }
}
