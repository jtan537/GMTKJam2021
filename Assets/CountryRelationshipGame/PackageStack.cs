using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageStack : MonoBehaviour
{
    [SerializeField] public int maxStackSize = 11;
    [SerializeField] private float startingPkg_X, startingPkg_Y, packageHeight;

    public int numBlue, numGreen, numYellow, numRed;
    
    public List<GameObject> stack = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addPackage(PackageColor.countries color)
    {

        // Add to stack
        if (stack.Count == maxStackSize)
        {
            return;
        }
        GameObject inst;
        inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"));
        
        inst.transform.parent = gameObject.transform;
        inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
        inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
        inst.GetComponent<PackageColor>().setColor(color);
        if (stack.Count + 1 < maxStackSize / 2)
        {
            inst.GetComponent<Rigidbody2D>().mass = 20;
        }
        else if (stack.Count + 1 < 3 * maxStackSize / 4)
        {
            inst.GetComponent<Rigidbody2D>().mass = 10;
        }
        stack.Add(inst);

        // Keep track of individual pkg count
        if (color == PackageColor.countries.Green)
        {
            numGreen += 1;
        } 
        else if (color == PackageColor.countries.Blue)
        {
            numBlue += 1;
        }
        else if (color == PackageColor.countries.Red)
        {
            numRed += 1;
        }
        else if (color == PackageColor.countries.Yellow)
        {
            numYellow += 1;
        }
    }
    /*    public void addPackage(PackageColor.countries color)
        {
            if (stack.Count == maxStackSize)
            {
                return;
            }
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
        }*/

    public int removePackages(PackageColor.countries color)
    {
        int numRemoved = 0;
        // Ignore bottom tray object
        for (int i = stack.Count - 1; i > 0; i--)
        {
            GameObject pkg = stack[i];
            if (pkg.GetComponent<PackageColor>().packageColor == color)
            {
                // 1. Lower each package above the deleted one, if there are packages above it
                if (i + 1 < stack.Count)
                {
                    for (int j = i + 1; j < stack.Count; j++)
                    {
                        Debug.Log("lower");
                        GameObject lower_pkg = stack[j];
                        lower_pkg.transform.position = new Vector3(lower_pkg.transform.position.x, lower_pkg.transform.position.y - packageHeight, 0f);
                    }
                }

                // 2. Set the hinge joint of the box above deleted to the box below deleted
                if (i - 1 >= 0 && i + 1 < stack.Count)
                {
                    stack[i + 1].GetComponent<HingeJoint2D>().connectedBody = stack[i - 1].GetComponent<Rigidbody2D>();
                }


                // 3. Delete the package
                stack.Remove(pkg);
                Destroy(pkg);

                numRemoved += 1;

            }
        }

        // Keep track of individual pkg count
        if (color == PackageColor.countries.Green)
        {
            numGreen = 0;
        }
        else if (color == PackageColor.countries.Blue)
        {
            numBlue = 0;
        }
        else if (color == PackageColor.countries.Red)
        {
            numRed = 0;
        }
        else if (color == PackageColor.countries.Yellow)
        {
            numYellow = 0;
        }
        return numRemoved;
    }


    /*    public void removePackages()
        {
            int numRemoved = 0;
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                GameObject pkg = stack[i];
                if (pkg.GetComponent<PackageColor>().packageColor == PackageColor.countries.Blue)
                {


                    // 1. If deleted is bottom box, and not the last box in the stack, set above box to first box
                    if (i == 0 && stack.Count > 1)
                    {
                        Destroy(stack[i + 1].GetComponent<HingeJoint2D>());
                        stack[i + 1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    }

                    // 2. Lower each package above the deleted one, if there are packages above it
                    if (i + 1 < stack.Count)
                    {
                        for (int j = i + 1; j < stack.Count; j++)
                        {
                            Debug.Log("lower");
                            GameObject lower_pkg = stack[j];
                            lower_pkg.transform.position = new Vector3(lower_pkg.transform.position.x, lower_pkg.transform.position.y - packageHeight, 0f);
                        }
                    }



                    // 3. Set the hinge joint of the box above deleted to the box below deleted
                    if (i - 1 >= 0 && i + 1 < stack.Count)
                    {
                        stack[i + 1].GetComponent<HingeJoint2D>().connectedBody = stack[i - 1].GetComponent<Rigidbody2D>();
                    }


                    // 4. Delete the package
                    stack.Remove(pkg);
                    Destroy(pkg);

                    numRemoved += 1;
                }
            }*/

    /*
     * BUG TESTING FUNCTIONS
     * */

    // For bug testing purposes, used with UI button to add a blue/green/yellow/red package
    public void addBluePackage()
    {
        if (stack.Count == maxStackSize)
        {
            return;
        }
        GameObject inst;
        inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"), gameObject.transform);
        inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
        inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
/*        inst.GetComponent<PackageColor>().setColor((PackageColor.countries)Random.Range(0, 4));*/
        inst.GetComponent<PackageColor>().setColor(PackageColor.countries.Blue);
        if (stack.Count + 1 < maxStackSize / 2)
        {
            inst.GetComponent<Rigidbody2D>().mass = 20;
        } else if (stack.Count + 1 < 3 * maxStackSize / 4)
        {
            inst.GetComponent<Rigidbody2D>().mass = 10;
        }
        stack.Add(inst);
    }
    public void addRedPackage()
    {
        if (stack.Count == maxStackSize)
        {
            return;
        }
        GameObject inst;

        inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"), gameObject.transform);
        inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
        inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
        inst.GetComponent<PackageColor>().setColor(PackageColor.countries.Red);
        if (stack.Count + 1 < maxStackSize / 2)
        {
            inst.GetComponent<Rigidbody2D>().mass = 20;
        }
        else if (stack.Count + 1 < 3 * maxStackSize / 4)
        {
            inst.GetComponent<Rigidbody2D>().mass = 10;
        }
        stack.Add(inst);
    }
    public void addGreenPackage()
    {
        if (stack.Count == maxStackSize)
        {
            return;
        }
        GameObject inst;
        inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"), gameObject.transform);
        inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
        inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
        inst.GetComponent<PackageColor>().setColor(PackageColor.countries.Green);
        if (stack.Count + 1 < maxStackSize / 2)
        {
            inst.GetComponent<Rigidbody2D>().mass = 20;
        }
        else if (stack.Count + 1 < 3 * maxStackSize / 4)
        {
            inst.GetComponent<Rigidbody2D>().mass = 10;
        }
        stack.Add(inst);
    }
    public void addYellowPackage()
    {
        if (stack.Count == maxStackSize)
        {
            return;
        }
        GameObject inst;

        inst = Instantiate(Resources.Load<GameObject>("Prefabs/OtherPackage"), gameObject.transform);
        inst.GetComponent<HingeJoint2D>().connectedBody = stack[stack.Count - 1].GetComponent<Rigidbody2D>();
        inst.transform.localPosition = new Vector3(startingPkg_X, startingPkg_Y + packageHeight * stack.Count, 0f);
        inst.GetComponent<PackageColor>().setColor(PackageColor.countries.Yellow);
        if (stack.Count + 1 < maxStackSize / 2)
        {
            inst.GetComponent<Rigidbody2D>().mass = 20;
        }
        else if (stack.Count + 1 < 3 * maxStackSize / 4)
        {
            inst.GetComponent<Rigidbody2D>().mass = 10;
        }
        stack.Add(inst);
    }

    // For bug testing purposes, used with UI button to delete a blue/green package
    public void removeBluePackages()
    {
        int numRemoved = 0;
        // Ignore bottom tray object
        for (int i = stack.Count - 1; i > 0; i--)
        {
            GameObject pkg = stack[i];
            if (pkg.GetComponent<PackageColor>().packageColor == PackageColor.countries.Blue)
            {
                // 1. Lower each package above the deleted one, if there are packages above it
                if (i + 1 < stack.Count)
                {
                    for (int j = i + 1; j < stack.Count; j++)
                    {
                        Debug.Log("lower");
                        GameObject lower_pkg = stack[j];
                        lower_pkg.transform.position = new Vector3(lower_pkg.transform.position.x, lower_pkg.transform.position.y - packageHeight, 0f);
                    }
                }

                // 2. Set the hinge joint of the box above deleted to the box below deleted
                if (i - 1 >= 0 && i + 1 < stack.Count)
                {
                    stack[i + 1].GetComponent<HingeJoint2D>().connectedBody = stack[i - 1].GetComponent<Rigidbody2D>();
                }


                // 3. Delete the package
                stack.Remove(pkg);
                Destroy(pkg);

                numRemoved += 1;
            }
        }
    }

    public void removeGreenPackages()
    {
        int numRemoved = 0;
        // Ignore bottom tray object
        for (int i = stack.Count - 1; i > 0; i--)
        {
            GameObject pkg = stack[i];
            if (pkg.GetComponent<PackageColor>().packageColor == PackageColor.countries.Green)
            {
                // 1. Lower each package above the deleted one, if there are packages above it
                if (i + 1 < stack.Count)
                {
                    for (int j = i + 1; j < stack.Count; j++)
                    {
                        Debug.Log("lower");
                        GameObject lower_pkg = stack[j];
                        lower_pkg.transform.position = new Vector3(lower_pkg.transform.position.x, lower_pkg.transform.position.y - packageHeight, 0f);
                    }
                }

                // 2. Set the hinge joint of the box above deleted to the box below deleted
                if (i - 1 >= 0 && i + 1 < stack.Count)
                {
                    stack[i + 1].GetComponent<HingeJoint2D>().connectedBody = stack[i - 1].GetComponent<Rigidbody2D>();
                }


                // 3. Delete the package
                stack.Remove(pkg);
                Destroy(pkg);

                numRemoved += 1;
            }
        }
    }
}
