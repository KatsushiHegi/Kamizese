using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationDisplayManager : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    [SerializeField] Button SortButton;
    [SerializeField] GameObject PopulationDisplayElementPref;
    [SerializeField] Transform Parent;

    Prefecture[] prefectures = new Prefecture[47];
    Prefecture[] sortedPrefectures = new Prefecture[47];
    private Status status;

    private enum Status{
        Normal,
        Sort,
    }
    
    private void Start(){
        SortButton.onClick.AddListener(() => Change());
    }

    /// <summary>
    /// 人口を更新します
    /// </summary>
    public void UpdatePopulation(){
        for(int i = 0 ; i < PrefectureManager.prefectureControllers.Length ; i++){
            prefectures[i] = PrefectureManager.prefectureControllers[i].prefecture;
            sortedPrefectures[i] = prefectures[i];
        }
        QuickSort(sortedPrefectures, 0, sortedPrefectures.Length-1);
        Disp(prefectures);
        status = Status.Normal;
    }

    private void Disp(Prefecture[] prefectures){
        Color[] ruralColors = new Color[8]{
            new Color(105.0f/255.0f,124.0f/255.0f,156.0f/255.0f),
            new Color(99.0f/255.0f,164.0f/255.0f,198.0f/255.0f),
            new Color(123.0f/255.0f,187.0f/255.0f,107.0f/255.0f),
            new Color(206.0f/255.0f,174.0f/255.0f,204.0f/255.0f),
            new Color(223.0f/255.0f,156.0f/255.0f,34.0f/255.0f),
            new Color(181.0f/255.0f,131.0f/255.0f,80.0f/255.0f),
            new Color(171.0f/255.0f,90.0f/255.0f,139.0f/255.0f),
            new Color(244.0f/255.0f,151.0f/255.0f,89.0f/255.0f),
        };
        foreach(Transform child in Parent){
            Destroy(child.gameObject);
        }
        for(int i = 0 ; i < prefectures.Length ; i++){
            var ins = Instantiate(PopulationDisplayElementPref,Parent);
            var pdec = ins.GetComponent<PopulationDisplayElementController>();



            pdec.SetPrefectureText(
                prefectures[i].prefectureName, 
                ruralColors[prefectures[i].ruralId]
                );
            pdec.SetPopulationText(
                prefectures[i].population, 
                prefectures[i].population < 265? new Color(30.0f/255.0f,71.0f/255.0f,136.0f/255.0f) : 
                prefectures[i].population > 5035? new Color(244.0f/255.0f,88.0f/255.0f,88.0f/255.0f) : 
                new Color(0,0,0)
            );
        }
    }
    
    private void Change(){
        if(status == Status.Normal){
            Disp(sortedPrefectures);
            status = Status.Sort;
        }
        else{
            Disp(prefectures);
            status = Status.Normal;
        }
    }

    //クイックソート
    private void QuickSort(Prefecture[] prefectures, int left, int right)
    {

        if (left >= right) return;

        Prefecture pivot = Median(
            prefectures[left],
            prefectures[(left + right) / 2],
            prefectures[right]
        );

        int i = left;
        int j = right;

        while (i <= j)
        {
            while (i < right && prefectures[i].population.CompareTo(pivot.population) > 0) i++;
            while (j > left && prefectures[j].population.CompareTo(pivot.population) < 0) j--;

            if (i >= j) break;
            Swap(ref prefectures[i], ref prefectures[j]);

            i++;
            j--;
        }

        QuickSort(prefectures, left, i - 1);
        QuickSort(prefectures, j + 1, right);
    }

    private Prefecture Median(Prefecture x, Prefecture y, Prefecture z){
        if(x.population.CompareTo(y.population) > 0) Swap(ref x, ref y);
        if(x.population.CompareTo(z.population) > 0) Swap(ref x, ref z);
        if(y.population.CompareTo(z.population) > 0) Swap(ref x, ref z);
        return y;
    }

    private void Swap(ref Prefecture x, ref Prefecture y){
        var tmp = x;
        x = y;
        y = tmp;
    }
}
