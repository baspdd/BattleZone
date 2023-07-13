using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceSpike : MonoBehaviour
{
    [SerializeField] private GameObject enemyDeath;
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

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer is (int)Layer.Fire)
        {
            var death = Instantiate(this.enemyDeath);
            death.transform.localPosition = transform.position;
            Destroy(this.gameObject);
            await UniTask.Delay(500);
            Destroy(death);
        }
    }
}
