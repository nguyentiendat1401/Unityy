using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float h, v;
    private int count = 0;

    public float speed;

    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        updateScore();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0f, v);
        rb.AddForce(speed * movement);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")//Kiểm tra xem có phải item hay không
        {
            //Destroy(other.gameObject);//xóa gameobj
            other.gameObject.SetActive(false);

            count++;
            updateScore();


        }
    }

    private void updateScore()
    {
        scoreText.text = "Count: " + count.ToString();
        if (count == 9)
        {
            Debug.Log("EndGame");
            scoreText.text = "End Game";
            Time.timeScale = 0;
        }
    }
}
