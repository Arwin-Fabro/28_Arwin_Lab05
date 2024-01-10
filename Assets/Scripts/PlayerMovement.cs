using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float speed;
    private int Coins;
    private int TotalCoins;
    public Text coinText;

    private int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        TotalCoins = GameObject.FindGameObjectsWithTag("Coins").Length;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        coinText.text = "Coins :" + Coins;
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coins")
        {
            Coins++;
            Destroy(other.gameObject);
            if (Coins == TotalCoins)
            {
                SceneManager.LoadScene(nextSceneLoad);
            }
        }
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
