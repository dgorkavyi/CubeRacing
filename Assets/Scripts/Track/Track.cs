using UnityEngine;

public class Track : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;

    public void SetNextPos(ObstaclePool pool, float pos)
    {
        if (_obstacleSpawner == null)
        {
            _obstacleSpawner = GetComponentInChildren<ObstacleSpawner>();
        }

        _obstacleSpawner.Spawn(pool);
        transform.localPosition = Vector3.forward * pos;
    }

    private void Awake() { }
}
