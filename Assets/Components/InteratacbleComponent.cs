using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

public class InteratacbleComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    public void Interact()
    {
        _action?.Invoke();

    }
}
