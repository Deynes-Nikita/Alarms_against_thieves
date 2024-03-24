using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class MouseInput : MonoBehaviour
{
    private const string MouseX = nameof(MouseX);

    [SerializeField] private Rotation _rotation;

    private void Start()
    {
        _rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis(MouseX);

        _rotation.Rotate(new Vector3(0, mouseX, 0));
    }
}
