using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float zPos;
    private float yPos;
    private float diff;

    // Start is called before the first frame update
    void Start()
    {
        zPos = Random.Range(transform.parent.position.z - 3f, transform.parent.position.z + 3f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
}
