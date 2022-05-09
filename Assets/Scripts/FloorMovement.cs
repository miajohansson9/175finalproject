using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    private float time = 0.0f;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time != 0.0f) {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }

        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            Instantiate(gameObject);
        }
    }
}

