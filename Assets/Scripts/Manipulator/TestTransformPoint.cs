using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransformPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.InverseTransformPoint(target.position));
    }
}