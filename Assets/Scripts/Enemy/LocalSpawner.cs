using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class LocalSpawner : MonoBehaviour
{
    private Player _target;
    private int _enemyCount;

    public int EnemyCount => _enemyCount;

    private void Awake()
    {
        _target = GetComponent<Enemy>().Target;
        _enemyCount = 0;
    }

    private void Update()
    {
    }

    public void InstantiateEnemy(GameObject enemyTemplate)
    {
        Enemy enemy = Instantiate(enemyTemplate, transform.position, transform.rotation).GetComponent<Enemy>();
        enemy.Init(GetComponent<Enemy>().Target);
        enemy.Dying += OnEnemyDying;
        _enemyCount++;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _enemyCount--;
    }
}
