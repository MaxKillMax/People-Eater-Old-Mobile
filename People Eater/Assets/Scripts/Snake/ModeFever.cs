using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class ModeFever : MonoBehaviour
{
    [SerializeField] Text TXT;
    [SerializeField] SnakeMove snakeMove;

    int CrystalCount;
    bool feverMode = false;
    public bool FeverMode { set { feverMode = value; } }
    public void AddCrystal()
    {
        if (!feverMode)
        {
            CrystalCount++;
            if (CrystalCount == 3)
            {
                feverMode = true;
                snakeMove.ActivateFever();
                CrystalCount = 0;
            }

            TXT.text = CrystalCount.ToString("N0", CultureInfo.CurrentCulture);
        }
    }
}
