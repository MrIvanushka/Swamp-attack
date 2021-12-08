using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocalSpawner))]
public class SafeMovingTransition : Transition
{
    private LocalSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<LocalSpawner>();
    }

    void Update()
    {
        if(_spawner.EnemyCount == 0)
            NeedTransit = true;
    }
}
