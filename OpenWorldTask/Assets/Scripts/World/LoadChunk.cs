using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadChunk : MonoBehaviour
{
    ///in range bool event??


    [SerializeField]Object file;

    //ChunkData chunk_data = new ChunkData();

    [SerializeField]MeshFilter chunk_to_load;
    /*private Vector3 playerPos;

    Vector2 terrainDimensions;*/

    //List<GameObject> ActiveChunks;

    private void Start()
    {
        Debug.Log(file.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadChunk();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            unloadChunk();
        }
    }

    [ContextMenu("Load OBJ")]
    public void loadChunk()
    {
        /* if(File.Exists(file))
         {
             string fileContents = File.ReadAllText(file);

             chunk_data = JsonUtility.FromJson<ChunkData>(fileContents);
             Vector3[] vertex_vec = null;
             for (int i = 0; i < chunk_data.vertecies.Length; i++)
             {
                 vertex_vec[i].x = chunk_data.vertecies[0];
                 vertex_vec[i].y = chunk_data.vertecies[1];
                 vertex_vec[i].z = chunk_data.vertecies[2];

                 chunk_to_load.GetComponent<MeshFilter>().sharedMesh.vertices[i] = vertex_vec[i];
             }
         }*/

        string path = Application.streamingAssetsPath + "/" + file.name + ".obj";

        StreamReader reader = new StreamReader(path);
        string line;
        List<Vector3> vertices = new List<Vector3>();
        List<int> indices = new List<int>();
        while ((line = reader.ReadLine()) != null)
        {
            string[] split = line.Split(' ');
            switch (split[0])
            {
                case "v": // Vertex
                    Vector3 vertex = new Vector3(float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
                    vertices.Add(vertex);
                    break;
                case "f": // Index
                    List<int> theseIndexes = new List<int>();
                    for (int i = 1; i < split.Length; i++)
                    {
                        theseIndexes.Add(int.Parse(split[i].Split('/')[0]) - 1);
                    }
                    indices.AddRange(Triangulate(theseIndexes));
                    break;
            }
        }
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = indices.ToArray();
        mesh.RecalculateNormals();
        chunk_to_load.sharedMesh = mesh;

        reader.Close();
    }

    [ContextMenu("UnloadOBJ")]
    void unloadChunk()
    {
        chunk_to_load.sharedMesh = null;
    }

    public List<int> Triangulate(List<int> _indices)
    {
        List<int> triangulated = new List<int>();
        for (int i = 2; i < _indices.Count; i++)
        {
            triangulated.AddRange(new[]
            {
                _indices[0],
                _indices[i-1],
                _indices[i]
            });
        }
        return triangulated;
    }
}
