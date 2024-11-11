using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeControl : MonoBehaviour
{
    public GameObject pipePrefab;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGamePlay)
        {
            time += Time.deltaTime;

            if (time > 1.5f)
            {
                time = 0;

                Instantiate(pipePrefab, new Vector2(5, Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            }
        }
    }
}
