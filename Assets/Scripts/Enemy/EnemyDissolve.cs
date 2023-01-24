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
    
    public async void TurnDissolves(float endValue, float duration = 0.0f) {
        if (duration == 0.0f) duration = durationDissolve;
        foreach (var skinned in skinnedMeshRenderers) {
            EnableDissolve(skinned,endValue,duration);
        }
    }

    private void EnableDissolve(SkinnedMeshRenderer skinnedMeshRenderer, float endValue, float duration) {
        skinnedMeshRenderer.materials[1].DOFloat(endValue,"_Cutoff", duration);
    }
    public float GetCurrentValue() {
        return skinnedMeshRenderers[0].materials[1].GetFloat("_Cutoff");
    }
}
