using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ChangeText(string message)
    {
        text.text = message;
    }
}
