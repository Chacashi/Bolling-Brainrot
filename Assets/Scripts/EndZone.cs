using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
public class EndZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BallController ball;
    [SerializeField] private CinemachineCamera cineCam;
    [SerializeField] private Transform endZoneCamTarget;

    private Transform originalFollow;

    private void Start()
    {
        if (cineCam != null)
        {
            originalFollow = cineCam.Follow;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(HandleEndZone());
        }
    }

    private IEnumerator HandleEndZone()
    {
        if (cineCam != null && endZoneCamTarget != null)
        {
            cineCam.Follow = endZoneCamTarget;
            cineCam.LookAt = endZoneCamTarget;
        }

        yield return new WaitForSeconds(3f);

        gameManager.RevisarTiro();

        if (cineCam != null && ball != null)
        {
            cineCam.Follow = ball.transform;
            cineCam.LookAt = ball.transform;
        }
    }
}
