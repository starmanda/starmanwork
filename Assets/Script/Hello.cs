using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject deskObject = Resources.Load<GameObject>("Desk");
        GameObject studentObject = Resources.Load<GameObject>("Student");
        GameObject seatObject = Resources.Load<GameObject>("Seat");

        for(int i = 0; i < 6; i++)
        {
            for (int j=0;j<10;j++)
            {
                GameObject tempDesk = Instantiate(deskObject);
                tempDesk.transform.position = new Vector3(i*2,0, j * 2);
                int randomValue = UnityEngine.Random.Range(0, 3);
                if (randomValue == 1)
                {
                    GameObject tempStudent = Instantiate(studentObject);
                    tempStudent.transform.position = new Vector3(2* i+1, 0, 2 * j );
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
