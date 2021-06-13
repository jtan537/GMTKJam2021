using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDropoff : MonoBehaviour
{

    public TimerBar bar;
    private PackageStack stack;

    private List<PackageColor.countries> countryList = new List<PackageColor.countries>();

    [SerializeField] int lowLim = 4, highLim = 7;

    // Start is called before the first frame update
    void Start()
    {
        stack = GameObject.Find("Stack").GetComponent<PackageStack>();
        countryList.Add(PackageColor.countries.Blue);
        countryList.Add(PackageColor.countries.Green);
        countryList.Add(PackageColor.countries.Red);
        countryList.Add(PackageColor.countries.Yellow);

    }


    // Randomly adds (lowLim - highLim) number of packages from tmpList to the stack
    private void randomlyAddPackages(List<PackageColor.countries> tmpList)
    {
        for (int i = 0; i < Random.Range(lowLim, highLim + 1); i++)
        {
            stack.addPackage(tmpList[Random.Range(0, 3)]);
        }
    }


    // Give packages NOT from this country
    private void givePackages()
    {
        List<PackageColor.countries> tmpList = countryList;
        if (gameObject.tag == "Blue")
        {
            tmpList.Remove(PackageColor.countries.Blue);
            randomlyAddPackages(tmpList);
        }
        else if (gameObject.tag == "Green")
        {
            tmpList.Remove(PackageColor.countries.Green);
            randomlyAddPackages(tmpList);
        }
        else if (gameObject.tag == "Red")
        {
            tmpList.Remove(PackageColor.countries.Red);
            randomlyAddPackages(tmpList);
        }
        else if (gameObject.tag == "Yellow")
        {
            tmpList.Remove(PackageColor.countries.Yellow);
            randomlyAddPackages(tmpList);
        }
        else
        {
            Debug.LogError("Package Giver Must be Tagged!");
        }
    }

    // Recieve all packages of this country, then give a random number of packages to the player
    private void recievePackage()
    {
        int numRecieved = 0;
        if (gameObject.tag == "Blue")
        {
            numRecieved = stack.removePackages(PackageColor.countries.Blue);
        }
        else if (gameObject.tag == "Green")
        {
            numRecieved = stack.removePackages(PackageColor.countries.Green);
        }
        else if (gameObject.tag == "Red")
        {
            numRecieved = stack.removePackages(PackageColor.countries.Red);
        }
        else if (gameObject.tag == "Yellow")
        {
            numRecieved = stack.removePackages(PackageColor.countries.Yellow);
        }
        else
        {
            Debug.LogError("Package Giver Must be Tagged!");
        }

        // Only give more packages if the player delivered at least 1 package
        if (numRecieved > 0)
        {
            givePackages();
            bar.AnimateBar();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("In Dropoff Point");
            GameObject.FindObjectOfType<PlayerDropRecieve>().inDropOffPoint = true;
            if (GameObject.FindObjectOfType<PlayerDropRecieve>().dropRecievePkg is true)
            {
                Debug.Log("Drop Package off");
                recievePackage();
                GameObject.FindObjectOfType<PlayerDropRecieve>().dropRecievePkg = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Left Dropoff Point");
            GameObject.FindObjectOfType<PlayerDropRecieve>().inDropOffPoint = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
