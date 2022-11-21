using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public SerializedDictionary<string, List<int>> testDict = new SerializedDictionary<string, List<int>>();
    
    async void Start()
    {
        return;
        var x = new List<int>() {6,5,4,3,2,1};
        SaveManager.SaveDates("Nie",x,"TestFile");
        

        x = new List<int>() {1, 2, 3, 4, 5, 6}; 
        SaveManager.SaveDates("Tak",x,"TestFile",ModificationType.Append);

        await Task.Delay(1000 * 5);
        x = new List<int>() {1, 2, 3, 4, 5, 6};
        SaveManager.SaveDates("Nwm",x,"TestFile",ModificationType.Append);
        
        var test= SaveManager.LoadDates<int>("Nie", "TestFile");
        foreach (var a in test)
        {
            Debug.Log(a);
        }
    }
    
    void Update()
    {
        
    }
}
