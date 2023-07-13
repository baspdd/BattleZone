using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoll : MonoBehaviour
{

    [SerializeField] private GameObject prefabs;
    [SerializeField] private int quantity;
    private List<GameObject> pool = new List<GameObject>();
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
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    await UniTask.Delay(300);
                    item.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
