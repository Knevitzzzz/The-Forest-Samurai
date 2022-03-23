using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform PlayerPivot;

   private void FixedUpdate() 
   {
     transform.position = Vector2.Lerp(transform.position, PlayerPivot.position, 0.1f);
   }
}
