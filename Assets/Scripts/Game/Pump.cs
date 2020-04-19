using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour {
    public GameObject Spike;
    public Animator spikeAnim;
    public float spikeTimer = 0.0f;
    public GameObject pump_Left;
    public GameObject pump_Right;
    public GameObject mildew;
    public GameObject adenoVirus;
    public Animator pump;
    public GameObject boss;
    public float pumpTimer = 0.0f;

    public bool onceOnly = false;
	// Use this for initialization
	void Start () {
        pump_Left.SetActive(false);
        pump_Right.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(EbolaBossHealthbar.Phase1)
        {
            pumpTimer += Time.deltaTime;
            if(pumpTimer>=5.0f&&pumpTimer<6.0f)
            {
                pump.SetBool("isPumping", true);
                pump_Left.SetActive(true);
                pump_Right.SetActive(true);
                //mildew.gameObject.SetActive(true);
                //adenoVirus.gameObject.SetActive(true);
                //mildew.gameObject.transform.position = new Vector2(-4, 0);
                //adenoVirus.gameObject.transform.position = new Vector2(4, 0);
                if (!onceOnly)
                {
                    mildew.gameObject.SetActive(true);
                    adenoVirus.gameObject.SetActive(true);
                    Instantiate(mildew, transform.position, Quaternion.identity);
                    Instantiate(adenoVirus, transform.position, Quaternion.identity);
                    onceOnly = true;
                }
                
            }
            if(pumpTimer>=6.0f)
            {
                onceOnly = false;
                pump.SetBool("isPumping", false);
                pumpTimer = 0.0f;
                pump_Left.SetActive(false);
                pump_Right.SetActive(false);
            }
        }

        else if (EbolaBossHealthbar.Phase2)
        {
            boss.GetComponent<MersFireInducement>().enabled = true;
        }

        else if (EbolaBossHealthbar.Phase3)
        {
            boss.GetComponent<MersFireInducement>().enabled = false;
            boss.GetComponent<BossPhase3Attack>().enabled = true;
        }
        else if (EbolaBossHealthbar.Phase4)
        {
            boss.GetComponent<BossPhase3Attack>().enabled = false;
            Spike.gameObject.SetActive(true);
            spikeTimer += Time.deltaTime;
            if (spikeTimer >= 2.0f)
            {
                spikeAnim.SetBool("isAttacking", true);
            }
            if (spikeTimer >= 5.0f)
            {
                spikeAnim.SetBool("isAttacking", false);
                spikeTimer = 0.0f;
            }
        }
	}
}
