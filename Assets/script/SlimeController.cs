using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] GameObject stain;
    [SerializeField] GameObject[] spawnpos;
    [SerializeField] GameObject Slime;
    [SerializeField] bool tagcontact = false;
    [SerializeField] AudioSource cameraAudio;
    [SerializeField] AudioClip slimeHitSE;
    private int currentPoint = 0;
    private NavMeshAgent agent;
    private float stayTime = 0f;
    [SerializeField] int SHp;
    private float acceleratorTime = 0f;
    private enum SlimeState { Walk,Wait,Stain}
    SlimeState state = SlimeState.Walk;
    bool isDamage = false;

    private float moveSpeed;
    private float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveSpeed = this.agent.speed;
        rotateSpeed = this.agent.angularSpeed;
        GoToNextPoint();
    }
    
    // Update is called once per frame
    void Update()
    {
		//歩く・待機・オブジェクト配置のモード切替
       switch(state)
        {
            case SlimeState.Walk:
                if (!agent.pathPending && agent.remainingDistance < 0.1f)
                {
                    state = SlimeState.Wait;
                }
                 
                break;
            case SlimeState.Wait:
                
				//到着した場所に汚れがあるか確認
                if(tagcontact == true)
                {
                    GoToNextPoint();
                    state = SlimeState.Walk;
                    break;
                }
                else
                {
                    stayTime += Time.deltaTime;
                    if (stayTime >= 3.0f)
                    {
                        state = SlimeState.Stain;
                        stayTime = 0f;
                    }
                   
                }
                break;
            case SlimeState.Stain:
				//汚れが置かれていなければ設置
                Instantiate(stain, spawnpos[currentPoint].transform.position, spawnpos[currentPoint].transform.rotation);

                GoToNextPoint();
                state = SlimeState.Walk;
                break;
            default:
                break;
        }

        if(SHp == 0)
        {
            Destroy(this.gameObject);
        }

        if(isDamage)
        {
			//ダメージを受けたら一時的に加速する
            acceleratorTime += Time.deltaTime;
            this.agent.speed = moveSpeed * 2;
            this.agent.angularSpeed = rotateSpeed * 2;
            if (acceleratorTime >= 3.0f)
            {
                this.agent.speed = moveSpeed;
                this.agent.angularSpeed = rotateSpeed;
                acceleratorTime = 0;
                isDamage = false;
            }
            
        }
    }

    // 指定した状態に変更する
    void ChangeState(SlimeState next) => state = next;

    void GoToNextPoint()
    {
        if (waypoints.Length == 0) return;

        currentPoint = (currentPoint + 1) % waypoints.Length;

        agent.destination = waypoints[currentPoint].position;
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stain"))
        {	
            tagcontact = true;
        }
        if (other.gameObject.CompareTag("Attack") && !isDamage)
        {
            Debug.Log("攻撃された");
            // ここで音を鳴らす
            cameraAudio.GetComponent<AudioSource>().PlayOneShot(slimeHitSE);
            isDamage = true;
            SHp -= 1;
            
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Stain"))
        {
           
            tagcontact = false;
        }  
    }
}
