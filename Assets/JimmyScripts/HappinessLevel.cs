using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HappinessLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setEmotion(float diplomacyPoints)
    {
        Image image = gameObject.GetComponent<Image>();
        if (diplomacyPoints < 20f)
        {
            image.sprite = Resources.Load<Sprite>("Emotions/angry");
        }
        else if (diplomacyPoints < 40f)
        {
            image.sprite = Resources.Load<Sprite>("Emotions/unhappy");
        }
        else if (diplomacyPoints < 60f)
        {
            image.sprite = Resources.Load<Sprite>("Emotions/neutral");
        }
        else if (diplomacyPoints < 80f)
        {
            image.sprite = Resources.Load<Sprite>("Emotions/happy");
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Emotions/very-happy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Blue")
        {
            setEmotion(GameManager.diplomacyPoints["Blue"]);
        }
        else if (gameObject.tag == "Green")
        {
            setEmotion(GameManager.diplomacyPoints["Green"]);
        }
        else if (gameObject.tag == "Red")
        {
            setEmotion(GameManager.diplomacyPoints["Red"]);
        }
        else if (gameObject.tag == "Yellow")
        {
            setEmotion(GameManager.diplomacyPoints["Yellow"]);
        }
        else
        {
            Debug.LogError("Package Giver Must be Tagged!");
        }
    }
}
