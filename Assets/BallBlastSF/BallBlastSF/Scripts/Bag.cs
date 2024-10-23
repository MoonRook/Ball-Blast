using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    private int amountCoin;
    private int amountPotion;

    public UnityEvent ChangeAmountCoin;
    public UnityEvent ChangeAmountPotion;

    public void AddPotion(int amount)
    {
        amountPotion += amount;
        ChangeAmountPotion.Invoke();
    }

    public bool DrawPotion(int amount)
    {
        if (amountPotion - amount < 0) return false;

        amountPotion -= amount;
        ChangeAmountPotion.Invoke();

        return true;
    }

    public int GetAmountPotion()
    {
        return amountPotion;
    }
    
    public void AddCoin(int amount)
    {
        amountCoin += amount;
        ChangeAmountCoin.Invoke();
    }

    public bool DrawCoin(int amount)
    {
        if (amountCoin - amount < 0) return false;

        amountCoin -= amount;
        ChangeAmountCoin.Invoke();

        return true;
    }

    public int GetAmountCoin()
    {
        return amountCoin;
    }
}
