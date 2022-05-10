using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float zPos;

    // Start is called before the first frame update
    void Start()
    {
        zPos = Random.Range(transform.parent.position.z - 8f, transform.parent.position.z + 8f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
}
