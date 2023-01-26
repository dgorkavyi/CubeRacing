using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    private static float LastPos = 0;
    private float Step = 30f;

    public void SetNextPos()
    {
        transform.localPosition = Vector3.forward * LastPos;
        IncreasePos();
    }

    private void IncreasePos() => LastPos += Step;
}
