using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(LocalSpawner))]
public class SummonState : State
{
    private const string _animationClip = "Summoning";

    [SerializeField] private GameObject _zombie;
    [SerializeField] private int _zombieCount;
    [SerializeField] private float _durationPerSpawn;
    [SerializeField] private float _startCastingDuration;

    private Animator _animator;
    private LocalSpawner _spawner;
    private WaitForSeconds _startWaiting;
    private WaitForSeconds _waitingPerSpawn;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spawner = GetComponent<LocalSpawner>();
        _startWaiting = new WaitForSeconds(_startCastingDuration);
        _waitingPerSpawn = new WaitForSeconds(_durationPerSpawn / _zombieCount);
    }

    private void OnEnable()
    {
        _animator.Play(_animationClip);
        StartCoroutine(Casting());
    }

    private IEnumerator Casting()
    {
        yield return _startWaiting;

        for (int i = 0; i < _zombieCount; i++)
        {
            _spawner.InstantiateEnemy(_zombie);
            yield return _waitingPerSpawn;
        }
    }
}
