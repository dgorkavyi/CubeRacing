using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField]
    private Track StartRoad;

    [SerializeField]
    private int TrackCount = 8;
    private List<Track> _trackList = new();

    private void Awake()
    {
        for (int i = 0; i < TrackCount; i++)
        {
            Track track = Instantiate(StartRoad);
            track.transform.parent = transform;
            track.SetNextPos();
            _trackList.Add(track);
        }
    }

    public IEnumerator StartMoving()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            Track nextLastTrack = _trackList.First();
            List<Track> nextTrackList = _trackList.Skip(1).ToList();
            nextLastTrack.SetNextPos();
            _trackList = nextTrackList.Append(nextLastTrack).ToList();
        }
    }
}
