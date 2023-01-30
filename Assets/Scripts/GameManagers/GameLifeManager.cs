using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameLifeManager : MonoBehaviour
{
    [SerializeField] private GameObject MoveJoystick;
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject RestartBtn;
    [SerializeField] private GameObject JumpBtn;
    [SerializeField] private GameObject DefeatScreen;
    [SerializeField] private ParticleSystem WarpEffect;
    [SerializeField] private TrackSpawner _trackSpawner;
    [SerializeField] private PlayerMovement _playerMoveMent;
    [SerializeField] private Timer _timer;
    private Coroutine _timerCoroutine;
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
        
        _timerCoroutine = StartCoroutine(_timer.StartTimer());
        _movement = StartCoroutine(_playerMoveMent.Movement());
        _trackMoving = StartCoroutine(_trackSpawner.StartMoving());
    }
    
    public void RestartGame(InputAction.CallbackContext context) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Defeat() {
        _instance.StopCoroutine(_instance._movement);
        _instance.StopCoroutine(_instance._trackMoving);
        _instance.StopCoroutine(_instance._timerCoroutine);
        _instance.RestartBtn.SetActive(true);
        _instance.JumpBtn.SetActive(false);
        _instance.MoveJoystick.SetActive(false);
        _instance.DefeatScreen.SetActive(true);
        _instance.WarpEffect.Stop();
    }

    private void Awake() {
        _instance = this;
        RestartBtn.SetActive(false);
        MoveJoystick.SetActive(false);
        JumpBtn.SetActive(false);
        DefeatScreen.SetActive(false);
        _instance.WarpEffect.Play();
    }
}
