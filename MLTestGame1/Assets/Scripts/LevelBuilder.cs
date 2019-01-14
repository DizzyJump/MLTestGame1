using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    public GameDirector DirectorRef;
    public Transform FloorPrefab;
    public Transform WallPrefab;
    public Transform CornerAnchorPrefab;
    public int LevelWidth;
    public int LevelHeigh;
    [HideInInspector]
    public List<GameObject> Walls = new List<GameObject>();
    [HideInInspector]
    public List<Floor> Floors = new List<Floor>();
    [HideInInspector]
    public List<Floor> EmptyFloors = new List<Floor>();
    [HideInInspector]
    public List<Floor> Corners = new List<Floor>();
    [HideInInspector]
    public Floor StartCell;
    [HideInInspector]
    public Floor ExitCell;
    public int ArtefactsCount;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [Button]
    void DropLevel()
    {
        Walls.Clear();
        Floors.Clear();
        EmptyFloors.Clear();
        Corners.Clear();
        while(transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }

    [Button]
    public void Generate()
    {
        DropLevel();
        var width = LevelWidth + 2;
        var heigh = LevelHeigh + 2;
        for(int i=0; i<width; i++)
            for(int j=0; j<heigh; j++)
            {
                bool isBorder = i == 0 || i == (width - 1) || j == 0 || j == (heigh - 1);
                bool isCorner = (i == 1 || i == (width - 2)) && (j == 1 || j == (heigh - 2));
                // spawn walls and floors
                var obj = Instantiate(isBorder ? WallPrefab : FloorPrefab, transform);
                if(isBorder)
                    Walls.Add(obj.gameObject);
                else
                {
                    EmptyFloors.Add(obj.gameObject.GetComponent<Floor>());
                    Floors.Add(obj.gameObject.GetComponent<Floor>());
                }
                    
                Vector3 pos = Vector3.zero;
                pos.x = i;
                pos.z = j;
                pos.y = isBorder ? 0 : -1;
                obj.localPosition = pos;
                // spawn corners
                if(isCorner)
                {
                    var corner = Instantiate(CornerAnchorPrefab, transform);
                    pos.y = 0;
                    corner.localPosition = pos;
                    Corners.Add(obj.gameObject.GetComponent<Floor>());
                }
            }
        // create start point
        StartCell = Corners[Random.Range(0, Corners.Count)];
        EmptyFloors.Remove(StartCell);
        Corners.Remove(StartCell);
        StartCell.SetType(Floor.CellTypes.Start);

        // create start point
        ExitCell = Corners[Random.Range(0, Corners.Count)];
        EmptyFloors.Remove(ExitCell);
        Corners.Remove(ExitCell);
        ExitCell.SetType(Floor.CellTypes.PlannedExit);

        // create artefacts
        for(int k = 0; k < ArtefactsCount; k++)
        {
            var artifact_cell = EmptyFloors[Random.Range(0, EmptyFloors.Count)];
            EmptyFloors.Remove(artifact_cell);
            artifact_cell.SetType(Floor.CellTypes.Artefact);
        }
    }
}
