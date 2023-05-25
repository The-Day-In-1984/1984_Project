using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MissionObject : MonoBehaviour
{
    // 1. 미션을 설정할 수 있어야 함
    // 2. 미션을 완료하면 미션이 다시 선택되지 않아야 함
    // 3. 미션은 중간에 종료될 수 있고, 다시 시작할 수 있음
    [SerializeField] private string _missionName;
    private Renderer _sphereRenderer;
   
    void Start()
    {
        _sphereRenderer = GetComponent<Renderer>();
    }
    
    public void SetOutlineColor(Color color)
    {
        _sphereRenderer.material.EnableKeyword("OUTBASE_ON");
        _sphereRenderer.material.SetColor("_OutlineColor", color);
    }
    
    public void DisableOutline()
    {
        _sphereRenderer.material.DisableKeyword("OUTBASE_ON");
    }
    
    public async Task Interact()
    {
        var mission = GameManager.UI.PopupPush(_missionName);
        await mission.GetComponentInChildren<MissionController>().MissionComplete(MissionComplete);
    }

    private void MissionComplete()
    {
        gameObject.tag = "Untagged";
        _sphereRenderer.material.DisableKeyword("DOODLE_ON");
        DisableOutline();
    }
}
