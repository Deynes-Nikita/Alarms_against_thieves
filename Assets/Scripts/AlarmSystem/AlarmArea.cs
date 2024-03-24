using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmArea : MonoBehaviour
{
    private Collider _collider;

    public event Action<Collider> DetectedMotion;

    public Collider Collider => _collider;

    private void OnTriggerEnter(Collider other)
    {
        DetectMovement(other);
    }

    private void OnTriggerExit(Collider other)
    {
        DetectMovement(other);
    }

    private void DetectMovement(Collider colliderer)
    {
        DetectedMotion?.Invoke(colliderer);
    }
}
