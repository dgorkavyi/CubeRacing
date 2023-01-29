using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _rollSpeed = 5;

    [SerializeField]
    private float _maxLeft = -2f;

    [SerializeField]
    private float _maxRight = 2f;

    [SerializeField]
    private PlayerInput _input;
    private bool _isMoving;

    public IEnumerator Movement()
    {
        while (true)
        {
            bool isMovingLeftRight = _input.actions["Move"].ReadValue<Vector2>().x != 0;

            if (isMovingLeftRight)
            {
                yield return new WaitForFixedUpdate();

                Vector2 input = _input.actions["Move"].ReadValue<Vector2>();
                Vector3 move = Vector3.right * input.x;
                transform.Translate(move * _rollSpeed * Time.deltaTime);
            }

            if (!_isMoving)
            {
                var anchor = transform.position + (Vector3.down + Vector3.forward) * 0.5f;
                var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                _isMoving = true;

                for (var i = 0; i < 90 / _rollSpeed; i++)
                {
                    transform.RotateAround(anchor, axis, _rollSpeed);
                    yield return new WaitForSeconds(0.01f);
                }

                _isMoving = false;
            }

            yield return null;
        }
    }
}
