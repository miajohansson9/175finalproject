using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    private float time = 0.0f;
    public float min;
    public float max;
    public float diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = Random.Range(0.5f, 1f);
        min = transform.position.y;
        max = transform.position.y + diff;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time != 0.0f) {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2,max-min)+ min, transform.position.z);
        }
    }
}
