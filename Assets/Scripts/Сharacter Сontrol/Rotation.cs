using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotate(Vector3 direction)
    {
        Vector3 offset = direction * (_speed * Time.deltaTime);

        transform.Rotate(0, offset.y , 0);
    }
}
