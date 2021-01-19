using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationDisplayManager : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] Button SortButton;
    [SerializeField] Text PopulationText;

    int[] popu = new int[47];
    string[] pref = new string[47];
    bool sortFlag = true;
    string str;
    
    private void Start(){
        SortButton.onClick.AddListener(() => Sort());

        str = null;
        for(int a = 0 ; a < 47 ; a++){
            popu[a] = PrefectureManager.prefectureControllers[a].prefecture.population;
            pref[a] = PrefectureManager.prefectureControllers[a].prefecture.prefectureName;
            str += (pref[a] + " : " + popu[a] + "\n");
        }
        PopulationText.text = str;
    }

    private void Sort(){
        str = null;
        for(int a = 0 ; a < 47 ; a++){
            popu[a] = PrefectureManager.prefectureControllers[a].prefecture.population;
            pref[a] = PrefectureManager.prefectureControllers[a].prefecture.prefectureName;
        }
        if (sortFlag == true){
            QuickSort(pref, popu, 0, 46);
            for(int a = 46 ; a >= 0 ; a--){
                str += (pref[a] + " : " + popu[a] + "\n");
            }
            PopulationText.text = str;   
            sortFlag = false;
        }
        else{
            for(int a = 0 ; a < 47 ; a++){
                str += (PrefectureManager.prefectureControllers[a].prefecture.prefectureName + " : " + PrefectureManager.prefectureControllers[a].prefecture.population + "\n");
            }
            PopulationText.text = str;
            sortFlag = true;
        }
    }

    private void QuickSort(string[] pref, int[] array, int left, int right){

        if(left >= right) return;

        int pivot = Median(array[left], array[(left + right)/2], array[right]);

        int i = left;
        int j = right;

        while(i <= j){
            while(i < right && array[i].CompareTo(pivot) < 0) i++;
            while(j > left && array[j].CompareTo(pivot) >= 0) j--;

            if(i > j) break;
            Swap(ref array[i], ref array[j]);
            SwapStr(ref pref[i], ref pref[j]);

            i++;
            j--;
        }

        QuickSort(pref, array, left, i - 1);
        QuickSort(pref, array, i, right);
    }

    private int Median(int x, int y, int z){
        if(x.CompareTo(y) > 0) Swap(ref x, ref y);
        if(x.CompareTo(z) > 0) Swap(ref x, ref z);
        if(y.CompareTo(z) > 0) Swap(ref x, ref z);
        return y;
    }

    private void Swap(ref int x, ref int y){
        var tmp = x;
        x = y;
        y = tmp;
    }

    private void SwapStr(ref string x, ref string y){
        string tmp = x;
        x = y;
        y = tmp;
    }
}
