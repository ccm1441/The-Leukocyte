using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwordBrandish : MonoBehaviour
{

    public Animator animSaw;
    public Animator animSword;
    public Animator animCharacter;
    public Animator scissorsAnim;
    public Animator legendAnim;
    public GameObject legend;
    public GameObject saw;
    public GameObject sword;
    public GameObject syringe;
    public GameObject mes;
    public GameObject tamiflu;
    public GameObject penicillin;
    public GameObject scissors;
    public Animator mesAnim;
    public static bool isInjecting = false;
    public static bool isBrandishing = false;
    public static bool isAttacking = false;
    public GameObject bulletToRight, bulletToLeft;
    public GameObject tabletToRight, tabletToLeft;
    public GameObject tablet2ToRight, tablet2ToLeft;
    public GameObject tablet3ToRight, tablet3ToLeft;
    public GameObject tamifluToRight, tamifluToLeft;
    public GameObject penicillinToRight, penicillinToLeft;
    public GameObject scissorsToLeft, scissorsToRight;
    public Sprite Pharmacist;
    public Sprite Doctor;
    Vector2 bulletPos;
    Vector2 bulletPos2;
    Vector2 bulletPos3;
    Vector2 bulletPos4;
    Vector2 bulletPos5;
    Vector2 bulletPos6;
    Vector2 bulletPos7;
    public float fireRate = 0.5f;
    public Text char_class;
    float nextFire = 0.0f;
    public AudioClip smash;
    public AudioClip throw1;
    public AudioClip throw2;
    // Use this for initialization

    private void Start()
    { 

    }

    void FixedUpdate()
    {

        if (combine.hasLegend)
        {
            saw.SetActive(false);
            sword.SetActive(false);
            syringe.SetActive(false);
            mes.SetActive(false);
            tamiflu.SetActive(false);
            penicillin.SetActive(false);
            scissors.SetActive(false);
            sword.SetActive(false);
            inventory_.hasWeapon1 = false;
            inventory_.hasWeapon2 = false;
            inventory_.hasWeapon3 = false;
            inventory_.hasWeapon4 = false;
            inventory_.hasWeapon5 = false;
            inventory_.hasWeapon6 = false;
            legend.SetActive(true);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (!sound_.level_sound.isPlaying)
                {
                    sound_.sowrd_sound = gameObject.GetComponent<AudioSource>();
                    sound_.sowrd_sound.clip = smash;
                    sound_.sowrd_sound.Play();
                }
                legendAnim.SetBool("Brandish", true);
                isBrandishing = true;

            }
            else
            {
                legendAnim.SetBool("Brandish", false);
                isBrandishing = false;
            }
        }

        if (player_.player_info_level >= 1 && player_.player_info_level <= 3 && !combine.hasLegend)
        {
            char_class.text = "BEGINNER";
            sword.SetActive(true);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (!sound_.level_sound.isPlaying)
                {
                    sound_.sowrd_sound = transform.gameObject.GetComponent<AudioSource>();
                    sound_.sowrd_sound.clip = smash;
                    sound_.sowrd_sound.Play();
                }
                animSword.SetBool("Brandish", true);
                isBrandishing = true;
            }
            else
            {
                animSword.SetBool("Brandish", false);
                isBrandishing = false;
            }
        }

        else if (player_.player_info_level <= 6 && !combine.hasLegend)
        {
            char_class.text = "NURSE";
            animCharacter.SetBool("nurse", true);
            sword.SetActive(false);
            if (!inventory_.hasWeapon3 && !inventory_.hasWeapon4)
            {
                syringe.SetActive(true);
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw2_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw2_sound.clip = throw2;
                        sound_.throw2_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireBullet();
                }
            }
            else if (inventory_.hasWeapon3 && !inventory_.hasWeapon4)
            {
                syringe.SetActive(false);
                tamiflu.SetActive(true);

                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw2_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw2_sound.clip = throw2;
                        sound_.throw2_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireTamiflu();
                }
            }
            else if (inventory_.hasWeapon3 && inventory_.hasWeapon4)
            {
                syringe.SetActive(false);
                tamiflu.SetActive(false);
                penicillin.SetActive(true);
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw2_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw2_sound.clip = throw2;
                        sound_.throw2_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    firePenicillin();
                }
            }
            else if (!inventory_.hasWeapon3 && inventory_.hasWeapon4)
            {
                syringe.SetActive(false);
                tamiflu.SetActive(false);
                penicillin.SetActive(true);
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw2_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw2_sound.clip = throw2;
                        sound_.throw2_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    firePenicillin();
                }
            }
        }

        else if (player_.player_info_level <= 9 && !combine.hasLegend)
        {
            char_class.text = "PHARMACIST";
            gameObject.GetComponent<SpriteRenderer>().sprite = Pharmacist;
            animCharacter.SetBool("nurse", false);
            animCharacter.SetBool("pharmacist", true);
            sword.SetActive(false);
            syringe.SetActive(false);
            tamiflu.SetActive(false);
            penicillin.SetActive(false);
            if (!inventory_.hasWeapon5 && !inventory_.hasWeapon6)
            {

                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw1_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw1_sound.clip = throw1;
                        sound_.throw1_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireTablet();
                }
            }
            else if (inventory_.hasWeapon5 && !inventory_.hasWeapon6)
            { 
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw1_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw1_sound.clip = throw1;
                        sound_.throw1_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireTablet2();
                }
            }
            else if (inventory_.hasWeapon5 && inventory_.hasWeapon6)
            {
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw1_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw1_sound.clip = throw1;
                        sound_.throw1_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireTablet3();
                }
            }
            else if (!inventory_.hasWeapon5 && inventory_.hasWeapon6)
            {
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw1_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw1_sound.clip = throw1;
                        sound_.throw1_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireTablet3();
                }
            }
        }
        else if (player_.player_info_level <= 12 && !combine.hasLegend)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Doctor;
            sword.SetActive(false);
            syringe.SetActive(false);
            animCharacter.SetBool("pharmacist", false);
            animCharacter.SetBool("doctor", true);
            char_class.text = "DOCTOR";
            if (!inventory_.hasWeapon1 && !inventory_.hasWeapon2)
            {
                mes.SetActive(true);

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.sowrd_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.sowrd_sound.clip = smash;
                        sound_.sowrd_sound.Play();
                    }
                    mesAnim.SetBool("attack", true);
                    isAttacking = true;
                }
                else
                {
                    mesAnim.SetBool("attack", false);
                    isAttacking = false;
                }
            }

            else if (inventory_.hasWeapon1 && !inventory_.hasWeapon2)
            {
                mes.SetActive(false);
                scissors.SetActive(true);
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    scissorsAnim.SetBool("isAttacking", true);

                }
                else
                {
                    scissorsAnim.SetBool("isAttacking", false);

                }
                if (Input.GetKey(KeyCode.LeftControl) && Time.time > nextFire)
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.throw2_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.throw2_sound.clip = throw2;
                        sound_.throw2_sound.Play();
                    }
                    nextFire = Time.time + fireRate;
                    fireScissors();
                }
            }
            else if (!inventory_.hasWeapon1 && inventory_.hasWeapon2)
            {
                mes.SetActive(false);
                scissors.SetActive(false);
                saw.SetActive(true);

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.sowrd_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.sowrd_sound.clip = smash;
                        sound_.sowrd_sound.Play();
                    }
                    animSaw.SetBool("isBrandishing", true);
                    isBrandishing = true;
                }
                else
                {
                    animSaw.SetBool("isBrandishing", false);
                    isBrandishing = false;
                }
            }
            else if (inventory_.hasWeapon1 && inventory_.hasWeapon2)
            {
                mes.SetActive(false);
                scissors.SetActive(false);
                saw.SetActive(true);

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!sound_.level_sound.isPlaying)
                    {
                        sound_.sowrd_sound = transform.gameObject.GetComponent<AudioSource>();
                        sound_.sowrd_sound.clip = smash;
                        sound_.sowrd_sound.Play();
                    }
                    animSaw.SetBool("isBrandishing", true);
                    isBrandishing = true;

                }
                else
                {
                    animSaw.SetBool("isBrandishing", false);
                    isBrandishing = false;
                }
            }
        }       




    }


    void fireBullet()
    {
        bulletPos = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos += new Vector2(+1f, -0.43f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }
        else
        {
            bulletPos += new Vector2(-1f, -0.43f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
    }
    void fireTablet()
    {
        bulletPos2 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos2 += new Vector2(+1f, -0.43f);
            Instantiate(tabletToRight, bulletPos2, Quaternion.identity);
        }
        else
        {
            bulletPos2 += new Vector2(-1f, -0.43f);
            Instantiate(tabletToLeft, bulletPos2, Quaternion.identity);
        }
    }

    void fireTamiflu()
    {
        bulletPos3 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos3 += new Vector2(+1f, -0.43f);
            Instantiate(tamifluToRight, bulletPos3, Quaternion.identity);
        }
        else
        {
            bulletPos3 += new Vector2(-1f, -0.43f);
            Instantiate(tamifluToLeft, bulletPos3, Quaternion.identity);
        }
    }

    void firePenicillin()
    {
        bulletPos4 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos4 += new Vector2(+1f, -0.43f);
            Instantiate(penicillinToRight, bulletPos4, Quaternion.identity);
        }
        else
        {
            bulletPos4 += new Vector2(-1f, -0.43f);
            Instantiate(penicillinToLeft, bulletPos4, Quaternion.identity);
        }
    }

    void fireTablet2()
    {
        bulletPos5 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos5 += new Vector2(+1f, -0.43f);
            Instantiate(tablet2ToRight, bulletPos5, Quaternion.identity);


        }
        else
        {
            bulletPos5 += new Vector2(-1f, -0.43f);
            Instantiate(tablet2ToLeft, bulletPos5, Quaternion.identity);


        }
    }

    void fireTablet3()
    {
        bulletPos6 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos6 += new Vector2(+1f, -0.43f);
            Instantiate(tablet3ToRight, bulletPos6, Quaternion.identity);
        }
        else
        {
            bulletPos6 += new Vector2(-1f, -0.43f);
            Instantiate(tablet3ToLeft, bulletPos6, Quaternion.identity);
        }
    }

    void fireScissors()
    {
        bulletPos7 = transform.position;
        if (PlayerMove.facingRight)
        {
            bulletPos7 += new Vector2(+1f, -0.43f);
            Instantiate(scissorsToRight, bulletPos7, Quaternion.identity);
        }
        else
        {
            bulletPos7 += new Vector2(-1f, -0.43f);
            Instantiate(scissorsToLeft, bulletPos7, Quaternion.identity);
        }
    }
}
