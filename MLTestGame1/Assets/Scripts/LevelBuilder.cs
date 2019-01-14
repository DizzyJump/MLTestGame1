using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    public Transform FloorPrefab;
    public Transform WallPrefab;
    public Transform CornerAnchorPrefab;
    public int LevelWidth;
    public int LevelHeigh;
    public List<GameObject> Walls = new List<GameObject>();
    public List<GameObject> Floors = new List<GameObject>();
    public List<GameObject> Corners = new List<GameObject>();
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
                    Floors.Add(obj.gameObject);
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
                    Corners.Add(corner.gameObject);
                }
            }
    }
}
