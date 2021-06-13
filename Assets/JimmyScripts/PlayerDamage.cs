using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{


    [SerializeField]
    private float invincibilityDurationSeconds;
    [SerializeField]
    private float invincibilityDeltaTime;

    private float ogMoveSpeed;
    public bool isInvincible = false;

    SpriteRenderer sr;

    [SerializeField]
    private int numPkgsLose = 2;
    PackageStack stack;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        stack = GameObject.FindObjectOfType<PackageStack>();
        ogMoveSpeed = gameObject.GetComponent<PlayerController>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        stack = GameObject.FindObjectOfType<PackageStack>();
    }

    void applyDamage()
    {
        gameObject.GetComponent<PlayerController>().moveSpeed /= 1.5f;
        if (stack.stack.Count > 2)
        {
            for (int i = 0; i < numPkgsLose; i++)
            {
                int randInd = Random.Range(1, stack.stack.Count);
                Debug.Log(randInd);
                stack.damagePackage(stack.stack[randInd].GetComponent<PackageColor>().packageColor);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible)
        {
            return;
        }
        if (!isInvincible && collision.gameObject.layer == 9)
        {
            applyDamage();
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private void ScaleAlphaTo(float a)
    {
        Color tmp = sr.color;
        tmp.a = a;
        sr.color = tmp;
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (sr.color.a == 1f)
            {
                ScaleAlphaTo(0f);
            }
            else
            {
                ScaleAlphaTo(1f);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        gameObject.GetComponent<PlayerController>().moveSpeed = ogMoveSpeed;
        Debug.Log("Player is no longer invincible!");
        ScaleAlphaTo(1f);
        isInvincible = false;
    }
}
