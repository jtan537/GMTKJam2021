using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string, float> diplomacyPoints = new Dictionary<string, float>();
    [SerializeField]
    List<PackageColor.countries> startingPkgs;

    [SerializeField]
    Image loseScreen, winScreen;

    PackageStack stack;
    // Start is called before the first frame update
    private void Start()
    {
        diplomacyPoints.Add("Blue", 50f);
        diplomacyPoints.Add("Green", 50f);
        diplomacyPoints.Add("Red", 50f);
        diplomacyPoints.Add("Yellow", 50f);

        stack = GameObject.Find("Stack").GetComponent<PackageStack>();
        foreach(PackageColor.countries country in startingPkgs)
        {
            stack.addPackage(country);
        }
        
    }

    void checkWinCon()
    {
        if (diplomacyPoints["Blue"] >= 80f && diplomacyPoints["Green"] >= 80f && diplomacyPoints["Red"] >= 80f && diplomacyPoints["Yellow"] >= 80f)
        {
            Debug.Log("WIN GAME!");
            winScreen.enabled = true;
        }
    }

    void checkLoseCon()
    {
        if (diplomacyPoints["Blue"] <= 0f || diplomacyPoints["Green"] <= 0f || diplomacyPoints["Red"] <= 0f && diplomacyPoints["Yellow"] <= 0f)
        {
            Debug.Log("LOSE GAME!");
            loseScreen.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkLoseCon();
        checkWinCon();
    }
}
