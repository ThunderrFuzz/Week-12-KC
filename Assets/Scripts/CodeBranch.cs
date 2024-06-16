/*
 * 
#define SOME_SYMBOL
#if SOME_SYMBOL
//symobl is defiend
#else
//symbol is undefined
#endif

//#undef SOME_SYMBOL
#if SOME_SYMBOL
// SYMBOL IS ALREADY DEFIEND 
#else
//SYMBOL IS UNDEFEIND
#endif 


*/




using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeBranch : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        string platforminfo = "Project is running";
#if UNITY_EDITOR
        platforminfo += " In the editor";
#elif UNITY_WEBGL
        platforminfo += " oN THE WEB";
#else
        platforminfo += " As a build";
#endif
        text.text = platforminfo;
    }

  
}
