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
    private Coroutine _movement;
    private Coroutine _trackMoving;
    private static GameLifeManager _instance;

    public bool IsGameRunning { get; private set; }

    public void StartGame(InputAction.CallbackContext context) {
        if (!context.ReadValueAsButton()) return;      
        
        IsGameRunning = true;
        StartBtn.SetActive(false);
        MoveJoystick.SetActive(true);
        JumpBtn.SetActive(true);
        
        _movement = StartCoroutine(_playerMoveMent.Movement());
        _trackMoving = StartCoroutine(_trackSpawner.StartMoving());
    }
    
    public void RestartGame(InputAction.CallbackContext context) {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.LoadLevel(0);
    }

    public static void Defeat() {
        _instance.StopCoroutine(_instance._movement);
        _instance.StopCoroutine(_instance._trackMoving);
        _instance.RestartBtn.SetActive(true);
        _instance.JumpBtn.SetActive(false);
        _instance.MoveJoystick.SetActive(false);
    }

    private void Awake() {
        _instance = this;
        RestartBtn.SetActive(false);
        MoveJoystick.SetActive(false);
        JumpBtn.SetActive(false);
    }
}
