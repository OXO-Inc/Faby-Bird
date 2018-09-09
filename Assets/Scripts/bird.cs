using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

    public float upForce = 200;
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject startText;
    public GameObject birdFlapSound;
    public GameObject button;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if(isDead==false && GameControl.instance.gamePause == false)
        {


            if(Input.GetMouseButtonDown(0))
            {
                button.SetActive(true);
                startText.SetActive(false);
                rb2d.gravityScale = 1.5f;
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                birdFlapSound.GetComponent<AudioSource>().Play();
                anim.SetTrigger("Flap");
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameControl.instance.dieCount += 1;
        if (GameControl.instance.dieCount > 1)
        {
            return;
        }
        rb2d.velocity = Vector2.zero;
        isDead = true;
        button.SetActive(false);
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
