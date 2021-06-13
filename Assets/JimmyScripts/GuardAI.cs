using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class GuardAI : MonoBehaviour
{
    public float moveSpeed = 10f;
    bool movingRight = true;
    Transform leftPoint, rightPoint;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        leftPoint = gameObject.transform.parent.transform.Find("LeftPoint");
        rightPoint = gameObject.transform.parent.transform.Find("RightPoint");
        anim = GetComponent<Animator>();

    }

    void moveGuard(float diplomacyPoints)
    {
        if (diplomacyPoints < 60f)
        {
            gameObject.layer = 9;
            if (movingRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            anim.SetBool("isAngry", true);
        } else
        {
            gameObject.layer = 8;
            anim.SetBool("isAngry", false);
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "Blue")
        {
            moveGuard(GameManager.diplomacyPoints["Blue"]);
        }
        else if (gameObject.tag == "Green")
        {
            moveGuard(GameManager.diplomacyPoints["Green"]);
        }
        else if (gameObject.tag == "Red")
        {
            moveGuard(GameManager.diplomacyPoints["Red"]);
        }
        else if (gameObject.tag == "Yellow")
        {
            moveGuard(GameManager.diplomacyPoints["Yellow"]);
        }
        else
        {
            Debug.LogError("Package Giver Must be Tagged!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
        }
        if (gameObject.transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
        }  
    }
}
