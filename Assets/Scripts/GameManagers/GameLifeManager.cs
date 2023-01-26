using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLifeManager : MonoBehaviour
{
    [SerializeField] private GameObject MoveJoystick;
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject RestartBtn;

    public bool IsGameRunning { get; private set; }

    public void StartGame() {
        IsGameRunning = true;
        StartBtn.SetActive(false);
        MoveJoystick.SetActive(true);
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Awake() {
        RestartBtn.SetActive(false);
        MoveJoystick.SetActive(false);
    }
}