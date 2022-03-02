using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

enum saveResolution { FULL=0, HALF, QUATER, EIGHTH, SXTEENTH}

[RequireComponent(typeof(Terrain))]
public class TerrainExport : EditorWindow
{
    saveResolution save_resolution = saveResolution.HALF;

    static TerrainData terrain_data;
    static Vector3 terrain_pos;

    GameObject terrainGroup;

    int selected_int = 0;

    private void Awake()
    {
        terrainGroup = GameObject.Find("TerrainGroup_0");
    }

    [MenuItem("Terrain/Export To Obj...")]
    static void Init()
    {
        terrain_data = null;
        Terrain terrain_obj = Selection.activeObject as Terrain;
        if(!terrain_obj)
        {
            terrain_obj = Terrain.activeTerrain;
        }
        if(terrain_obj)
        {
            terrain_data = terrain_obj.terrainData;
            terrain_pos = terrain_obj.transform.position;
        }
        EditorWindow.GetWindow<TerrainExport>().Show();
    }

    private void OnGUI()
    {
        if(!terrain_data)
        {
            GUILayout.Label("No terrain found");
            if (GUILayout.Button("Cancel"))
            {
                EditorWindow.GetWindow<TerrainExport>().Close();
            }
            return;
        }

        save_resolution = (saveResolution)EditorGUILayout.EnumPopup("Resolution", save_resolution);

        if (GUILayout.Button("Export"))
        {
            Export();
        }

        if(GUILayout.Button("ExportAll"))
        {
            ExportAll();
        }
    }

    void Export()
    {
        string file_name = EditorUtility.SaveFilePanel("Export .obj file", "", "Terrain" + selected_int.ToString(), "obj"); ;
        int w = terrain_data.heightmapResolution;
        int h = terrain_data.heightmapResolution;
        Vector3 mesh_scale = terrain_data.size;
        int t_res = (int)Mathf.Pow(2, (int)save_resolution);
        mesh_scale = new Vector3(mesh_scale.x / (w - 1) * t_res, mesh_scale.y, mesh_scale.z / (h - 1) * t_res);
        Vector2 uv_scale = new Vector2(1.0f / (w - 1), 1.0f / (h - 1));
        float[,] tData = terrain_data.GetHeights(0, 0, w, h);

        w = (w - 1) / t_res + 1;
        h = (h - 1) / t_res + 1;
        Vector3[] t_verts = new Vector3[w * h];
        Vector2[] tUV = new Vector2[w * h];

        int[] tPolys = new int[(w-1) * (h-1) * 6];

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                t_verts[y * w + x] = Vector3.Scale(mesh_scale, new Vector3(-y, tData[x * t_res, y * t_res], x)) + terrain_pos;
                tUV[y * w + x] = Vector2.Scale(new Vector2(x * t_res, y * t_res), uv_scale);
            }
        }

        int index = 0;
        for (int y = 0; y < h-1; y++)
        {
            for (int x = 0; x < w-1; x++)
            {
                tPolys[index++] = (y * w) + x;
                tPolys[index++] = ((y + 1) * w) + x;
                tPolys[index++] = (y * w) + x + 1;

                tPolys[index++] = ((y + 1) * w) + x;
                tPolys[index++] = ((y + 1) * w) + x + 1;
                tPolys[index++] = (y * w) + x + 1;
            }
        }

        StreamWriter sw = new StreamWriter(file_name);

        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        for (int i = 0; i < t_verts.Length; i++)
        {
            StringBuilder sb = new StringBuilder("v ", 20);

            sb.Append(t_verts[i].x.ToString()).Append(" ").
                Append(t_verts[i].y.ToString()).Append(" ").
                Append(t_verts[i].z.ToString());
            sw.WriteLine(sb);
        }

        for (int i = 0; i < tUV.Length; i++)
        {
            StringBuilder sb = new StringBuilder("vt ", 22);
            sb.Append(tUV[i].x.ToString()).Append(" ").
                Append(tUV[i].y.ToString());
            sw.WriteLine(sb);
        }

        for (int i = 0; i < tPolys.Length; i += 3)
        {
            StringBuilder sb = new StringBuilder("f ", 43);
            sb.Append(tPolys[i] + 1).Append("/").Append(tPolys[i] + 1).Append(" ").
               Append(tPolys[i + 1] + 1).Append("/").Append(tPolys[i + 1] + 1).Append(" ").
               Append(tPolys[i + 2] + 1).Append("/").Append(tPolys[i + 2] + 1);
            sw.WriteLine(sb);
        }

        sw.Close();

        EditorWindow.GetWindow<TerrainExport>().Close();
        terrain_data = null;
    }

    void ExportAll()
    {
        for (int i = 0; i < terrainGroup.transform.childCount; i++)
        {
            selected_int = i;
            terrain_data = terrainGroup.transform.GetChild(i).GetComponent<Terrain>().terrainData;
            terrain_pos = terrainGroup.transform.GetChild(i).position;
            Export();
        }
    }
}
