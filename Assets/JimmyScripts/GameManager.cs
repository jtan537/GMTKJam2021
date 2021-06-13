using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string, float> diplomacyPoints = new Dictionary<string, float>();
    [SerializeField]
    List<PackageColor.countries> startingPkgs;

    [SerializeField]
    GameObject loseScreen, winScreen;

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

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        diplomacyPoints = new Dictionary<string, float>();
        diplomacyPoints.Add("Blue", 50f);
        diplomacyPoints.Add("Green", 50f);
        diplomacyPoints.Add("Red", 50f);
        diplomacyPoints.Add("Yellow", 50f);
        stack = GameObject.Find("Stack").GetComponent<PackageStack>();
        foreach (PackageColor.countries country in startingPkgs)
        {
            stack.addPackage(country);
        }
        Debug.Log("Level Loaded");
    }


    void checkWinCon()
    {
        if (diplomacyPoints["Blue"] >= 80f && diplomacyPoints["Green"] >= 80f && diplomacyPoints["Red"] >= 80f && diplomacyPoints["Yellow"] >= 80f)
        {
            Debug.Log("WIN GAME!");
            winScreen.SetActive(true);
        }
    }

    void checkLoseCon()
    {
        if (diplomacyPoints["Blue"] <= 0f || diplomacyPoints["Green"] <= 0f || diplomacyPoints["Red"] <= 0f || diplomacyPoints["Yellow"] <= 0f)
        {
            Debug.Log("LOSE GAME!");
            loseScreen.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkLoseCon();
        checkWinCon();
    }
}
