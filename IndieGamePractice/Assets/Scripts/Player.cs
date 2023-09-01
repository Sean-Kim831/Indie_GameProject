using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public AudioSource item_Sound;

    public bool isjump;

    public int score;
    public int left_item;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI left_item_text;

    public GameObject end_image;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        left_item = 8;

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            item_Sound.Play();
            score = score+10;
            left_item = left_item-1;
        }
        if(other.tag == "Jump_item")
        {
            other.gameObject.SetActive(false);
            item_Sound.Play();
            score = score+20;
            left_item = left_item-1;
        }

   
        if(score >= 100)
        {
            end_image.SetActive(true);
        }
        
        score_text.text = "Score : " + score + "/ 100";
        left_item_text.text = "Left item : " + left_item;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Floor")
        { 
            isjump = true;
        }
        
    }

    //물리 사용을 위한 지속 호출
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal"); //수평축입력
        float moveVertical = Input.GetAxis("Vertical"); //수직축입력

        //플레이어를 이동시키겠다
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed); //플레이어에게 힘 가해서 이동시키겠다

        if(Input.GetKey(KeyCode.Space) && isjump)
        {
            rb.AddForce(Vector3.up * 9, ForceMode.Impulse);
            isjump = false;
        }
    }
}
