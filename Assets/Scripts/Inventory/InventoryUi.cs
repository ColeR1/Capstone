using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    private TextMeshProUGUI woodText;
    // Start is called before the first frame update
    void Start()
    {
        woodText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWoodText(PlayerInventory playerInventory)
    {
        woodText.text = playerInventory.WoodCount.ToString();
    }
}
