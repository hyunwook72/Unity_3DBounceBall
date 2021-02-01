using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyBall : MonoBehaviour
{
    Vector3 originalPos;
    public int moveSpeed = 0;
    private float distToGround;
    Rigidbody rigid;
    GameObject Player;

    GameObject nearObject;
    bool iDown;
    public GameObject[] stars;
    public bool[] hasStars;

    // Start is called before the first frame update
    void Start()
    {
        Player = new GameObject("Player");
        Player.AddComponent<Rigidbody>();
        Player.AddComponent<BoxCollider>();
        gameObject.tag = "Player";
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rigid = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
       // Interaction();
    }

    //bool IsGrounded()
    //{
    //  return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    //}

    // Update is called once per frame
    //void GetInput()
   // {
    //    iDown = GetInput.GetButtonDown("Interaction");
   // }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //gameObject.transform.position = originalPos;
        }

        if (collision.gameObject.name == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //gameObject.transform.position = originalPos;
        }

        if (collision.gameObject.name == "JumpPad")
        {
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

    }
   // void Interaction()
    //{
    //    if(iDown && nearObject != null)
    //    {
     //       if(nearObject.tag == "Star")
     //       {
     //           Star star = nearObject.GetComponent<Star>();
     //           int starIndex = star.value;
    //            hasStars[starIndex] = true;
    //
     //           Destroy(nearObject);
     //       }
     //   }
    //}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            Destroy(other.gameObject);
        }
    }

    //void OnTriggerStay(Collider other)
   // {
     //   if (other.tag == "Star")
    //        nearObject = other.gameObject;
   // }

   // void OnTriggerExit(Collider other)
   // {
    //    if (other.tag == "Star")
     //       nearObject = null;
   // }
}
