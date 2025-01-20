using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeCar : MonoBehaviour
{
    private int selectedCar;
    private Animator carAnimation;
    public TextMeshProUGUI carName;
    public void Start()
    {
        selectedCar = PlayerPrefs.GetInt("selectedCar", 0);
        carAnimation = this.GetComponent<Animator>();
        if (selectedCar == 0)
        {
            carName.text = "Default";
            carAnimation.SetTrigger("YellowLeft");
            carAnimation.SetTrigger("BlueLeft");
        }
        else if (selectedCar == 1)
        {
            carName.text = "Ferrari";
            carAnimation.SetTrigger("YellowLeft");
         
        }
        else if (selectedCar == 2)
        {
            carName.text = "Mustang";
        }
    }
    public void previousButton()
    {
        if (selectedCar == 0)
        {
            carName.text = "Default";
        }
        else if (selectedCar == 1)
        {
            carName.text = "Default";
            carAnimation.SetTrigger("BlueLeft");
            selectedCar = 0;
            PlayerPrefs.SetInt("selectedCar", 0);
        }
        else if (selectedCar == 2)
        {
            carName.text = "Ferrari";
            carAnimation.SetTrigger("YellowLeft");
            selectedCar = 1;
            PlayerPrefs.SetInt("selectedCar", 1);
        }

    }

    public void nextButton()
    {
        if (selectedCar == 0)
        {
            carName.text = "Ferrari";
            carAnimation.SetTrigger("RedRight");
            selectedCar = 1;
            PlayerPrefs.SetInt("selectedCar", 1);
        }
        else if (selectedCar == 1)
        {
            carName.text = "Mustang";
            carAnimation.SetTrigger("BlueRight");
            selectedCar = 2;
            PlayerPrefs.SetInt("selectedCar", 2);
        }
        else if (selectedCar == 2)
        {

        }
    }
}
