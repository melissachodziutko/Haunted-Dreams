using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pages : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            //GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.pages += 1;
        Debug.Log(PlayerMovement.pages);
        if (PlayerMovement.pages == 4)
        {
            SceneManager.LoadScene("end");
        }
        Destroy(gameObject);
    }
}
