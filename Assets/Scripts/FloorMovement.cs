using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    Rigidbody previousGameObject;
    GameObject trap;
    [SerializeField] float speed = 7f;
    private TrapMovement spikes;
    private float time = 0.0f;
    public int floorLimit = 3;

    public int frames;
    public int points;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Floor").Length < floorLimit) {
            Invoke("GenerateFloors", 0f);
        }
        previousGameObject = GetComponent<Rigidbody>();
        spikes = transform.GetChild(0).GetChild(1).GetComponent<TrapMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time != 0.0f) {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }
        // if we've reached max speed stop increasing        
        if (speed >= 14f)
        {
            return;
        }

        // increase the speed by 5% every 10 points
        frames++;
        if (frames == 1800)
        {
            speed *= 1.1f;
            frames = 0;
        }
    }

    void GenerateFloors()
    {
        Instantiate(gameObject, new Vector3(previousGameObject.transform.position.x, previousGameObject.transform.position.y + 1f,
                       previousGameObject.transform.position.z + 20f),Quaternion.Euler(0, 0, 0));
    }

    void OnBecameInvisible() {
        transform.position = new Vector3(transform.position.x, transform.position.y + (1f * floorLimit), (transform.position.z + 20f * floorLimit));
        spikes.min = spikes.min + (1f * floorLimit);
        spikes.max = spikes.min + spikes.diff;
    }
}

