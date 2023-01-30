using UnityEngine;

public class Track : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private static float LastPos = 0;
    private static float Step = 30f;

    public void SetNextPos(ObstaclePool pool)
    {
        if (_obstacleSpawner == null)
        {
            _obstacleSpawner = GetComponentInChildren<ObstacleSpawner>();
        }
        
        _obstacleSpawner.Spawn(pool);
        transform.localPosition = Vector3.forward * LastPos;
        IncreasePos();
    }

    private static void IncreasePos() => LastPos += Step;

    private void Awake() { }
}
