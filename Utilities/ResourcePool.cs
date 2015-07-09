using UnityEngine;
using System.Collections;

public class ResourcePool 
{
	GameObject[] list;
	int _poolSize;
	
	int i;
	
	public ResourcePool(int poolSize, string resourceName, Transform parent = null)
	{
		_poolSize = poolSize;
		list = new GameObject[_poolSize];
		
		for (i = 0; i < _poolSize; i++)
		{
			GameObject temp = (GameObject) GameObject.Instantiate(Resources.Load(resourceName, typeof(GameObject)));
			temp.SetActive(false);
			if (parent) temp.transform.parent = parent;
			list[i] = temp;
		}
	}
	
	public GameObject FirstAvailable
	{
		get
		{
			for (i = 0; i < _poolSize; i++)
			{
				if (!list[i].activeInHierarchy)
				{
					return list[i];
				}
			}
			
			return null;
		}
	}
	
	public GameObject Get(int index)
	{
		return list[index];
	}
}
