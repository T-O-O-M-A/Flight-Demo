using UnityEngine;
using System.Collections;

public class proceduralTerrain : MonoBehaviour {

    TerrainData terrain;
    public int velikost;
	// Use this for initialization
	void Start () {
        terrain = this.GetComponent<TerrainData>();
        float[,] vysky = new float[velikost, velikost];
        for (int x = 0; x < velikost; x++)
        {
            for(int y=0; y<velikost; y++)
            {
                vysky[y, x] = Mathf.PerlinNoise(y/10, x/10);
                Debug.Log(vysky[y, x]);
            }
        }
        terrain.SetHeights(0, 0, vysky);
        terrain.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
