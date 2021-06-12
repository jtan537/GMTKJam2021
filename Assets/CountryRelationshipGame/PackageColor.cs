using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageColor : MonoBehaviour
{
    public enum countries { Blue, Red, Green, Yellow };
    public countries packageColor;

    public void setColor (countries color)
    {
        packageColor = color;
    }

    private void Update()
    {
        if (packageColor == countries.Blue)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (packageColor == countries.Red)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (packageColor == countries.Green)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (packageColor == countries.Yellow)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

    }

}
