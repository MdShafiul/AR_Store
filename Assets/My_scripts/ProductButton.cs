using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject productMenu;
    public GameObject[] products;
    
    void Start()
    {
        productMenu.SetActive(true);
        foreach (GameObject product in products)
            product.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMenu()
    {
        
        productMenu.SetActive(true);
        foreach (GameObject product in products)
            product.SetActive(false);
        
    }

    public void OnClickProduct()
    {

        productMenu.SetActive(false);

        string btnName;
        btnName = EventSystem.current.currentSelectedGameObject.name;

        if (btnName == "Button1")
            products[0].SetActive(true);

        else if (btnName == "Button2")
            products[1].SetActive(true);

        else if (btnName == "Button3")
            products[2].SetActive(true);

    }

}
