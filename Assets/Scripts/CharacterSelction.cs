using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelction : MonoBehaviour
{

    // Start is called before the first frame update
    private int selection;
    static int value;
    
    public void chooseCharacterOne()
    {
        /* selection = 1;
         value = selection; ; */
        //DontDestroyOnLoad(this.selection);
        SetInt("selection", 1);
        Debug.Log("Character 1 is chosen");
    }
    
    public int returnValue()
    {
        selection = Getint("selection");
        return selection;
    }
    public void chooseCharacterTwo()
    {
        /*value = selection;
        selection = 2;*/
        SetInt("selection", 2);
        Debug.Log("Character 2 is chosen");
    }
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

}
