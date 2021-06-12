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

}
