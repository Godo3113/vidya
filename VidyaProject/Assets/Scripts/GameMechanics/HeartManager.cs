using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void UpdateHearts()
    {
        InitHearts(); // Check if any new hearts have been added
        float tempHealth = playerCurrentHealth.RuntimeValue / 2; // Half a heart is 1 hit point
        for (int i = 0; i < heartContainers.RuntimeValue; i++)
        {
            if(i <= tempHealth-1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfFullHeart;
            }
        }
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.RuntimeValue; i ++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
}
