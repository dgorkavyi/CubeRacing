using UnityEngine;

public class Track : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private static float LastPos = 0;
    private float Step = 30f;

    public void SetNextPos(ObstaclePool pool)
    {
        _obstacleSpawner.Spawn(pool);
        transform.localPosition = Vector3.forward * LastPos;
        IncreasePos();
    }

    private void IncreasePos() => LastPos += Step;

    private void Awake()
    {
        _obstacleSpawner = GetComponentInChildren<ObstacleSpawner>();
    }
}
