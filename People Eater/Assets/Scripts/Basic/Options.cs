using UnityEngine;
using UnityEngine.UI;

// Данный скрипт связывается с StaticOptions с меню настроек
public class Options : MonoBehaviour
{
    [SerializeField] Toggle Immortality;

    private void Start()
    {
        Immortality.isOn = StaticOptions.Immortality;
    }

    public void SetImmortality()
    {
        StaticOptions.GetImmortality(Immortality.isOn);
    }
}
