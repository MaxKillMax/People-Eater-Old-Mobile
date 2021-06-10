using UnityEngine;
using UnityEngine.UI;

// ������ ������ ����������� � StaticOptions � ���� ��������
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
