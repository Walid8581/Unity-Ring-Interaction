using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToSee : MonoBehaviour
{
    public Text textshowed = null;
    public void changeword(string word)
    {

        textshowed.text = word;
    }
}
