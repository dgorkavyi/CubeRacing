using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _rollSpeed = 5;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private PlayerInput _input;
    private bool _isMoving;
    private bool _isCooldown;
    private float _cooldownTime = 2f;

    public IEnumerator Movement()
    {
        while (true)
        {
            bool isMovingLeftRight = _input.actions["Move"].ReadValue<Vector2>().x != 0;

            if (isMovingLeftRight)
            {
                Vector2 input = _input.actions["Move"].ReadValue<Vector2>();
                Vector3 move = Vector3.right * input.x;
                transform.Translate(move * _rollSpeed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }

            if (!_isMoving)
            {
                Assemble(Vector3.forward);
            }

            yield return null;
        }
    }

    private void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForFixedUpdate();
        }
        _isMoving = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton() || _isCooldown)
            return;

        StartCoroutine(StartCooldown(_cooldownTime));
        Debug.Log(!context.ReadValueAsButton());
        Debug.Log(_isCooldown);
        rb.AddForce(new Vector3(0, 20), ForceMode.Impulse);
    }

    public IEnumerator StartCooldown(float time)
    {
        _isCooldown = true;
        yield return new WaitForSeconds(time);
        _isCooldown = false;
    }
}
