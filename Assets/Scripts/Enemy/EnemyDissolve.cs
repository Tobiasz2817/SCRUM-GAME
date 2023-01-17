using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDissolve : MonoBehaviour
{
    [SerializeField] private List<SkinnedMeshRenderer> skinnedMeshRenderers = new List<SkinnedMeshRenderer>();
    [SerializeField] private float durationDissolve = 2f;
    
    public async void TurnDissolves(float endValue) {
        foreach (var skinned in skinnedMeshRenderers) {
            EnableDissolve(skinned,endValue);
        }
    }

    private void EnableDissolve(SkinnedMeshRenderer skinnedMeshRenderer, float endValue) {
        skinnedMeshRenderer.materials[1].DOFloat(endValue,"_Cutoff", durationDissolve);
    }

    public float GetDurationDissolve() {
        return durationDissolve;
    }
}
