using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    Rigidbody previousGameObject;
    [SerializeField] float speed = 7f;
    private TrapMovement spikes;
    private Trap trap;
    private float time = 0.0f;
    public int floorLimit = 3;
    private int floors;
    
    // Start is called before the first frame update
    void Start()
    {
        floors = GameObject.FindGameObjectsWithTag("Floor").Length;
        if (floors < floorLimit) {
            Invoke("GenerateFloors", 0f);
        }

        previousGameObject = GetComponent<Rigidbody>();
        spikes = transform.GetChild(0).GetChild(1).GetComponent<TrapMovement>();
        trap = transform.GetChild(0).GetComponent<Trap>();
        
        if (floors <= 1) {
            trap.gameObject.SetActive(false);
        } else {
            trap.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time != 0.0f) {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }
    }

    void GenerateFloors()
    {
        float diff = Random.Range(-3f, 3f);
        Instantiate(gameObject, new Vector3(previousGameObject.transform.position.x + diff, previousGameObject.transform.position.y + 1f,
                       previousGameObject.transform.position.z + 14f),Quaternion.Euler(0, 0, 0));
    }

    void OnBecameInvisible() {
        transform.position = new Vector3(transform.position.x, transform.position.y + (1f * floorLimit), (transform.position.z + 14f * floorLimit));
        spikes.min = spikes.min + (1f * floorLimit);
        spikes.max = spikes.min + spikes.diff;
        trap.gameObject.SetActive(true);
    }
}

