using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 10;

        float horisontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horisontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
