using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CleaningObject : MonoBehaviour
{
    [SerializeField] GameObject stain;
    public float cleaningtime = 0f;
    [SerializeField] Slider slider;
    [SerializeField] GameObject unitychan;
    public bool cleanfinish = false;
    // Start is called before the first frame update
    void Start()
    {
        slider.gameObject.SetActive(false);
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Stain"))
        {
            if (Input.GetKey(KeyCode.D))
            {
               
                slider.gameObject.SetActive(true);
                cleaningtime += Time.deltaTime;
                slider.value = cleaningtime * 0.1f;
                cleanfinish = false;

                if (cleaningtime >= 10.0f)
                {
                    Destroy(other.gameObject);
                    cleaningtime = 0f;
                    slider.value = 0;
                    slider.gameObject.SetActive(false);
                    

                }
            }
            else
            {
                
                slider.gameObject.SetActive(false);
            }
        }

    }

   
}
