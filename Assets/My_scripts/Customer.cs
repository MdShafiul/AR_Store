using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{

    public string vehicleName , customerName , customerAddress , customerContact , timeNDate;
    public int price, shipping, trackingId;

    public Customer()
    {

        vehicleName = AR_buttons.vehicleName;
        customerName = AR_buttons.customerName;
        customerAddress = AR_buttons.customerAddress;
        customerContact = AR_buttons.customerContact;
        price = AR_buttons.price;
        shipping = AR_buttons.shipping;
        timeNDate = AR_buttons.timeNDate;
        trackingId = AR_buttons.trackingId;

    }

}
