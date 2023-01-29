using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacles;
    public List<Obstacle> Obstacles => _obstacles;
}
