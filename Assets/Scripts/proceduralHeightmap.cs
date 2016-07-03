using UnityEngine;
using System.Collections;

public class proceduralHeightmap : MonoBehaviour {

    public float scale, height;
    public int octaves;
    Vector3[] vertices;
    float localheight;
    // Use this for initialization
    void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        vertices = new Vector3[mesh.vertexCount];
        vertices = mesh.vertices;
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            vertices[i].y = 0;
            localheight = 0;
            for (int j = 1; j <= octaves; j++)
            {
                localheight += Mathf.PerlinNoise(mesh.vertices[i].z / (scale / j),mesh.vertices[i].x / (scale / j)) * (height / j)-(height*0.5f)/j;
            }
            vertices[i].y = localheight;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
        //mesh.Optimize();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.deltaTime);
	}
}
