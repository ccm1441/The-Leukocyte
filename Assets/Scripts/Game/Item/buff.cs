using UnityEngine;
using UnityEngine.UI;

public class buff : MonoBehaviour {

    public Text exp_time;
    public GameObject exp_buff;
    public ParticleSystem exp_use_eff;

    private void Start()
    {
        exp_use_eff.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(buff_.use_exp)
        {           
            exp_buff.SetActive(true);
            exp_use_eff.gameObject.SetActive(true);
            buff_.time += Time.deltaTime;
            exp_time.text = ((buff_.exp_time - buff_.time)).ToString("N0");
        }

        if(int.Parse(exp_time.text)<= 0)
        {
            exp_use_eff.gameObject.SetActive(false);
            exp_buff.SetActive(false);
            buff_.use_exp = false;
            buff_.exp_time = 0;
            buff_.time = 0;
            buff_.exp_mult = 1;
        }
    }
}
