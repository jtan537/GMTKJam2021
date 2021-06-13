using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string, float> diplomacyPoints = new Dictionary<string, float>();
    public float bPts, gPts, rPts, yPts;

    PackageStack stack;
    // Start is called before the first frame update
    private void Start()
    {
        diplomacyPoints.Add("Blue", 50f);
        diplomacyPoints.Add("Green", 50f);
        diplomacyPoints.Add("Red", 50f);
        diplomacyPoints.Add("Yellow", 50f);

        stack = GameObject.Find("Stack").GetComponent<PackageStack>();
        stack.addPackage(PackageColor.countries.Red);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(bluePts);
/*        foreach (KeyValuePair<string,float> country in diplomacyPoints)
        {

        }*/
    }
}
