using UnityEngine;
using System.Collections;

public class waves : MonoBehaviour {

    //public int xvert, yvert=1;
    public float scale=5, height=4,speedx=1, speedz=0.5f;
    float t = 0, poziceX, poziceZ;
    Mesh mesh;
    Transform pozice;
    Vector3[] vertices;
    public int octaves = 3;
    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = new Vector3[mesh.vertexCount];
        vertices = mesh.vertices;
        pozice = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //t += Time.deltaTime;
        t += 0.01f;
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            poziceX = (mesh.vertices[i].x + pozice.position.x/this.transform.lossyScale.x + (speedx * t));
            poziceZ = (mesh.vertices[i].z + pozice.position.z/ this.transform.lossyScale.z + (speedz * t));
            vertices[i].y = 0;
            for (int j = 1; j <= octaves; j++)
            {
                vertices[i].y += Mathf.PerlinNoise(poziceZ*j / (scale/j), poziceX*j / (scale/j))*(height/ j)-(height*0.5f)/j;
                //Debug.Log(Mathf.PerlinNoise(mesh.vertices[i].y / scale + speedy * t, mesh.vertices[i].x / scale + speedx * t) * size);
            }
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
	}
}
