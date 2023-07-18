using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoll : MonoBehaviour
{

    [SerializeField] private GameObject prefabs;
    [SerializeField] private int quantity;
    [SerializeField] private AudioSource shootSE;
    private List<GameObject> pool = new List<GameObject>();
    private AnimationStage animate => FindObjectOfType<AnimationStage>();
    private float cooldown = 0.8f;
    private float lastShootTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < quantity; i++)
        {
            pool.Add(Instantiate(prefabs.transform).gameObject);
            pool[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanShoot())
        {
            animate.setStage(4);
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private bool CanShoot()
    {
        return Time.time - lastShootTime >= cooldown;
    }

    private void Shoot()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                shootSE.Play();
                obj.SetActive(true);
                break;
            }
        }
    }
}
