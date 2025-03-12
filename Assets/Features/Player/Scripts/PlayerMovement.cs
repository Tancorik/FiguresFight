using UnityEngine;
using UnityEngine.InputSystem;

/**
 *  Класс отвечающийза движение персонажа
 */
public class PlayerMovement : MonoBehaviour
{
    // Надо же нам поворачивать персонажа
    [SerializeField]
    private Transform body;

    private CharacterController characterController;

    private float _moveSpeed = 5f;
    private Vector3 _moveVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveVector.magnitude != 0f)
        {
            characterController.Move(_moveVector * Time.deltaTime * _moveSpeed);
            body.forward = Vector3.RotateTowards(body.forward, _moveVector, 20f * Time.deltaTime, 0f);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 moveVector = inputValue.Get<Vector2>();
        _moveVector.x = moveVector.x;
        _moveVector.z = moveVector.y;
    }
}
