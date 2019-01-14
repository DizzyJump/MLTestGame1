using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    [System.Flags]
    public enum CellTypes
    {
        Artefact,
        Exit,
        PlannedExit,
        Start,
        Empty,
    }

    public CellTypes Type = CellTypes.Empty;
    System.Action OnTrigger;

    // Use this for initialization
    void Start() {
        Type = CellTypes.Empty;
    }

    // Update is called once per frame
    void Update() {

    }
    
    public void SetType(CellTypes type, System.Action action = null)
    {
        Type = type;
        OnTrigger = action;
    }

    public void ActionCall()
    {
        if(OnTrigger != null)
            OnTrigger();
        else
            Debug.LogError("Try to call empty trigger! Type: "+Type.ToString());
    }
}
