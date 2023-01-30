using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private Obstacle _currentObstacle;
    private Vector3 _pos;

    public void Spawn(ObstaclePool pool)
    {
        // if (_currentObstacle != null) {
        //     Destroy(_currentObstacle.gameObject);
        // }

        // int index = Random.Range(0, pool.Obstacles.Count);
        // _pos = Vector3.zero;

        // _currentObstacle = Instantiate<Obstacle>(pool.Obstacles[index]);
        // _currentObstacle.transform.parent = transform;
        // _currentObstacle.transform.localPosition = _pos;
    }
}
