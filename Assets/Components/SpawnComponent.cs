using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;

    public void Spawn()
    {
        var instantoate = Instantiate(_prefab, _target.position, Quaternion.identity);
        instantoate.transform.localScale = _target.lossyScale;
    }
}
