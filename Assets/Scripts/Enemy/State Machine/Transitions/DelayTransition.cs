using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTransition : Transition
{
    [SerializeField] private float _delay;

    private float _currentTime;

    private void OnEnable()
    {
        _currentTime = 0;
        NeedTransit = false;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _delay)
        {
            NeedTransit = true;
            _currentTime = 0;
        }
    }
}
