using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private const float offset = 800f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < this.transform.childCount; i++)
        {
            var screenPos = Camera.main.WorldToScreenPoint(this.transform.GetChild(i).transform.position);
            if(screenPos.x <= Screen.width + offset)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            if (!this.transform.GetChild(i).gameObject.activeSelf) return;
            var onScreen = screenPos.y > 0f && screenPos.y < Screen.height && screenPos.x > 0f && screenPos.x < Screen.width;
            if (!onScreen) this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
