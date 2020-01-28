using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;
using Proyecto26;

public class AR_buttons : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject simulaBike;
    public GameObject mountainBike;
    public GameObject formula1;

    public GameObject[] infoBarsSimulaBike;
    public GameObject[] infoBarsMountainBike;
    public GameObject[] infoBarsFormula1;

    VirtualButtonBehaviour[] virtualButtonBehaviours;

    public GameObject submitWin0, submitWin1, orderWindow, menuButton, warningToast, loadInfo;

    public static string vehicleName, customerName, customerAddress, customerContact, timeNDate;
    public static int price, shipping, trackingId = 13;
    public TMP_InputField inputCustomerName;
    public TMP_InputField inputCustomerAddress;
    public TMP_InputField inputCustomerContact;

    public TextMeshProUGUI textVehicleName, textPrice, textShipping, totalCost;
    public TextMeshPro showPrice;

    Tracking_Code tracking_Code = new Tracking_Code();

    // Start is called before the first frame update
    void Start()
    {

        GetTrackingID();
        trackingId = PlayerPrefs.GetInt("trackingId");
        loadInfo.SetActive(true);

        simulaBike.SetActive(false);
        mountainBike.SetActive(false);
        formula1.SetActive(false);

        submitWin0.SetActive(false);
        submitWin1.SetActive(false);
        orderWindow.SetActive(false);

        warningToast.SetActive(false);

        if (infoBarsSimulaBike.Length > 0)
        {
            foreach (GameObject infoBar in infoBarsSimulaBike)
            {
                infoBar.SetActive(false);
            }
        }

        if (infoBarsMountainBike.Length > 0)
        {
            foreach (GameObject infoBar in infoBarsMountainBike)
            {
                infoBar.SetActive(false);
            }
        }

        if (infoBarsSimulaBike.Length > 0)
        {
            foreach (GameObject infoBar in infoBarsSimulaBike)
            {
                infoBar.SetActive(false);
            }
        }

        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
            virtualButtonBehaviours[i].RegisterEventHandler(this);

    }

    // Update is called once per frame
    void Update()
    {

        if (trackingId > 0)
            loadInfo.SetActive(false);

        if (simulaBike.activeSelf)
            VehicleDescription("Simula Bike", 185, 20);

        else if (mountainBike.activeSelf)
            VehicleDescription("Mountain Bike", 225, 30);

        else if (formula1.activeSelf)
            VehicleDescription("Formula 1", 10750000, 500);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        string vBName;

        vBName = vb.VirtualButtonName;

        if (vBName == "info")
        {

            if (simulaBike.activeSelf)
            {

                int barNo = 0;

                if (infoBarsSimulaBike.Length > 0)
                {

                    foreach (GameObject infoBar in infoBarsSimulaBike)
                    {
                        if (infoBar.activeSelf)
                            barNo++;
                        infoBar.SetActive(true);
                    }

                    if (infoBarsSimulaBike.Length == barNo)
                    {
                        foreach (GameObject infoBar in infoBarsSimulaBike)
                        {
                            infoBar.SetActive(false);
                        }
                    }

                }

                //        if( infoBar.activeSelf )
                //            infoBar.SetActive(false);

            }

            else if (mountainBike.activeSelf)
            {

                int barNo = 0;  // to check active infoBar

                if (infoBarsMountainBike.Length > 0)
                {

                    foreach (GameObject infoBar in infoBarsMountainBike)
                    {
                        if (infoBar.activeSelf)
                            barNo++;
                        infoBar.SetActive(true);
                    }

                    if (infoBarsMountainBike.Length == barNo)
                    {
                        foreach (GameObject infoBar in infoBarsMountainBike)
                        {
                            infoBar.SetActive(false);
                        }
                    }

                }

                //        if( infoBar.activeSelf )
                //            infoBar.SetActive(false);

            }

            else if (formula1.activeSelf)
            {

                int barNo = 0;

                if (infoBarsFormula1.Length > 0)
                {

                    foreach (GameObject infoBar in infoBarsFormula1)
                    {
                        if (infoBar.activeSelf)
                            barNo++;
                        infoBar.SetActive(true);
                    }

                    if (infoBarsFormula1.Length == barNo)
                    {
                        foreach (GameObject infoBar in infoBarsFormula1)
                        {
                            infoBar.SetActive(false);
                        }
                    }

                }

                //        if( infoBar.activeSelf )
                //            infoBar.SetActive(false);

            }

        }

        else if (vBName == "buy")
        {
            if (simulaBike.activeSelf || mountainBike.activeSelf || formula1.activeSelf)
            {
                orderWindow.SetActive(true);
                submitWin0.SetActive(true);
                menuButton.SetActive(false);
            }
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

    public void back0()
    {
        orderWindow.SetActive(false);
        submitWin0.SetActive(false);
        menuButton.SetActive(true);
    }

    public void next0()
    {
        submitWin1.SetActive(true);
        submitWin0.SetActive(false);
    }

    public void back1()
    {
        submitWin1.SetActive(false);
        submitWin0.SetActive(true);
    }

    public void OnSubmit()
    {

        customerName = inputCustomerName.text;
        customerAddress = inputCustomerAddress.text;
        customerContact = inputCustomerContact.text;

        if (!(string.IsNullOrEmpty(inputCustomerName.text) || string.IsNullOrEmpty(inputCustomerAddress.text) || string.IsNullOrEmpty(inputCustomerContact.text)))
        {

            PostToDatabase();
            submitWin1.SetActive(false);
            orderWindow.SetActive(false);
            menuButton.SetActive(true);

            inputCustomerName.text = "";
            inputCustomerAddress.text = "";
            inputCustomerContact.text = "";

        }
        
        else // if the form is incomplete
        {

            warningToast.SetActive(true);
            StartCoroutine(ToastCoroutine());

        }

    }

    IEnumerator ToastCoroutine()
    {

        //yield on a new YieldInstruction that waits for .75 seconds.
        yield return new WaitForSeconds(.75f);
        warningToast.SetActive(false);

    }

    private void PostToDatabase()
    {
        timeNDate = System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
        GetTrackingID();
        Customer customer = new Customer();
        RestClient.Put("https://##########.firebaseio.com/" + trackingId + ".json", customer);  // firebase database link

        trackingId = PlayerPrefs.GetInt("trackingId") + 1;

        //update tracking id
        Tracking_Code tracking_Code1 = new Tracking_Code();

        RestClient.Put("https://########.firebaseio.com/" + "Tracker" + ".json", tracking_Code1);  // firebase database link
    }

    private void GetTrackingID()
    {
                                                // firebase database link
        RestClient.Get<Tracking_Code>("https://##########.firebaseio.com/" + "Tracker" + ".json").Then(response =>
        {
            tracking_Code = response;
            trackingId = tracking_Code.id;
            PlayerPrefs.SetInt("trackingId", trackingId);
        });

    }

    public void VehicleDescription(string vName, int vPrice, int vShipping)
    {

        vehicleName = vName;
        price = vPrice;
        shipping = vShipping;
        textVehicleName.text = vehicleName;
        textPrice.text = price.ToString() + "$";
        textShipping.text = shipping.ToString() + "$";
        totalCost.text = (price + shipping).ToString() + "$";

        showPrice.text = price.ToString() + "$";

        timeNDate = System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");

    }

}
