using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    public bool start;
    public float posX, posY;
    public float pauseTime;

    public TMP_FontAsset font1, font2;

    public TMP_Text titleText;

    public SpriteRenderer spr1, spr2;

    public int colorIndex = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        posX = Random.Range(-6, 6);
        posY = Random.Range(-3.65f, 1.9f);
        pauseTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (start && pauseTime <= 0)
        {
            start = false;
            posX = Random.Range(-6, 6);
            posY = Random.Range(-3.65f, 1.9f);
            titleText.font = font1;
            titleText.fontSize = 108;
            titleText.text = "Find the Spot";
        }


        if (Input.GetKey(KeyCode.LeftArrow) && pauseTime <= 0)
        {
            transform.Translate(Vector3.left * .01f, Space.World);
            titleText.font = font2;
            titleText.fontSize = 78;

            if (transform.position.x - .2f > posX)
            {
                //text = "on your left"
                titleText.text = "On Your Left";
            } 
            else if (transform.position.x + .2f < posX)
            {
                //text = "on your right"
                titleText.text = "On Your Right";
            }
            spr1.enabled = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && pauseTime <= 0)
        {
            transform.Translate(Vector3.up * .01f, Space.World);
            titleText.font = font2;
            titleText.fontSize = 78;

            if (transform.position.y - .2f > posY)
            {
                //text = "beneath you"
                titleText.text = "Beneath You";
            }
            else if (transform.position.y + .2f < posY)
            {
                //text = "on your top"
                titleText.text = "On Your Top";
            }
            spr1.enabled = true;

        }
        else if (Input.GetKey(KeyCode.RightArrow) && pauseTime <= 0)
        {
            transform.Translate(Vector3.right * .01f, Space.World);
            titleText.font = font2;
            titleText.fontSize = 78;

            if (transform.position.x - .2f > posX)
            {
                //text = "on your left"
                titleText.text = "On Your Left";
            }
            else if (transform.position.x + .2f < posX)
            {
                //text = "on your right"
                titleText.text = "On Your Right";
            }
            spr1.enabled = true;

        }
        else if (Input.GetKey(KeyCode.DownArrow) && pauseTime <= 0)
        {
            transform.Translate(Vector3.down * .01f, Space.World);
            titleText.font = font2;
            titleText.fontSize = 78;

            if (transform.position.y - .2f > posY)
            {
                //text = "beneath you"
                titleText.text = "Beneath You";
            }
            else if (transform.position.y + .2f < posY)
            {
                //text = "on your top"
                titleText.text = "On Your Top";
            }
            spr1.enabled = true;

        }
        else
        {
            spr1.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Text = "Find the Spot"
            titleText.font = font1;
            titleText.fontSize = 108;
            titleText.text = "Find the Spot";

            switch (colorIndex) {
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    colorIndex++;
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    colorIndex++;
                    break;
                case 3:
                    gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                    colorIndex -= 2;
                    break;

            }
        }

        if (Check() && !start)
        {
            start = true;
            pauseTime = 3;
            // Text = "Relocated"
            titleText.font = font1;
            titleText.fontSize = 108;
            titleText.text = "Found! Relocated";
            
        }
        if (pauseTime > 0)
        {
            spr2.enabled = true;
            pauseTime -= Time.deltaTime;
        } else
        {
            spr2.enabled = false;
        }

    }

    bool Check()
    {
        if (transform.position.x - .2f <= posX && transform.position.x + .2f >= posX &&
            transform.position.y - .2f <= posY && transform.position.y + .2f >= posY)
        {
            return true;
        }
        return false;
    }
}
