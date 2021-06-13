using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class GuardAI : MonoBehaviour
{
    public float moveSpeed = 10f;
    bool isAngry = false;
    bool movingRight = true;
    Transform leftPoint, rightPoint;
    // Start is called before the first frame update
    void Start()
    {
        leftPoint = gameObject.transform.parent.transform.Find("LeftPoint");
        rightPoint = gameObject.transform.parent.transform.Find("RightPoint");
    }

    void moveGuard(float diplomacyPoints)
    {
        if (diplomacyPoints < 40f)
        {
            if (movingRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
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
        Debug.Log(rightPoint.position.x);
        if (gameObject.transform.position.x <= leftPoint.position.x)
        {
            Debug.Log(leftPoint.position.x);
            movingRight = true;
        }
        if (gameObject.transform.position.x >= rightPoint.position.x)
        {
            Debug.Log(rightPoint.position.x);
            movingRight = false;
        }  
    }
}
