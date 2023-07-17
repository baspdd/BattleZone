using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTranform;
    private Vector3 lastcameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTranform = Camera.main.transform;
        lastcameraPosition = cameraTranform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTranform.position - lastcameraPosition;
        transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, deltaMovement.z);
        lastcameraPosition = cameraTranform.position;
    }
}
