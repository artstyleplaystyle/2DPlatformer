using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReward : MonoBehaviour
{
    [SerializeField] private Strawberry _strawberry;
    [SerializeField] private Transform _path;
    [SerializeField] private float _coolDown;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_coolDown);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_strawberry, _points[i].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}