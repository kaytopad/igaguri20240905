using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igaguriGenerator : MonoBehaviour
{

    public GameObject igaguriPrafab;
    // Update is called once per frame
    void Update()
    {
        //�N���b�N�ŃC�K�O���𐶐���������
        if (Input.GetMouseButtonDown(0))
        {
            GameObject igaguri = Instantiate(igaguriPrafab);
            igaguri.GetComponent<igaguriController>().Shoot(new Vector3(0, 200, 2000));

        }
    }
}
