using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float zPos;
    private float xPos;
    private float xDim;

    // Start is called before the first frame update
    void Start()
    {
        xDim = Random.Range(0.05f, 0.19f);
        transform.localScale = new Vector3(xDim, transform.localScale.y, transform.localScale.z);
        zPos = Random.Range(transform.parent.position.z - 6f, transform.parent.position.z + 6f);
        xPos = Random.Range(transform.parent.position.x - 1.5f,transform.parent.position.x + 1.5f);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
