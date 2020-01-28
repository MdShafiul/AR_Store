using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsOfModel : MonoBehaviour
{
    public GameObject wheelBar;
    public GameObject suspensionBar;
    public GameObject chainBar;
    public GameObject casseteBar;

    public GameObject mountainWheelBar;
    public GameObject mountainSuspensionBar;
    public GameObject mountainChainBar;
    public GameObject mountainFreewheelBar;

    string objName;
    // Start is called before the first frame update
    void Start()
    {

        wheelBar.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if( Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began )
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if( Physics.Raycast(ray, out Hit) )
            {

                objName = Hit.transform.name;
                switch(objName)
                {

                    case "ban_sepeda_depan":
                        if (wheelBar.activeSelf)
                            wheelBar.SetActive(false);
                        else
                            wheelBar.SetActive(true);
                        break;

                    case "Cylinder_Cylinder.001":
                        if (suspensionBar.activeSelf)
                            suspensionBar.SetActive(false);
                        else
                            suspensionBar.SetActive(true);
                        break;

                    case "gear_belakang 1":
                        if (casseteBar.activeSelf)
                            casseteBar.SetActive(false);
                        else
                            casseteBar.SetActive(true);
                        break;

                    case "rantai 1":
                        if (chainBar.activeSelf)
                            chainBar.SetActive(false);
                        else
                            chainBar.SetActive(true);
                        break;

                    case "gear_depan 1":
                        if (chainBar.activeSelf)
                            chainBar.SetActive(false);
                        else
                            chainBar.SetActive(true);
                        break;

                    case "ban_depan":
                        if (mountainWheelBar.activeSelf)
                            mountainWheelBar.SetActive(false);
                        else
                            mountainWheelBar.SetActive(true);
                        break;

                    case "stank":
                        if (mountainSuspensionBar.activeSelf)
                            mountainSuspensionBar.SetActive(false);
                        else
                            mountainSuspensionBar.SetActive(true);
                        break;

                    case "ban_belakang":
                        if (mountainFreewheelBar.activeSelf)
                            mountainFreewheelBar.SetActive(false);
                        else
                            mountainFreewheelBar.SetActive(true);
                        break;

                    case "rantai":
                        if (mountainChainBar.activeSelf)
                            mountainChainBar.SetActive(false);
                        else
                            mountainChainBar.SetActive(true);
                        break;

                    case "gear_depan":
                        if (mountainChainBar.activeSelf)
                            mountainChainBar.SetActive(false);
                        else
                            mountainChainBar.SetActive(true);
                        break;

                    default:
                        break;

                }

            }

        }

    }
}
