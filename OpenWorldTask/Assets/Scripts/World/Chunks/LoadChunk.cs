using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(EntityList))]
public class LoadChunk : MonoBehaviour
{

    [SerializeField]
    string fileName;

    [SerializeField]MeshFilter chunk_to_load;
    [SerializeField]MeshCollider chunk_collider;

    bool loaded;

    private GameObject distanceLoadObject;
    private LoadByDistance loadByDistanceScript;

    private void Start()
    {
        distanceLoadObject = GameObject.Find("ChunkLoader");
        loadByDistanceScript = distanceLoadObject.GetComponent<LoadByDistance>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.1f);

        loadByDistanceScript.chunks.Add(new Chunks { chunk = this.gameObject.GetComponent<LoadChunk>(), chunkPos = this.transform.position, entities = this.gameObject.GetComponent<EntityList>() });
        //get entities in chunk and add to entity list
    }

    [ContextMenu("Load OBJ")]
    public void loadChunk()
    {
        if (!loaded)
        {
            string path = Application.streamingAssetsPath + "/" + fileName + ".obj";

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
            chunk_collider.sharedMesh = mesh;
            loaded = true;

            reader.Close();
        }
    }

    [ContextMenu("UnloadOBJ")]
    public void unloadChunk()
    {
        if (loaded)
        {
            chunk_to_load.sharedMesh = null;
            chunk_collider.sharedMesh = null;
            loaded = false;
        }
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
