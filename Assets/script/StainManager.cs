using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainManager : MonoBehaviour
{
    [SerializeField] GameObject stain;
    [SerializeField] GameObject[] spawnpos;
   
    
    // Start is called before the first frame update
    void Start()
    {
        int truecount = 0;
        int falsecount = 0;
        
		//9個のスポーン地点からランダムに4個汚れを生成
        for (int i = 0; i < 9; i++)
        {
            bool draw = false;
            if (truecount < 4 && falsecount < 5)
            {
                int num = Random.Range(0, 2);
                if (num == 1)
                {
                    draw = true;
                    truecount++;
                }
                else
                {
                    draw = false;
                    falsecount++;
                }
            }
            else if(truecount >= 4) 
            {
                draw = false ;
            }
            else if(falsecount >= 5)
            {
                draw= true;
            }
            
            if(draw) 
            {
                Instantiate(stain, spawnpos[i].transform.position, spawnpos[i].transform.rotation);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
