using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameramov : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
         GetComponent<Rigidbody>().velocity = new Vector3(0, gm.vertvel, 4 * gm.zVelAdj);

     

    }

    private void Update()
    {

    }
}
