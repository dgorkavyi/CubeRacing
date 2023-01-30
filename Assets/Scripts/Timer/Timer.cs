using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerText;
    private float _timer;

    public IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            _timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_timer / 60F);
            int seconds = Mathf.FloorToInt(_timer % 60F);
            int milliseconds = Mathf.FloorToInt((_timer * 100F) % 100F);
            TimerText.text =
                minutes.ToString("00")
                + ":"
                + seconds.ToString("00")
                + ":"
                + milliseconds.ToString("00");
        }
    }
}
