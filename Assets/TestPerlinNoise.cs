using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPerlinNoise : MonoBehaviour {
    public Vector2 perlinCenter;
    [Range(1, 1000)]
    public float frequency = 1;
    [Range(0, 50)]
    public float scope = 25;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnDrawGizmos() {

        

        for (int i = 0; i < 100; i++) {
            for (int j = 0; j < 100; j++) {
                Vector2 coord = new Vector2(i, j) - Vector2.one * 50;
                coord = (coord + perlinCenter) * frequency / 10000;
                float height = Mathf.PerlinNoise(coord.x, coord.y);
                Vector3 position = new Vector3(i, height * scope, j);
                Gizmos.DrawSphere(position, 0.2f);

                //    GameObject go =GameObject.CreatePrimitive( PrimitiveType.Sphere);
                //  go.transform.position = new Vector3(i,j,height*50);        
            }
        }
    }

}
