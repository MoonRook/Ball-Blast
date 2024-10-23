using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinText : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private Text text;

    private void Start()
    {
        bag.ChangeAmountCoin.AddListener(OnChangeHitPoints);
    }

    private void OnDestroy()
    {
        bag.ChangeAmountCoin.RemoveListener(OnChangeHitPoints);
    }

    private void OnChangeHitPoints()
    {
        text.text = bag.GetAmountCoin().ToString();
    }
        
}
