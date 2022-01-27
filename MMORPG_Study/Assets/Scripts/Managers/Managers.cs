using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장됨
    static Managers Instance { get { Init(); return s_instance; } } // 유일한 매니저를 갖고온다.

    InputManager _input = new InputManager();
    ResourcesManager _resources = new ResourcesManager();
    UIManager _ui = new UIManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourcesManager Resource { get { return Instance._resources; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }

    void Start()
    {
        // 초기화
        Init();
    }

    void Update()
    {
        _input.OnUpdate();     
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._sound.Init();
        }
    }

    public static void Claer()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
    }
}
