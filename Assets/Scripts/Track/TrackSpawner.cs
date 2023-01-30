using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private Track StartRoad;

    [SerializeField]
    private ObstaclePool _pool;

    [SerializeField]
    private int TrackCount = 7;
    private List<Track> _trackList = new();
    private float _lastPos = 0;
    private float _step = 30f;
    private void IncreasePos() => _lastPos += _step;

    private void Awake()
    {
        _trackList.Add(StartRoad);

        for (int i = 0; i < TrackCount; i++)
        {
            Track track = Instantiate(StartRoad);
            track.transform.parent = transform;
            _trackList.Add(track);
        }

        _trackList.ForEach(track => {
            track.SetNextPos(_pool, _lastPos);
            IncreasePos();
        });
    }

    public IEnumerator StartMoving()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);

            Track nextLastTrack = _trackList.First();
            List<Track> nextTrackList = _trackList.Skip(1).ToList();
            nextLastTrack.SetNextPos(_pool, _lastPos);
            _trackList = nextTrackList.Append(nextLastTrack).ToList();
        }
    }
}
