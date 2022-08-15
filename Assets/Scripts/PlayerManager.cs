using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerAnimations playerAnimationsScript;

    private float hitWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        hitWaitTime = playerAnimationsScript.rollAntimationTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tentacle"))
        {
            StartCoroutine(PlayerHitAnimation());
        }
    }

    IEnumerator PlayerHitAnimation()
    {
        playerAnimationsScript.playerSprite.sprite = playerAnimationsScript.hitSprite;
        gameObject.GetComponent<PlayerDash>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAnimations>().enabled = false;
        yield return new WaitForSeconds(hitWaitTime);
        gameObject.GetComponent<PlayerDash>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerAnimations>().enabled = true;
    }
}
