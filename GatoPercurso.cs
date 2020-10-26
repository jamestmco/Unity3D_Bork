using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoPercurso : MonoBehaviour
{
    //path = Pai dos Pontoluz
    //Pontoluz = Caminho que o cilindro percorre

    public static event System.Action OnGatoHasSpottedPlayer;

    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;
    public float timeToSpotPlayer = .5f;

    public Light spotlight;
    public float viewDistance = 11f;
    public LayerMask viewMask;

    float viewAngle;
    float playerVisibleTimer;

    public Transform pathHolder;
    Transform Player;
    Color originalSpotlightColor;
    public Animator animagatos; //AQUI

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        originalSpotlightColor = spotlight.color;

        Vector3[] Pontoluzes = new Vector3[pathHolder.childCount];
        for (int i = 0; i < Pontoluzes.Length; i++)
        {
            Pontoluzes[i] = pathHolder.GetChild(i).position;
            Pontoluzes[i] = new Vector3(Pontoluzes[i].x, transform.position.y, Pontoluzes[i].z);
        }
        StartCoroutine(FollowPath(Pontoluzes));
    }

    void Update ()
    {
        if (CanSeePlayer())
        {
            //raio de luz que atinge os obstáculos
            //spotlight.color = Color.red;
            StopAllCoroutines();
            playerVisibleTimer += Time.deltaTime;
            if (GetComponent<Gatos>().estaZonzo == false) 
            { 
                transform.LookAt(Player); //AQUI
            }
        }

        else
        {
            //spotlight.color = originalSpotlightColor;

            playerVisibleTimer -= Time.deltaTime;
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColor, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (OnGatoHasSpottedPlayer != null)
            {
                OnGatoHasSpottedPlayer();
            }
        }

        if (GetComponent<Gatos>().estaZonzo == true)
        {
            Debug.Log("Parei");
            StopAllCoroutines();
        }
    }



    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, Player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (Player.position - transform.position).normalized;
            float angleBetweenGatoAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);

            if (angleBetweenGatoAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, Player.position,viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator FollowPath (Vector3[] Pontoluzes)
    {
        transform.position = Pontoluzes[0];

        int targetPontoluzIndex = 1;
        Vector3 targetPontoluz = Pontoluzes[targetPontoluzIndex];
        transform.LookAt(targetPontoluz);

        while (true)
        {
            animagatos.SetTrigger("Catwalk");
            transform.position = Vector3.MoveTowards(transform.position, targetPontoluz, speed * Time.deltaTime);
            if (transform.position == targetPontoluz)
            {
                targetPontoluzIndex = (targetPontoluzIndex + 1) % Pontoluzes.Length;
                targetPontoluz = Pontoluzes[targetPontoluzIndex];
                transform.LookAt(targetPontoluz);
                //yield return new WaitForSeconds(waitTime);
                //yield return StartCoroutine(TurnToFace(targetPontoluz));
            }
            yield return null;
        }
    }



    //faz com que o gato vire na direção dos pontos
    IEnumerator TurnToFace (Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x * Mathf.Rad2Deg);

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }



    //Gizmos aparecem na opção de game
    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform Pontoluz in pathHolder)
        {
            //os 5 Pontoluz no chão apareceram com forma
            Gizmos.DrawSphere(Pontoluz.position, .3f);

            //adiciona uma linha para unir os Pontoluz no chão
            Gizmos.DrawLine(previousPosition, Pontoluz.position);
            previousPosition = Pontoluz.position;
        }

        //une o último Pontoluz ao cilindro
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
