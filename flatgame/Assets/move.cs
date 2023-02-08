using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;

    private static Vector3 _position;
    public GameObject dialogue;
    private bool haveWand;
  

    
    public static string[] dialogLines = new string[2]
    {
        "GIVE ME FOOD OR I WONT LEAVE!",
        "Hi, you have the FOOD! Thank You!"
    };

    

    // Start is called before the first frame update
    void Start()
    {
        haveWand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
            animator.SetFloat("vertical",0);
            animator.SetFloat("horizontal",1);
           
            animator.SetFloat("speed", moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * (-moveSpeed * Time.deltaTime);
            animator.SetFloat("vertical",0);
            animator.SetFloat("horizontal",-1);
            
            animator.SetFloat("speed", moveSpeed);

        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * (moveSpeed * Time.deltaTime);
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",1);
            
            animator.SetFloat("speed", moveSpeed);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * (-moveSpeed * Time.deltaTime);
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",-1);
           
            animator.SetFloat("speed", moveSpeed);

        }
        else
        {
            animator.SetFloat("horizontal",0);
            animator.SetFloat("vertical",0);
            animator.SetFloat("speed",0);
        }
       
        _position = transform.position;

        


    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Wand")
        {
            haveWand = true;
            Destroy(other.gameObject);
        }

        if (haveWand && other.gameObject.name == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Enemy")
        {
           
            
            if (haveWand)
            {
                // get key
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<TextMeshProUGUI>().text = dialogLines[1];
                Debug.Log("Hi, you have the FOOD! " + dialogLines[1]);
            }

            else
            {
                // not get key
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<TextMeshProUGUI>().text = dialogLines[0];
                Debug.Log("Hi, do you have the FOOD? " + dialogLines[0]);
            }
        }
        
    }

    
    public static Vector2 Target()
    {
        return _position;
    }
    
    
}

