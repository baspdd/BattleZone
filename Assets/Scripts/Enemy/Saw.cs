using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    // Start is called before the first frame update
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, Random.Range(0f, 360f) * speed * Time.deltaTime);
    }
}
