using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    private int scoreVal = 0;

    public TextMeshProUGUI scoreBox;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 1f), Mathf.Clamp(transform.position.y, -4.4f, 4f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if(collision.GetComponent<ProjectileMove>() != null)
            {
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBox.text = "Score: " + scoreVal;
            }
            Destroy(collision.gameObject);
        }
    }
}