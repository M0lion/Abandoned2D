using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Triangle : MonoBehaviour {

    public MeshFilter meshFilter;

    Texture2D tex;

	void Start () {
        Mesh mesh = meshFilter.mesh;
        mesh.Clear();

        tex = new Texture2D(1,1);
        tex.SetPixel(0, 0, Color.white);

        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(new Vector3(0, 0.5f, 0));
        vertices.Add(new Vector3(0.5f, -0.5f, 0));
        vertices.Add(new Vector3(-0.5f, -0.5f, 0));
        //mesh.SetVertices(vertices); 
        mesh.vertices = vertices.ToArray();

        List<Vector2> uvs = new List<Vector2>();
        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(0, 0));
        //mesh.SetUVs(0, uvs);
        mesh.uv = uvs.ToArray();

        Vector3[] normals = new Vector3[3];
        normals[0] = new Vector3(0, 0, -1);
        normals[1] = new Vector3(0, 0, -1);
        normals[2] = new Vector3(0, 0, -1);
        mesh.normals = normals;

        List<int> triangles = new List<int>();
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        //mesh.SetTriangles(triangles, 0);
        mesh.triangles = triangles.ToArray();
    }
	
	void Update () {
	
	}
}
