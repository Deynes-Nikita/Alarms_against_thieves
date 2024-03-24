using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmArea : MonoBehaviour
{
    private Collider _collider;

    public event Action<Collider> InHouses;
    public event Action<Collider> OutHouses;

    public Collider Collider => _collider;

    private void OnTriggerEnter(Collider other)
    {
        InHouses?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OutHouses?.Invoke(other);
    }
}
