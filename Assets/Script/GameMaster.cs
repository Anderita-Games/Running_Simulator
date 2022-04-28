using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameMaster : MonoBehaviour
{
    public bool Started;
    public GameObject Floor_Prefab;
    public GameObject Floor_New;
    public int Quantity;
    public int X;
    public GameObject Intro_Text;
    public UnityEngine.UI.Text CurrentTime;
    public UnityEngine.UI.Text HighTime;
    public int Time_Elapsed;
    public GameObject Player;
    public GameObject Cameras; // For location
    public Rigidbody The_Camera;
    public float Speed;
    public virtual void Start()
    {
        while (this.Quantity < 30)
        {
            this.Floor_New = UnityEngine.Object.Instantiate(this.Floor_Prefab, new Vector3(this.X, 0, 0), Quaternion.identity);
            PlayerPrefs.SetInt("Block Total", PlayerPrefs.GetInt("Block Total") + 1);
            this.Quantity++;
            this.X++;
            this.Floor_New.name = "Floor #" + this.Quantity;
        }
        if (Application.loadedLevelName == "MainMenu2")
        {
            this.Started = true;
            this.StartCoroutine(this.Creation());
            this.StartCoroutine(this.TimeAdder());
        }
    }

    public virtual void Update()
    {
        if ((Input.GetMouseButtonDown(0) && (this.Started == false)) && (this.Time_Elapsed <= 0))
        {
            this.Started = true;
            this.StartCoroutine(this.Creation());
            this.StartCoroutine(this.TimeAdder());
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && (this.Started == false))
            {
                Application.LoadLevel("MainMenu2");
            }
        }
        if (this.Player.transform.position.y < -5)
        {
            this.Started = false;
        }
        if (this.Started == true)
        {
            this.Intro_Text.SetActive(false);
            this.Player.transform.Translate((Vector3.right * this.Speed) * Time.deltaTime);

            {
                float _3 = this.Speed;
                Vector3 _4 = this.The_Camera.velocity;
                _4.x = _3;
                this.The_Camera.velocity = _4;
            }
            this.Speed = this.Speed * 1.0001f;
        }
        else
        {
            this.Intro_Text.SetActive(true);

            {
                int _5 = 0;
                Vector3 _6 = this.The_Camera.velocity;
                _6.x = _5;
                this.The_Camera.velocity = _6;
            }
        }
        this.CurrentTime.text = ("Time Survived: " + this.Time_Elapsed) + " Seconds";
        if (this.Time_Elapsed > PlayerPrefs.GetInt("HighTime"))
        {
            PlayerPrefs.SetInt("HighTime", this.Time_Elapsed);
        }
        this.HighTime.text = ("Longest Time: " + PlayerPrefs.GetInt("HighTime")) + " Seconds";
    }

    public virtual IEnumerator Creation()
    {
        while (this.Started == true)
        {
            int Gap_Next = Random.Range(1, 10);
            while (Gap_Next > 0)
            {
                this.Floor_New = UnityEngine.Object.Instantiate(this.Floor_Prefab, new Vector3(this.X, 0, 0), Quaternion.identity);
                this.Quantity++;
                this.X++;
                Gap_Next--;
                if (this.Started == true)
                {
                    UnityEngine.Object.Destroy(this.Floor_New, 120);
                }
                this.Floor_New.name = "Floor #" + this.Quantity;
                yield return new WaitForSeconds(0.2f);
            }
            this.X = this.X + Random.Range(2, 4);
        }
    }

    public virtual IEnumerator TimeAdder()
    {
        while (this.Started == true)
        {
            yield return new WaitForSeconds(1);
            this.Time_Elapsed++;
        }
    }

    public GameMaster()
    {
        this.Quantity = 1;
        this.X = -10;
        this.Speed = 3;
    }

}