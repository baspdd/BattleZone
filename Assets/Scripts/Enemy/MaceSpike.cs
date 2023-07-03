using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceSpike : MonoBehaviour
{
    [SerializeField] float amplitude = 2;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + amplitude * new Vector3(0f, Mathf.Sin(Time.time), 0);
    }
}
