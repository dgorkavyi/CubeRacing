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

    [SerializeField]
    private Transform Cube;

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
            }

            transform.Translate(Vector3.forward * _rollSpeed * Time.deltaTime);
            Cube.Rotate(Vector3.right * _rollSpeed * 50 * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton() || _isCooldown)
            return;

        StartCoroutine(StartCooldown(_cooldownTime));
        Debug.Log(!context.ReadValueAsButton());
        Debug.Log(_isCooldown);
        rb.AddForce(new Vector3(0, 40), ForceMode.Impulse);
    }

    public IEnumerator StartCooldown(float time)
    {
        _isCooldown = true;
        yield return new WaitForSeconds(time);
        _isCooldown = false;
    }
}
