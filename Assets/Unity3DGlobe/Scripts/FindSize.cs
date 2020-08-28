using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Debug.Log(mesh.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
