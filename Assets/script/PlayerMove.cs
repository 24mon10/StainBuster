using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    float speed = 10.0f;
    Animator animator;
    [SerializeField] GameObject unitychan;
    [SerializeField] GameObject playeraudio;
    CleaningObject cleaningcomplete;
    float deletetime = 0f;
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] AudioClip m_cleanAudio;
    [SerializeField] AudioClip m_walkAudio;
    bool playcleanAudio = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = playeraudio.GetComponent<AudioSource>();
        cleaningcomplete = GetComponent<CleaningObject>();
        rb = GetComponent<Rigidbody>();
        this.animator = unitychan.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool walk = false;
        if (Input.GetKey(KeyCode.W))
        {
            walk = true;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = transform.forward * speed;
            this.animator.SetBool("Run", true);
            this.animator.SetBool("Stay", false);
            if (!m_audioSource.isPlaying && walk)
            {
                m_audioSource.PlayOneShot(m_walkAudio);
            }
        }

        if (!walk)
        {
            
            this.animator.SetBool("Stay", true);
            this.animator.SetBool("Run", false);
            rb.velocity = Vector3.zero;
        }

        if(Input.GetKey(KeyCode.A)) 
        {
            rb.velocity = Vector3.zero;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Stain"))
        {
            bool cfin = cleaningcomplete.cleanfinish;
            if (Input.GetKey(KeyCode.D))
            {
                this.animator.SetBool("Wipe", true);
				rb.velocity = Vector3.zero;
				playcleanAudio = true;
                deletetime += Time.deltaTime; 
                if(!m_audioSource.isPlaying && playcleanAudio)
                {
                    m_audioSource.PlayOneShot(m_cleanAudio);
                }
            }
            else
            {

                m_audioSource.Stop();
                playcleanAudio = false;
                this.animator.SetBool("Wipe", false);
               //S m_audioSource.Stop(m_cleanAudio);
            }
            if (deletetime >= 10f)
            {
                playcleanAudio = false;
                m_audioSource.Stop();
                Debug.Log("オブジェクトが消えた");
                this.animator.SetBool("Wipe", false);
                deletetime = 0f;
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("判定外");
        if (other.gameObject.CompareTag("Stain"))
        {
            this.animator.SetBool("Wipe", false);
        }
    }
}
