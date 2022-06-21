using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLuncher : MonoBehaviour, ILauncher
{

    [SerializeField]
   public Fire firePrefab;
   [SerializeField]
    private Transform point; 

    //configurar o comportamento do meu objeto
    public void Launch( )
    {
       Instantiate(firePrefab,point.position,transform.rotation);
    }

    


 

}
