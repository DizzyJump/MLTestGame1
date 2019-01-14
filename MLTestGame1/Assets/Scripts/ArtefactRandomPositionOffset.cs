using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactRandomPositionOffset : MonoBehaviour {
    public Vector3 OffsetBiasAmplitude;

    private void OnEnable()
    {
        Vector3 local_pos = transform.localPosition;
        local_pos += OffsetBiasAmplitude * (Random.value * 2 - 1);
        transform.localPosition = local_pos;
    }
}
