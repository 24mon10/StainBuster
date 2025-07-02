using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectCount : MonoBehaviour
{
    GameObject[] slimeBox;
    GameObject[] stainBox;
    [SerializeField] TextMeshProUGUI slimeCount;
    [SerializeField] TextMeshProUGUI stainCount;
    private float waitTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //slimeCount = slimeCount.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        slimeBox = GameObject.FindGameObjectsWithTag("Slime");
        stainBox = GameObject.FindGameObjectsWithTag("Stain");

        slimeCount.text = "" + slimeBox.Length;
        stainCount.text = "" + stainBox.Length;


        if(slimeCount.text == "" + 0 && stainCount.text == "" + 0)
        {
            waitTime += Time.deltaTime;
            if(waitTime > 4.0f)SceneManager.LoadScene("ClearScene");
        }

		if (Input.GetKeyDown(KeyCode.F2)) SceneManager.LoadScene("ClearScene");
    }
}
