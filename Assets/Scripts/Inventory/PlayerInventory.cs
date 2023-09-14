using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int WoodCount {get; private set;}

   public UnityEvent<PlayerInventory> onWoodCollected;

   public void WoodCollected()
   {
        WoodCount++;
        onWoodCollected.Invoke(this);
   }
}
