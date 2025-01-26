using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ChangeCar : MonoBehaviour
{
    private int selectedCar;
    private Animator carAnimation;
    public TextMeshProUGUI carName;
    public AudioClip car1;
    public AudioClip car2;
    public AudioClip car3;
    private AudioSource carSource;

    public void Start()
    {
        selectedCar = PlayerPrefs.GetInt("selectedCar", 0);
        carAnimation = this.GetComponent<Animator>();
        carSource= this.GetComponent<AudioSource>();

        if (selectedCar == 0)
        {
            carName.text = "Default";
            //carAnimation.SetTrigger("YellowLeft");
            //carAnimation.SetTrigger("BlueLeft");
            carSource.clip = car1;
            carSource.Play();
            
        }
        else if (selectedCar == 1)
        {
            carName.text = "Ferrari";
            carAnimation.SetTrigger("YellowLeft");
            carSource.clip = car2;
            carSource.Play();

        }
        else if (selectedCar == 2)
        {
            carName.text = "Mustang";
            carSource.clip = car3;
            carSource.Play();
        }
    }
    public void previousButton()
    {
        if (selectedCar == 0)
        {
            carName.text = "Default";
            print(PlayerPrefs.GetInt("selectedCar", 0));
            
        }
        else if (selectedCar == 1)
        {
            carName.text = "Default";
            carAnimation.SetTrigger("BlueLeft");
            selectedCar = 0;
            PlayerPrefs.SetInt("selectedCar", 0);
            print(PlayerPrefs.GetInt("selectedCar", 0));
            carSource.clip = car1;
            carSource.Play();
        }
        else if (selectedCar == 2)
        {
            carName.text = "Ferrari";
            carAnimation.SetTrigger("YellowLeft");
            selectedCar = 1;
            PlayerPrefs.SetInt("selectedCar", 1);
            print(PlayerPrefs.GetInt("selectedCar", 0));
            carSource.clip = car2;
            carSource.Play();
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
            print(PlayerPrefs.GetInt("selectedCar", 0));
            carSource.clip = car2;
            carSource.Play();
        }
        else if (selectedCar == 1)
        {
            carName.text = "Mustang";
            carAnimation.SetTrigger("BlueRight");
            selectedCar = 2;
            PlayerPrefs.SetInt("selectedCar", 2);
            print(PlayerPrefs.GetInt("selectedCar", 0));
            carSource.clip = car3;
            carSource.Play();
        }
        else if (selectedCar == 2)
        {
            print(PlayerPrefs.GetInt("selectedCar", 0));
            
        }
    }


    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

}
