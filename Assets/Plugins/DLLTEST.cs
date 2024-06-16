using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.Rendering;


public class DLLTEST : MonoBehaviour
{
#if UNITY_IOS
    const string dll = "_Internal";
#else
    const string dll = "TestingCustomDLLUnity";
#endif
    [DllImport(dll)]
    private static extern int DieRoll(int sides);
    [DllImport(dll)]
    private static extern float Add(float a, float b);
    [DllImport(dll)]
    private static extern IntPtr HelloWorld();
    [DllImport(dll)]
    private static extern void SeedRandomizer();
    [DllImport(dll)]
    private static extern int Random();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Add(1.5f, 5.25f));
        Debug.Log(Marshal.PtrToStringAnsi(HelloWorld()));
        Debug.Log("6 sided die roll:  " + DieRoll(6));
        Debug.Log("12 sided die roll:  " + DieRoll(12));
        Debug.Log(Random() + " Dll random numbner generated");
    }
}
