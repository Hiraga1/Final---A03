using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogs
{
    public string name;

    [TextArea(3, 10)]
    public string[] lines; 

}
