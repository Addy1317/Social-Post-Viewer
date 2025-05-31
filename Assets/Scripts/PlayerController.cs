using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SPV
{
    [System.Serializable]
    public class PostData
    {
        public string username;
        public string profilePic;
        public string content;
        public int likes;
    }

    public class PlayerController : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI usernameText;
        [SerializeField] private Image profileImage;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private TextMeshProUGUI likeCountText;
        [SerializeField] private Button likeButton;
        [SerializeField] private Image likeButtonImage;

        [Header("Sprites")]
        [SerializeField] private Sprite likedSprite;
        [SerializeField] private Sprite unlikedSprite;

        [Header("Comment Section")]
        [SerializeField] private GameObject commentPanel;
        [SerializeField] private TextMeshProUGUI commentText;

        private bool isLiked = false;
        private int likeCount;

        private void Start()
        {
            //LoadPostData();
            //likeButton.onClick.AddListener(ToggleLike);
        }
        private void OnDisable()
        {
            likeButton.onClick.RemoveListener(ToggleLike);
        }

        void LoadPostData()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>("postsData");
            if (jsonFile != null)
            {
                PostData postData = JsonUtility.FromJson<PostData>(jsonFile.text);

                usernameText.text = postData.username;
                contentText.text = postData.content;
                likeCount = postData.likes;
                likeCountText.text = likeCount + " Likes";

                // Load profile picture (from Resources folder)
               /* Sprite loadedSprite = Resources.Load<Sprite>(postData.profilePic);
                if (loadedSprite != null)
                    profileImage.sprite = loadedSprite;*/
            }
            else
            {
                Debug.LogError("JSON file not found.");
            }

            UpdateLikeUI();
        }

        private void ToggleLike()
        {
            isLiked = !isLiked;
            likeCount += isLiked ? 1 : -1;
            UpdateLikeUI();
        }

        private void UpdateLikeUI()
        {
            likeCountText.text = likeCount + "";

            if (likeButtonImage != null)
            {
                likeButtonImage.sprite = isLiked ? likedSprite : unlikedSprite;
            }
            else
            {
                likeButton.GetComponentInChildren<Text>().text = isLiked ? "Liked" : "Like";
            }
        }

        internal void InitWithData(PostData data)
        {
            usernameText.text = data.username;
            contentText.text = data.content;
            likeCount = data.likes;
            likeCountText.text = likeCount + " Likes";

            // Load profile pic
            Sprite sprite = Resources.Load<Sprite>(data.profilePic);
            if (sprite != null)
                profileImage.sprite = sprite;

            UpdateLikeUI();
            likeButton.onClick.AddListener(ToggleLike);
        }

        public void OnCommentClicked()
        {
            commentPanel.SetActive(true);
            Debug.Log("Opening Comment Panel");
            commentText.text = "Great post!\nLooking forward to more."; // dummy data
        }

        public void OnCloseComment()
        {
            commentPanel.SetActive(false);
            Debug.Log("Closing Comment Panel");
        }
    }
}