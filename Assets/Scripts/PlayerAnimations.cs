using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private float inputHorizontal;
    private float inputVertical;

    public Sprite idleSprite;
    public Sprite sideSprite;
    public Sprite backSprite;

    public ParticleSystem afterImageParticleSystem;
    public Material[] particleTexture;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        if (inputHorizontal > 0)
        {
            playerSprite.sprite = sideSprite;
            afterImageParticleSystem.GetComponent<ParticleSystemRenderer>().material = particleTexture[3];
            playerSprite.flipX = false;
        }

        if (inputHorizontal < 0)
        {
            playerSprite.sprite = sideSprite;
            afterImageParticleSystem.GetComponent<ParticleSystemRenderer>().material = particleTexture[2];
            playerSprite.flipX = true;
        }

        if (inputHorizontal == 0 && inputHorizontal == 0)
        {
            playerSprite.sprite = idleSprite;
            afterImageParticleSystem.GetComponent<ParticleSystemRenderer>().material = particleTexture[1];
            playerSprite.flipX = false;
        }

        if (inputVertical > 0)
        {
            afterImageParticleSystem.GetComponent<ParticleSystemRenderer>().material = particleTexture[0];
            playerSprite.sprite = backSprite;
        }
    }
}
