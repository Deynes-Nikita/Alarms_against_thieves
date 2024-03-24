using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        Vector3 offset = direction * (_speed * Time.deltaTime);

        transform.Translate(offset);
    }
}
