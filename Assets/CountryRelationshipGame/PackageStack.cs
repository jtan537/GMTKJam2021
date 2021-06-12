using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageStack : MonoBehaviour
{
    [SerializeField] public int maxStackSize = 10;
    [SerializeField] private float startingPkg_X, startingPkg_Y, packageHeight;
    
    public List<GameObject> stack = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // For bug testing purposes, used with UI button to add a package
    public void addPackage()
    {
        GameObject inst;
        if (stack.Count == 0)
        {
            inst = Instantiate(Resources.Load<GameObject>("Prefabs/FirstPackage"), gameObject.transform);
            inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y, 0f);
        }
        else
        {
            inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"), gameObject.transform);
            inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
            inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
        }
        inst.GetComponent<PackageColor>().setColor(PackageColor.countries.Blue);
        stack.Add(inst);
    }
    public void addPackage(PackageColor.countries color)
    {
        GameObject inst;
        if (stack.Count == 0)
        {
            inst = Instantiate(Resources.Load<GameObject>("Prefabs/FirstPackage"));
            inst.transform.parent = gameObject.transform;
            inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y, 0f);
        }
        else
        {
            inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"));
            inst.transform.parent = gameObject.transform;
            inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);

        }
        inst.GetComponent<PackageColor>().setColor(color);
        stack.Add(inst);
    }

/*    public int removePackages(countries color)
    {
        int numRemoved = 0;
        foreach (countries country in stack)
        {
            stack.Remove(country);
            numRemoved += 1;
        }
        return numRemoved;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
