using UnityEngine;
using System.Collections;

public class ShatellStart : MonoBehaviour {

    public GameObject MovePoint;
    public float HeightFromEarth = 2000f;

    public GameObject _Start_First_Position_Player_Oculus_Rift;
    public GameObject _Second_Position_Player_Oculus_Rift;
    public GameObject Astranaft_Animation;

    public GameObject OculusRift_GameObject;

    public GameObject _door_prt;
    public GameObject _door_stb;
    public GameObject _MainRocket;
    public GameObject _Pult_Panel;
    public GameObject _shut;
    public GameObject _Taile;
    public GameObject _Part_OF_Land_;
    public GameObject _Oculus_Rift_CameraLeft;
    public GameObject _Oculus_Rift_CameraRight;
    public GameObject _ISS_complete_2011;

    public GameObject _ISS_Oculus_Camera;
    public GameObject _Main_Work_Space;
    public GameObject Pult_Upravlenie;

    public GameObject Fire_Smoke_GameObject;

    public GameObject _Sound_1;
    public GameObject _Sound_2;
    public GameObject _Sound_3;
    public GameObject _Sound_4;
    public GameObject _Sound_5;
    public GameObject _Sound_6;

    private bool oneTimeAddForce        = false;
    private bool animationOneTime       = false;
    private bool change_Camera_in_space = false;
    private bool CountDown = false;


	void Update () 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameObject.transform.position.y > 10.0f)
        {
            //gameObject.rigidbody.active = false;
            //gameObject.GetComponent<AudioSource>().Stop();
            gameObject.rigidbody.Sleep();
            _ISS_complete_2011.gameObject.SetActive(true);

            Destroy(_door_prt);
            Destroy(_door_stb);
            Destroy(_MainRocket);
            Destroy(_Pult_Panel);
            Destroy(_shut);
            Destroy(_Taile);
            Destroy(_Part_OF_Land_);

            _Sound_6.gameObject.SetActive(true);
            _ISS_complete_2011.transform.position = gameObject.transform.position;

            //After Out Earth Position 12742KM we destroy Rocket
            if (change_Camera_in_space == false)
            {
                //OculusRift_GameObject.gameObject.SetActive(false);
                OculusRift_GameObject.transform.position = _Main_Work_Space.transform.position;
                OculusRift_GameObject.gameObject.SetActive(true);
                change_Camera_in_space = true;
            }
            
            /*OculusRift_GameObject.GetComponent<OVRGamepadController>().active = true;
            OculusRift_GameObject.GetComponent<OVRPlayerController>().active = true;
            OculusRift_GameObject.GetComponent<CameraShake>().active = false;*/

            if (Input.GetKey(KeyCode.C))
            {
                OculusRift_GameObject.transform.position = _ISS_Oculus_Camera.transform.position;
            }
            if (Input.GetKey(KeyCode.M))
            {
                OculusRift_GameObject.transform.position = _Main_Work_Space.transform.position;
                /*if (OculusRift_GameObject.GetComponent<OVRPlayerController>().enabled = true)
                {
                    OculusRift_GameObject.GetComponent<OVRPlayerController>().enabled = true;
                }*/
            }
            if (Input.GetKey(KeyCode.Space))
            {
                OculusRift_GameObject.transform.position = Pult_Upravlenie.transform.position;
            }

        }
        else
        {
            StartCoroutine(WaitSomeSeconds(13.0f));
            float RandomX = Random.Range(0.1f, -0.1f);
            float RandomY = Random.Range(0.1f, -0.1f);
            float RandomZ = Random.Range(0.1f, -0.1f);
            

            //_Oculus_Rift_CameraLeft.transform.position += new Vector3(RandomX, RandomY, RandomZ);
            
        }

        if (gameObject.transform.position.y < 0.0f && gameObject.transform.position.y > -157.0f)
        {
            _Sound_4.gameObject.SetActive(true);
            
        }
        if (gameObject.transform.position.y > 0.0f && gameObject.transform.position.y < 10.0f)
        {
            _Sound_4.gameObject.SetActive(false);
            _Sound_5.gameObject.SetActive(true);
        }

        if (animationOneTime == false)
        {
            StartCoroutine(WaitAndDeleteAnimation(13));
        }
        if (animationOneTime == true && CountDown == false)
        {
            //_Sound_2.gameObject.SetActive(true);
            Fire_Smoke_GameObject.gameObject.SetActive(true);
            CountDown = true;
        }



	}
    IEnumerator WaitSomeSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        //Astranaft_Animation.GetComponent<Animation>().cullingType = AnimationCullingType.AlwaysAnimate;


        OculusRift_GameObject.transform.position = _Second_Position_Player_Oculus_Rift.transform.position;
       
        if (oneTimeAddForce == false)
        {
            Fire_Smoke_GameObject.gameObject.SetActive(true);
            OculusRift_GameObject.transform.RotateAround(new Vector3(1, 0, 1), 90);
            //if( )
            gameObject.rigidbody.AddForce(-MovePoint.transform.position, ForceMode.Impulse);
            oneTimeAddForce = true;
        }
    }
    IEnumerator WaitAndDeleteAnimation( float animation_delete)
    {
        yield return new WaitForSeconds(animation_delete);
        Destroy(Astranaft_Animation);
        animationOneTime = true;
             
    }
    
}
