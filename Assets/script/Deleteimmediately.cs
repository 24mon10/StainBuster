using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deleteimmediately : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Stain"))
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				Destroy(other.gameObject);
			}
		}
	}
}
