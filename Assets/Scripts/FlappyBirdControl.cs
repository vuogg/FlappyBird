using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdControl : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Animator animator;

    public float force;

    public AudioSource audioSource;
    public AudioClip flyClip, pingClip, dieClip;

    public bool isAlive;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = false;
        rigidbody2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive && Input.GetMouseButtonDown(0))
        {
            rigidbody2D.AddForce(Vector2.up * force);
            audioSource.PlayOneShot(flyClip);
        }

        if(rigidbody2D.velocity.y > 0)
        {
            float angle = Mathf.Lerp(0, 90, rigidbody2D.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, -rigidbody2D.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void OnInit()
    {
        isAlive = true;
        score = 0;
        rigidbody2D.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            audioSource.PlayOneShot(pingClip);
            score++;
            UIManager.instance.scoreUI.text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isAlive && (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Pipe"))
        {
            isAlive = false;
            audioSource.PlayOneShot(dieClip);
            animator.SetTrigger("die");
            GameManager.instance.isGamePlay = false;

            UIManager.instance.FinishGame();
        }
    }
}
