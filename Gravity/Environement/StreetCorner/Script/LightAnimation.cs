using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightAnimation : MonoBehaviour
{
    [Space(10)]
    [Header("Determine light behaviors")]
    [Space(20)]
    [Range(1,40)]public float greenLightTime;
    [Range(1, 6)] public float yellowLightTime;
    public bool pedestrianLight;
    [Range(1, 40)] public float PedTime;
    [Range(1, 40)] public float counterTime;
    
    [Space(50)]
   
    [HideInInspector] public bool blinking;
    [Space(-20)]
    [SerializeField] private Material NSRed, EWRed, NSGre, EWGre, NSYel, EWYel, EWPed, NSPed;
    public Material eWPed;
    public Material nSPed;
    [HideInInspector]
    public int lightCase = 0;
    private GameObject master;

    
    

   
    //[SerializeField] private bool button;

    private List<GameObject> ewbuttons = new List<GameObject>();
    private List<GameObject> nsButtons = new List<GameObject>();
    private List<GameObject> buttons = new List<GameObject>(); //button not used in this version
    private List<GameObject> pedLights = new List<GameObject>();
    [HideInInspector] public List<GameObject> nsCounters;
    [HideInInspector] public List<GameObject> ewCounters;
    [HideInInspector] public List<GameObject> allCounters;
    [HideInInspector]
    public bool ewPedestrianCrossing, nsPedestrianCrossing, ewCarCrossing, nsCarCrossing;

    [SerializeField] private GameObject ew, ns, ped;
   


    private void Start()
    {
        
        
        foreach (GameObject pedLight in GameObject.FindGameObjectsWithTag("PedLight"))
        {
            pedLights.Add(pedLight);
        }
        foreach (GameObject ewCounter in GameObject.FindGameObjectsWithTag("EWCounter"))
        {
            ewCounters.Add(ewCounter);
            allCounters.Add(ewCounter);
        }
        foreach (GameObject nsCounter in GameObject.FindGameObjectsWithTag("NSCounter"))
        {
            ewCounters.Add(nsCounter);
            allCounters.Add(nsCounter);
        }


        foreach (GameObject button in GameObject.FindGameObjectsWithTag("EWPedButton"))
            {
            ewbuttons.Add(button);
            buttons.Add(button);
        }
        foreach(GameObject button in GameObject.FindGameObjectsWithTag("NSPedButton"))
            {
            nsButtons.Add(button);
            buttons.Add(button);
        }

        
        
        foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }

        

        if (!pedestrianLight)
        {
            foreach (GameObject pedlight in pedLights)
            {
                pedlight.SetActive(false);
            }

        }


    }

    private void UpdateLight(int lightCase)
    {
        switch (lightCase)
        {
            case 1:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 0);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 1);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                ewPedestrianCrossing = false;
                nsPedestrianCrossing = false;
                ewCarCrossing = true;
                nsCarCrossing = false;
                ew.SetActive(true);
                blinking = false;
                break;

            case 2:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 0);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                ew.SetActive(false);
                blinking = false;
                ewPedestrianCrossing = false;
                nsPedestrianCrossing = false;
                ewCarCrossing = false;
                nsCarCrossing = false;
                blinking = false;
                break;
            case 3:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 0);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;

                break;
            case 4:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 0);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;


            case 5:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;

            case 6:
                NSRed.SetFloat("_OnOff", 0);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;
            case 7:
                NSRed.SetFloat("_OnOff", 0);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 1);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                ns.SetActive(true);
                blinking = false;
                ewPedestrianCrossing = false;
                nsPedestrianCrossing = false;
                ewCarCrossing = false;
                nsCarCrossing = true;
                blinking = false;
                break;
            case 8:
                NSRed.SetFloat("_OnOff", 0);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                ns.SetActive(false);
                blinking = false;
                break;
            case 9:
                NSRed.SetFloat("_OnOff", 0);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 1);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;
            case 10:
                NSRed.SetFloat("_OnOff", 0);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;
            case 11:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;
            case 12:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;
            case 13:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOffMan", 1);
                EWPed.SetFloat("_OnOff", 0);
                EWPed.SetFloat("_OnOffMan", 1);
                ped.SetActive(true);
                ewPedestrianCrossing = true;
                nsPedestrianCrossing = true;
                ewCarCrossing = false;
                nsCarCrossing = false;

                blinking = false;
                break;
            case 14:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = false;
                break;

            case 15:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                blinking = true;
                break;
            case 16:
                NSRed.SetFloat("_OnOff", 1);
                EWRed.SetFloat("_OnOff", 1);
                NSGre.SetFloat("_OnOff", 0);
                EWGre.SetFloat("_OnOff", 0);
                NSYel.SetFloat("_OnOff", 0);
                EWYel.SetFloat("_OnOff", 0);
                NSPed.SetFloat("_OnOff", 1);
                NSPed.SetFloat("_OnOffMan", 0);
                EWPed.SetFloat("_OnOff", 1);
                EWPed.SetFloat("_OnOffMan", 0);
                ped.SetActive(false);
                blinking = true;
                break;


        }

    }


}

