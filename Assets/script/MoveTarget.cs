using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] Transform target = null;

	void Start ()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.localPosition);

        // OffMeshLink�ɏ�����ۂ̃A�N�V����
        StartCoroutine(MoveNormalSpeed(agent));
    }

    IEnumerator MoveNormalSpeed(NavMeshAgent agent)
    {
        agent.autoTraverseOffMeshLink = false; // OffMeshLink�ɂ��ړ����֎~
        
        while (true)
        {
            // OffmeshLink�ɏ��܂ŕ��ʂɈړ�
            yield return new WaitWhile(() => agent.isOnOffMeshLink == false);

            // OffMeshLink�ɏ�����̂ŁANavmeshAgent�ɂ��ړ����~�߂āA
            // OffMeshLink�̏I���܂�NavmeshAgent.speed�Ɠ������x�ňړ�
            agent.isStopped = true;
            yield return new WaitWhile(() =>
            {
                transform.localPosition = Vector3.MoveTowards(
                                            transform.localPosition,
                                            agent.currentOffMeshLinkData.endPos, agent.speed * Time.deltaTime);
                return Vector3.Distance(transform.localPosition, agent.currentOffMeshLinkData.endPos) > 0.1f;
            });

            // NavmeshAgent�𓞒B�������ɂ��āANavmesh���ĊJ
            agent.CompleteOffMeshLink();
            agent.isStopped = false;
        }
    }
}
