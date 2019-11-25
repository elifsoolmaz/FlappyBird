using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Footpath : MonoBehaviour
{

    public bool touched;
    public GameObject pipes;
    

    // Start is called before the first frame update
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touched== true)
        {
             Invoke("increasePath", 1.5f);
             touched = false;
            

        }

    }
    void increasePath()
    {
        transform.position = transform.position + new Vector3(15.4f, 0, 0.66f);

        //pipes value

        float yPos = Random.Range(0, 5);
        Debug.Log(yPos.ToString());
        pipes.transform.position = new Vector3(transform.position.x, yPos, 0.35f);
    


    }
}
