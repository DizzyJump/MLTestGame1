using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefact : MonoBehaviour {
    Floor parent;
    public bool DisableOnCollide = true;

    private void OnEnable()
    {
        parent = transform.parent.GetComponent<Floor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(DisableOnCollide)
            gameObject.SetActive(false);
        parent.ActionCall();
    }
}
