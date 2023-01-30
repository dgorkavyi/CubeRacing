using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameLifeManager : MonoBehaviour
{
    [SerializeField] private GameObject MoveJoystick;
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject RestartBtn;
    [SerializeField] private GameObject JumpBtn;
    [SerializeField] private TrackSpawner _trackSpawner;
    [SerializeField] private PlayerMovement _playerMoveMent;

    public bool IsGameRunning { get; private set; }

    public void StartGame(InputAction.CallbackContext context) {
        if (!context.ReadValueAsButton()) return;      
        
        IsGameRunning = true;
        StartBtn.SetActive(false);
        MoveJoystick.SetActive(true);
        JumpBtn.SetActive(true);
        
        StartCoroutine(_playerMoveMent.Movement());
        StartCoroutine(_trackSpawner.StartMoving());
    }
    
    public void RestartGame(InputAction.CallbackContext context) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Awake() {
        RestartBtn.SetActive(false);
        MoveJoystick.SetActive(false);
        JumpBtn.SetActive(false);
    }
}
