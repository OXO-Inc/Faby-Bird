using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {


    public static ScrollingObject instance;
    public int speed=-3;
    private Rigidbody2D rb2d;
    // Use this for initializatio

    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
        if(GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
		
	}
    private void FixedUpdate()
    {
        speed += -1;
    }
}
