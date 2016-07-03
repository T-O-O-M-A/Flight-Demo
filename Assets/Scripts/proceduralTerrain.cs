using UnityEngine;
using System.Collections;

public class proceduralTerrain : MonoBehaviour {

    TerrainData terrain;
    public int velikost, octaves;
    public float vyska, treshold, scale;
    public GameObject kostka;
    float localVyska;
    GameObject[,,] teren;
	// Use this for initialization
	void Start () {
        teren = new GameObject[velikost, velikost, velikost];
        terrain = this.GetComponent<TerrainData>();
        float[,] vysky = new float[velikost, velikost];
        for (int x = 0; x < velikost; x++)
        {
            for(int z=0; z<velikost; z++)
            {
                localVyska = 0;
                for(int i =1; i <= octaves; i++)
                {
                    localVyska += Mathf.PerlinNoise(x *i*scale, z * i*scale) * vyska;
                    
                }
                /*localVyska += Mathf.PerlinNoise(x / (scale * 2), z / (scale * 2)) * (vyska / 2);
                localVyska += Mathf.PerlinNoise(x / (scale * 4), z / (scale * 4)) * (vyska / 16);
                localVyska += Mathf.PerlinNoise(x / (scale * 8), z / (scale * 8)) * (vyska / 32);*/
                localVyska -= 2.5f*vyska;
                Instantiate(kostka,new Vector3( x, localVyska, z),Quaternion.identity);
                //  Debug.Log(localVyska);
                /*for (int z = 0; z<localVyska; z++)
                {
                    if (localVyska > treshold)
                    {
                        teren[x, y, z] = Instantiate(kostka, new Vector3(x, y, z), Quaternion.identity) as GameObject;
                    }
                }*/
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
