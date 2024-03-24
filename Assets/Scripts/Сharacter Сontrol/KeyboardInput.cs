using UnityEngine;

[RequireComponent(typeof(Movement))]
public class KeyboardInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);

        _movement.Move(new Vector3(horizontal, 0, vertical));
    }
}
