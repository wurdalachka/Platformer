using System.Collections;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public teleporter teleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        teleport.gameObject.SetActive (false);
        collision.transform.position = teleport.transform.position;
        StartCoroutine(TeleportPlayer(1.1f));


        IEnumerator TeleportPlayer(float timeToteleporter)
        {
            yield return new WaitForSeconds (timeToteleporter); 
            teleport.gameObject.SetActive(true);   
        }
    }
}
