using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current_posi_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      

        // Transform.position 값을 출력한다.
        Debug.Log(transform.position);
    }
}
