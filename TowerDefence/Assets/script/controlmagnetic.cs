using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlmagnetic : MonoBehaviour {

    public bool magnetDetectionEnabled = true;
    public Text m_MyText;
    int klikniecia;
    public static bool nacelowanie;
    public static bool niszczenie = false;


    void Start()
    {
        magnetfull.SetEnabled(magnetDetectionEnabled);
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        klikniecia = 0;
        nacelowanie = false;
        
    }

    public static bool Znniszcz()
    {
        return niszczenie;
    }

    void Update()
    {
        // magnetfull.CheckIfWasClicked()
        if (!magnetDetectionEnabled) return;
        if ( magnetfull.CheckIfWasClicked())
        {
           // Debug.Log("DO SOMETHING HERE");  // PERFORM ACTION.
            klikniecia += 1;
            m_MyText.text = "Zniszczeni przeciwnicy:" + klikniecia;
            
           
            niszczenie = true;
            Znniszcz();
            magnetfull.ResetClick();

        }
    }

    public void sprawdzaj(GameObject obiekt)
    {
        nacelowanie = true;
    }

    public void anulujSprawdzanie()
    {
        nacelowanie = false;
        niszczenie = false;
    }

   
}

