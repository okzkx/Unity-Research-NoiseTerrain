using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeshSelectType {
    None = 0,
    LeftTop = 1 << 0,
    LeftBottom = 1 << 1,
    RightTop = 1 << 2,
    RightBottom = 1 << 3,
}


public class GenerateTerrain : MonoBehaviour {

    public float maxHeight = 20;
    public float width = 50;
    public Vector2 perlinCenter = new Vector2(42, 45);
    [Range(0, 0.1f)]
    public float frequency = 0.05f;

    public GameObject[] terrainItemPrefabs = new GameObject[16];

    IEnumerator Start() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < width; j++) {
                for (float k = 0.25f; k < maxHeight; k += 0.5f) {
                    float h = k + 0.25f;
                    float h1 = k - 0.25f;
                    (Vector2 a, Vector2 b, Vector2 c, Vector2 d) = Get4Points(i, j);

                    bool leftTop = Sample(a) > h;
                    bool leftBottom = Sample(b) > h;
                    bool rightTop = Sample(c) > h;
                    bool rightBottom = Sample(d) > h;

                    MeshSelectType meshSelectType = MeshSelectType.None;
                    meshSelectType |= leftTop ? MeshSelectType.LeftTop : MeshSelectType.None;
                    meshSelectType |= leftBottom ? MeshSelectType.LeftBottom : MeshSelectType.None;
                    meshSelectType |= rightTop ? MeshSelectType.RightTop : MeshSelectType.None;
                    meshSelectType |= rightBottom ? MeshSelectType.RightBottom : MeshSelectType.None;

                    GameObject prefab = GetTerrainItem(meshSelectType);
                    if (prefab != null) {
                        GameObject terrainItem = GameObject.Instantiate(prefab);
                        terrainItem.transform.position = new Vector3(a.x, k, a.y);
                    }
                }
            }
            yield return null;
        }
    }

    private GameObject GetTerrainItem(MeshSelectType meshSelectType) {
        return terrainItemPrefabs[(int)meshSelectType];
    }

    private (Vector2, Vector2, Vector2, Vector2) Get4Points(int i, int j) {
        return (new Vector2(i - 0.5f, j + 0.5f), new Vector2(i - 0.5f, j - 0.5f),
            new Vector2(i + 0.5f, j + 0.5f), new Vector2(i + 0.5f, j - 0.5f));
    }



    float Sample(Vector2 coord) {
        coord += perlinCenter;
        coord *= frequency;
        return Mathf.PerlinNoise(coord.x, coord.y) * maxHeight;
    }

}
