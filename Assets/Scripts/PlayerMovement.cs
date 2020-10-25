using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   
    public int movementspeed = 1;
    public static int pages = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementspeed * (Time.deltaTime / 8));
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementspeed * (Time.deltaTime / 8));
        }
       /* else if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementspeed * (Time.deltaTime / 8));
        }*/

    }
    void timerEnded()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider2D>().CompareTag("Enemy"))
        {
            Debug.Log("poopoo");
            //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            pages -= 1;

        }
        if (GetComponent<Collider2D>().CompareTag("Page"))
        {
            Debug.Log("poopoo");
            pages += 1;
            if (pages == 4)
            {
                SceneManager.LoadScene("End");
            }
        }
        if (GetComponent<Collider2D>().CompareTag("Boundary"))  
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
       
    }
}
