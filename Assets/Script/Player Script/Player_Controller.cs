using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    public Player player;
    public Pile_driver _pile_driver; //打樁機腳本
    public Demolition_hammer _demolition_hammer; //鑿破錘腳本
    public Drill _drill; //鑽頭腳本
    public Props_Controller _props_Controller;
    public GameObject drill_Object; //鑽頭觸發物件
    public GameObject nowShield_Object;
    public Player_Animator_Controller animatorCtrl;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Handheld_Equipment>().EquipmentJudge();
    }

    private void Update()
    {
        Drill_Open(); //當玩家的裝備為鑽頭時開起鑽頭佔領物件
        OverheatCollDown();
        IsOverheat();
    }

    public void PlayerMove(GameObject player, string[] InputKey) //玩家移動
    {
        rb = player.GetComponent<Rigidbody>();
        Player _player = player.GetComponent<Player>();
        if (Input.GetKey(InputKey[1])) // 按住 w 時
        {
            rb.velocity = new Vector3(0, 0, _player.speed);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(InputKey[3])) // 按住 s 時
        {
            rb.velocity = new Vector3(0, 0, -_player.speed);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(InputKey[4])) // 按住 d 時
        {
            rb.velocity = new Vector3(_player.speed, 0, 0);
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(InputKey[2])) // 按住 a 時
        {
            rb.velocity = new Vector3(-_player.speed, 0, 0);
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (!(Input.GetKey(InputKey[1]) || Input.GetKey(InputKey[2]) || Input.GetKey(InputKey[3]) || Input.GetKey(InputKey[4])))
        {
            rb.velocity = new Vector3(0, 0, 0);
            animatorCtrl.Set_isRun(false);
        }
        else
        {
            animatorCtrl.Set_isRun(true);
        }
    }

    public void UseEquipment(GameObject player) //使用裝備
    {
        Player _player = player.GetComponent<Player>();
        switch (_player._equipment)
        {
            case Equipment.drill://鑽頭
                Debug.Log(_player._equipment + "鑽頭");
                _drill.Attack();
                break;
            case Equipment.pile_driver://打樁機
                Debug.Log(_player._equipment + "打樁機");
                _pile_driver.Attack(player, _player._myTeam.GetHashCode()); //將玩家&玩家隊伍列舉的值傳給Pile_driver
                if (!_player.isOverheat)
                    animatorCtrl.Set_Pd_Attack(); //播放打樁機攻擊動畫
                break;
            case Equipment.demolition_hamer://鑿破機
                Debug.Log(_player._equipment + "鑿破機");
                _demolition_hammer.Attack(player, _player._myTeam.GetHashCode());
                if (!_player.isOverheat)
                    animatorCtrl.Set_Dh_Attack(); //播放鑿破機攻擊動畫
                break;
            default://以上都不符合走這個
                Debug.Log("你沒拿裝備");
                break;
        }
    }

    public void UseProps(GameObject player) //使用道具
    {
        Player _player = player.GetComponent<Player>();
        switch (_player._props)
        {
            case Props.shield://護盾
                Debug.Log(_player._props + "護盾");
                _props_Controller.UseShield(player);
                break;
            case Props.speed://加速
                Debug.Log(_player._props + "加速");
                _props_Controller.UseSpeed(player);
                break;
            case Props.brick://磚頭
                Debug.Log(_player._props + "磚頭");
                _props_Controller.UseBrick(player, _player._myTeam.GetHashCode());
                break;
            case Props.boom://炸藥
                Debug.Log(_player._props + "炸藥");
                //_boom.Use(player, _player._myTeam.GetHashCode());
                _props_Controller.UseBoom(player, _player._myTeam.GetHashCode());
                break;
            case Props.mines://地雷
                Debug.Log(_player._props + "地雷");
                _props_Controller.UseMines(player, _player._myTeam.GetHashCode());
                break;
            case Props.hook://鈎爪
                Debug.Log(_player._props + "鈎爪");
                _props_Controller.UseHook(player, _player._myTeam.GetHashCode());
                break;
            case Props.no_have_props://沒拿
                Debug.Log("你沒有道具");
                break;
            default://以上都不符合走這個
                Debug.Log("所持道具錯誤");
                break;
        }
        _player._props = Props.no_have_props; //讓道具只能使用一次，若註解掉則開啟無限道具模式
    }

    public void Drill_Open() //當玩家的裝備為鑽頭時開起鑽頭佔領物件
    {
        if (player._equipment == Player_Controller.Equipment.drill) //當玩家的裝備為鑽頭時
        {
            if (!(drill_Object.activeInHierarchy)) //當鑽頭Object未啟用時
            {
                drill_Object.SetActive(true); //將其啟用
                drill_Object.transform.GetChild(0).GetComponent<Occupy_point_Controllor>().TeamNum = player._myTeam.GetHashCode(); //並將其隊伍值設為玩家隊伍值
            }
        }
        else //當玩家的裝備不是鑽頭時
        {
            if (drill_Object.activeInHierarchy) //且鑽頭Object已啟用
                drill_Object.SetActive(false); //將其關閉
        }
    }

    public void IsOverheat()
    {
        if (player.overheat_value >= 1 && !player.isOverheat)
        {
            //Debug.Log("過熱");
            StartCoroutine(SetOverheat());
        }
    }

    public void OverheatCollDown() //過熱值冷卻
    {
        if (!_drill.is_Drill_attack)
        {
            if (player.overheat_value > 0)
                player.overheat_value -= 0.1f * Time.deltaTime;
        }
    }

    public IEnumerator SetOverheat()
    {
        player.isOverheat = true;

        yield return new WaitForSeconds(2);
        player.isOverheat = false;

        yield return null;
    }

    public void SetDizzy(int dizzyTime)
    {
        StartCoroutine(StartDizzy(dizzyTime));
    }

    public IEnumerator StartDizzy(int dizzyTime)
    {
        player.isDizzy = true;
        Debug.Log(player + "被砸暈");

        yield return new WaitForSeconds(dizzyTime);

        player.isDizzy = false;
        Debug.Log(player + "解除暈眩");

        yield return null;
    }

    public void StartMoveToHookFixedPosition(Vector3 HookFixedPoint) //移動到鈎爪觸發點
    {
        StartCoroutine(MoveToHookFixedPosition(HookFixedPoint));
    }
    public IEnumerator MoveToHookFixedPosition(Vector3 HookFixedPoint) //移動到鈎爪觸發點
    {
        int _flySpeed = 10;
        float radius = 0.1f; //檢測半徑
        bool isReach = false;

        while (!isReach) //如果是否抵達為false
        {
            Collider[] cols = Physics.OverlapSphere(HookFixedPoint, radius);
            if (cols.Length > 0)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].gameObject == this.gameObject)
                    {
                        Debug.Log("已抵達hookpoint");
                        isReach = true;
                    }
                }
            }
            radius += 0.5f * Time.deltaTime;
            player.transform.localPosition = Vector3.MoveTowards(player.transform.localPosition, HookFixedPoint, _flySpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    public enum Equipment
    {
        no_have_equipment = 0,
        drill, //鑽頭 Drill
        pile_driver, //打樁機 Pile_driver
        demolition_hamer, //鑿破機 Demolition_hammer
    }

    public enum Props //道具
    {
        no_have_props = 0,
        shield, //護盾
        speed, //加速
        brick, //磚頭
        boom, //炸藥
        mines, //地雷
        hook, //鈎爪
    }
    public enum MyTeam //隊伍狀態
    {
        Nobody = 0,
        Team1 = 1,
        Team2 = 2,
        Team3 = 3,
        Team4 = 4,
    }
}
