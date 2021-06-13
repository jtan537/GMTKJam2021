using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class TimerBar : MonoBehaviour
{
    GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        bar = gameObject;
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.transform.localScale.x <= 0.05f)
        {
            if (gameObject.tag == "Blue")
            {
                GameManager.diplomacyPoints["Blue"] -= 20f;
            }
            else if (gameObject.tag == "Green")
            {
                GameManager.diplomacyPoints["Green"] -= 20f;
            }
            else if (gameObject.tag == "Red")
            {
                GameManager.diplomacyPoints["Red"] -= 20f;
            }
            else if (gameObject.tag == "Yellow")
            {
                GameManager.diplomacyPoints["Yellow"] -= 20f;
            }
            else
            {
                Debug.LogError("Package Giver Must be Tagged!");
            }
            AnimateBar();
        }
    }

    public void AnimateBar()
    {
        LeanTween.cancel(bar);
        bar.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scaleX(bar, 0, time);
    }
}
