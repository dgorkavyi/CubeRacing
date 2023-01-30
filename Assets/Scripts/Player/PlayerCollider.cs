using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Obstacle>()) {
            GameLifeManager.Defeat();
        }
    }
}