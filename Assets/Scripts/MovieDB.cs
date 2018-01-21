using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct movie_data
{
    public GameObject moviePiece;
    public GameObject ARObject;
};

public class MovieDB : MonoBehaviour
{
    static private List<movie_data> movies = new List<movie_data>();
    static private int CurrentIndex = 0;

    static public void CreateMovieList(GameObject[] prefabPiece, GameObject[] ARPrefab)
    {
        if (prefabPiece.Length != ARPrefab.Length)
            return;

        for (int i = 0; i < prefabPiece.Length; ++i)
        {
            movie_data data = new movie_data();
            data.moviePiece = GameObject.Instantiate(prefabPiece[i], Vector3.zero, Quaternion.identity);
            data.ARObject = GameObject.Instantiate(ARPrefab[i], Vector3.zero, Quaternion.identity);

            data.moviePiece.SetActive(false);
            data.ARObject.SetActive(false);

            movies.Add(data);
        }
    }

    static public movie_data GetNextMovie(bool Remove = true)
    {
        movie_data data = movies[CurrentIndex];
        if (Remove == true)
        {

            movies.RemoveAt(CurrentIndex);
        }

        CurrentIndex++;
        CurrentIndex = CurrentIndex % movies.Count;

        data.moviePiece.SetActive(true);

        return data;
    }

    static public movie_data GetPrevious()
    {
        movie_data data = movies[CurrentIndex];
        
        CurrentIndex--;
        CurrentIndex = CurrentIndex < 0 ? movies.Count : CurrentIndex;

        data.moviePiece.SetActive(true);

        return data;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
