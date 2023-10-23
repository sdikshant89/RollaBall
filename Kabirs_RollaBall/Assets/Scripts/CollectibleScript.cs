using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private bool direction = true;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(20, 35, 50) * Time.deltaTime, Space.Self);
        occilate();
    }

    void occilate() {
        if (direction)
        {
            transform.Translate(new Vector3(0f, 0.015f, 0f), Space.World);
            if (transform.position.y > 1.25)
            {
                direction = false;
            }
        }
        else
        {
            transform.Translate(new Vector3(0f, -0.015f, 0f), Space.World);
            if (transform.position.y < 0.5)
            {
                direction = true;
            }
        }
    }
}

//Debug.Log(Time.realtimeSinceStartup);

//rb.AddForce(new Vector3(0f, 2f, 0f)*5);

//int intTime = (int)Time.realtimeSinceStartup;
//if (intTime % 4 == 0 && intTime != secondInterval) {

//    secondInterval = intTime;

//    //Debug.Log("Inside at time: " + intTime + "and secondTime: " + secondInterval);

//    if (countFlag.Equals(0))
//    {
//        Debug.Log("Inside innermost");
//        //transform.Translate(new Vector3(0f, 100f, 0f) * Time.deltaTime, Space.World);
//        countFlag++;
//    }
//}


//if (transform.position.y > 3)
//{
//    transform.Translate(new Vector3(0f, 1f, 0f) * Time.deltaTime, Space.World);
//}
//else if (transform.position.y >= 3) {

//    transform.Translate(new Vector3(0f, -1f, 0f) * Time.deltaTime, Space.World);
//}


//transform.Translate(newPos * Time.deltaTime, Space.World);
//transform.Translate(initialPos * Time.deltaTime, Space.World);
//if (transform.position == initialPos)
//{
//    Vector3 newPos = new Vector3(initialPos.x, initialPos.y, (initialPos.z + 5.0f));
//    transform.Translate(newPos * Time.deltaTime, Space.World);
//}
//else {
//    transform.Translate(initialPos * Time.deltaTime, Space.World);
//}

//private Vector3 initialPos;
//private Rigidbody rb;
//public int countFlag = 0;
//public int secondInterval = 0;
//void Start()
//{
//    //initialPos = transform.position;
//    //rb = GetComponent<Rigidbody>();
//}
