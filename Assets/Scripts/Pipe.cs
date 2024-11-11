using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGamePlay)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}
