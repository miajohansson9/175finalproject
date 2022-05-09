using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    Rigidbody previousGameObject;
    [SerializeField] float speed = 7f;
    private float time = 0.0f;
    public int floorLimit = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateFloors", 1f, 7f);
        previousGameObject = GetComponent<Rigidbody>();
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
        if (GameObject.FindGameObjectsWithTag("Floor").Length < floorLimit) {
            Instantiate(gameObject, new Vector3(previousGameObject.transform.position.x, previousGameObject.transform.position.y + 1f,previousGameObject.transform.position.z+20f),Quaternion.Euler(0, 0, 0));
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

