using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D other) 
   {
       Debug.Log("Oof");
   }

   void OnTriggerEnter2D(Collider2D other) 
   {
        Debug.Log("*Triggered*");
   }
}
