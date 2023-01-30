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

    private void Awake()
    {
        _trackList.Add(StartRoad);

        for (int i = 0; i < TrackCount; i++)
        {
            Track track = Instantiate(StartRoad);
            track.transform.parent = transform;
            _trackList.Add(track);
        }
        
        _trackList.ForEach(track => track.SetNextPos(_pool));
    }

    public IEnumerator StartMoving()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            Track nextLastTrack = _trackList.First();
            List<Track> nextTrackList = _trackList.Skip(1).ToList();
            nextLastTrack.SetNextPos(GetComponent<ObstaclePool>());
            _trackList = nextTrackList.Append(nextLastTrack).ToList();
        }
    }
}
