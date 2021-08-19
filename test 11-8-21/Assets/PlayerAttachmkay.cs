using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachmkay : MonoBehaviour
{
   public GameObject TheLedge;
   public CharacterController ThePlayer;

   void OnTriggerEnter(){
       ThePlayer.transform.parent = TheLedge.transform;
   }
   void OnTriggerExit () {
  ThePlayer.transform.parent = null;
 }
}
