using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int itemCount = 0;

    [SerializeField] private TextMeshProUGUI itemText;

    private string itemName = "Melons";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            GameObject melon = collision.gameObject;
            Destroy(melon);
            itemCount++;
            //Debug.Log("itemCount is now :" + itemCount);
            itemText.text = itemName + ": " + itemCount;

        }
    }

}
