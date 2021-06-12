using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPkgButton : MonoBehaviour
{
    private Button myButton;
    PackageStack stack;

    public bool isRemovingButton = false;
    public int color;
    // Start is called before the first frame update
    void Start()
    {
        stack = GameObject.FindObjectOfType<PackageStack>();

        myButton = GetComponent<Button>();
        if (isRemovingButton)
        {
            if (color == 0)
            {
                myButton.onClick.AddListener(() => stack.removePackages(PackageColor.countries.Blue));
            }
            else if (color == 1)
            {
                myButton.onClick.AddListener(() => stack.removePackages(PackageColor.countries.Green));
            }
            else if (color == 2)
            {
                myButton.onClick.AddListener(() => stack.removePackages(PackageColor.countries.Red));
            }
            else if (color == 3)
            {
                myButton.onClick.AddListener(() => stack.removePackages(PackageColor.countries.Yellow));
            }
        } else
        {
            if (color == 0)
            {
                myButton.onClick.AddListener(() => stack.addPackage(PackageColor.countries.Blue));
            }
            else if (color == 1)
            {
                myButton.onClick.AddListener(() => stack.addPackage(PackageColor.countries.Green));
            }
            else if (color == 2)
            {
                myButton.onClick.AddListener(() => stack.addPackage(PackageColor.countries.Red));
            }
            else if (color == 3)
            {
                myButton.onClick.AddListener(() => stack.addPackage(PackageColor.countries.Yellow));
            }
        }
        
    }

}
