using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEventManager : MonoBehaviour
{
    public Text defenseAmnt;
    public Text attackAmnt;
    public Text points;
    public GameObject upAttk;
    public GameObject upDfse;


    void Update()
    {
        upAttk.SetActive(true);//Allows the upgrade attack button to be used
        upDfse.SetActive(true);//Allows the upgrade defense button to be used
        defenseAmnt.text = PlayerPrefs.GetInt("PlayerDefense").ToString();//Shows the defense value
        attackAmnt.text = PlayerPrefs.GetInt("PlayerAttack").ToString();//Shows the attack value
        points.text = PlayerPrefs.GetInt("Points").ToString();//Shows the points value
        if (PlayerPrefs.GetInt("Points") <= 0)//If the user has no points
        {
            //The upgrade button is not shown
            upAttk.SetActive(false);
            upDfse.SetActive(false);
        }
    }

    public void upgradeAttack()
    {
        if (PlayerPrefs.GetInt("Points") > 0)//If the user has points
        {
            PlayerPrefs.SetInt("PlayerAttack", PlayerPrefs.GetInt("PlayerAttack") + 1);//Increments attack
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - 1);//Decrements points
        }
        
    }

    public void upgredeDefense()
    {
        if (PlayerPrefs.GetInt("Points") > 0)//If the user has points
        {
            PlayerPrefs.SetInt("PlayerDefense", PlayerPrefs.GetInt("PlayerDefense") + 1);//Increments defense
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - 1);//Decrements points
        }
        
    }
}
