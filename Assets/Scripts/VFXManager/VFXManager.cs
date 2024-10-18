using System;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    static VFXManager _instance;

    [SerializeField] private List<VFXManagerSetup> vfxManagerSetups;

    public enum VFXType
    {
        JUMP
    }

    public static VFXManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VFXManager>();
            }
            return _instance;
        }
    }

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach (var vfxManagerSetup in vfxManagerSetups)
        {
            if (vfxManagerSetup.vfxType == vfxType)
            {
                var vfx = Instantiate(vfxManagerSetup.vfxPrefab);
                vfx.transform.position = position;
                Destroy(vfx, 5);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject vfxPrefab;
}
