using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FirePoint : MonoBehaviour
{
   
    public ILauncher launcher;
    
    void Awake(){
        launcher = GetComponent<ILauncher>();
    }


    //metodo que ouve o input player e dispara oq tiver que disparar
    void OnFire(){
        launcher.Launch();

   }           
  
}
