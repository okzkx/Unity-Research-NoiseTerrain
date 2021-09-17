using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetArray : MonoBehaviour {
    int[] A = new int[] { 1, 1, 2, 2, 3, 3, 7, 8, 9 };
    int[] B = new int[] { -1, -1, 2, 3, 4, };
    //int[] B = new int[] { 2 };

    // Start is called before the first frame update
    void Start() {
        List<int> c = new List<int>();
        int p1 = 0;
        int p2 = 0;

        //while (p1 < A.Length && p2 < B.Length) {
        //    //if (p2 >= B.Length) {
        //    //    c.Add(A[p1]);
        //    //    p1++;
        //    //    continue;
        //    //}

        //    if (A[p1] == B[p2]) {
        //        p1++;
        //        p2++;
        //    } else {
        //        c.Add(A[p1]);
        //        if (A[p1] < B[p2]) {
        //            p1++;
        //        } else {
        //            p2++;

        //            if (p2 >= B.Length) {
        //                p1++;
        //            }
        //        }
        //    }
        //}

        //for (int i = p1 + 1; i < A.Length; i++) {
        //    c.Add(A[i]);
        //}

        //foreach (var item in c) {
        //    Debug.Log(item);


        List<int> a1 = new List<int>(A);
        List<int> b1 = new List<int>(B);

        bool first = true;
        bool remain = false;
        while (remain || first) {
            remain = false;
            first = false;
            for (int i = 0; i < a1.Count; i++) {
                for (int j = 0; j < b1.Count; j++) {
                    if (a1[i] == b1[j]) {
                        a1.RemoveAt(i);
                        b1.RemoveAt(j);
                        remain = true;
                        break;
                    }
                }
                if (remain) {
                    break;
                }
            }
        }


        foreach (var item in a1) {
            Debug.Log(item);
        }

        foreach (var item in b1) {
            Debug.Log(item);
        }
    }
}