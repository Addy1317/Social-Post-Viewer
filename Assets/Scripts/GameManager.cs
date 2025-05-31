using UnityEngine;

namespace SPV
{

    [System.Serializable]
    public class PostListWrapper
    {
        public PostData[] posts;
    }

    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject postPrefab;
        [SerializeField] private Transform contentParent;

        private void Start()
        {
            LoadAndCreatePosts();
        }

        private void LoadAndCreatePosts()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>("postsData");

            if (jsonFile != null)
            {
                PostListWrapper wrapper = JsonUtility.FromJson<PostListWrapper>(jsonFile.text);

                foreach (PostData postData in wrapper.posts)
                {
                    GameObject postGO = Instantiate(postPrefab, contentParent);
                    PlayerController ui = postGO.GetComponent<PlayerController>();
                    ui.InitWithData(postData); // New method to be added
                }
            }
            else
            {
                Debug.LogError("Could not load postsData.json");
            }
        }
    }
}
