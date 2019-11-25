using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float birdSpeed;
    public float jumpPower;
    public int score;
    public GameObject canvas;
    public AudioClip[] audios;
    public Text gameScore;


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        //phone with touch
        for(var i=0; i<Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);

            }
        }

        // pc with W key
        transform.Translate(Vector3.right * birdSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            //vector 3 : yukarı dogru..
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
        }
    }

     void OnTriggerExit2D(Collider2D touch)
    {
        if (touch.gameObject.tag == "trigger")
        {
            Debug.Log("touch");
            touch.gameObject.transform.parent.root.gameObject.GetComponent<Footpath>().touched = true;
            score++;
            GetComponent<AudioSource>().PlayOneShot(audios[1], 1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            gameOver();
        }
    }
    void gameOver()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(audios[0], 1);
        canvas.SetActive(true);
       // gameScore.text = PlayerPrefs.GetInt("Score").ToString();
        gameScore.text = score.ToString();
        

    }
    public void RestartButton()
    {
        Application.LoadLevel("SampleScene");
    }
}
