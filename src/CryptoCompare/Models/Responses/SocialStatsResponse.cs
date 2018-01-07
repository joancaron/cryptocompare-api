using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CryptoCompare
{
    public partial class SocialStatsResponse
    {
        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }

        [JsonProperty("Data")]
        public SocialStats SocialStats { get; set; }
    }

    public partial class SocialStats
    {
        [JsonProperty("General")]
        public General General { get; set; }

        [JsonProperty("CryptoCompare")]
        public CryptoCompare CryptoCompare { get; set; }

        [JsonProperty("Twitter")]
        public Twitter Twitter { get; set; }

        [JsonProperty("Reddit")]
        public Reddit Reddit { get; set; }

        [JsonProperty("Facebook")]
        public Facebook Facebook { get; set; }

        [JsonProperty("CodeRepository")]
        public CodeRepository CodeRepository { get; set; }
    }

    public partial class CryptoCompare
    {
        [JsonProperty("SimilarItems")]
        public SimilarItem[] SimilarItems { get; set; }

        [JsonProperty("CryptopianFollowers")]
        public CryptopianFollower[] CryptopianFollowers { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }

        [JsonProperty("Followers")]
        public long Followers { get; set; }

        [JsonProperty("Posts")]
        public string Posts { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("PageViewsSplit")]
        public PageViewsSplit PageViewsSplit { get; set; }

        [JsonProperty("PageViews")]
        public long PageViews { get; set; }
    }

    public partial class SimilarItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("FollowingType")]
        public long FollowingType { get; set; }
    }

    public partial class PageViewsSplit
    {
        [JsonProperty("Overview")]
        public long Overview { get; set; }

        [JsonProperty("Markets")]
        public long Markets { get; set; }

        [JsonProperty("Analysis")]
        public long Analysis { get; set; }

        [JsonProperty("Charts")]
        public long Charts { get; set; }

        [JsonProperty("Trades")]
        public long Trades { get; set; }

        [JsonProperty("Orderbook")]
        public long Orderbook { get; set; }

        [JsonProperty("Forum")]
        public long Forum { get; set; }

        [JsonProperty("Influence")]
        public long Influence { get; set; }
    }

    public partial class CryptopianFollower
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    public partial class General
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CoinName")]
        public string CoinName { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }
    public partial class Twitter
    {
        [JsonProperty("following")]
        public string Following { get; set; }

        [JsonProperty("account_creation")]
        public string AccountCreation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lists")]
        public long Lists { get; set; }

        [JsonProperty("statuses")]
        public long Statuses { get; set; }

        [JsonProperty("favourites")]
        public string Favourites { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public partial class Reddit
    {
        [JsonProperty("posts_per_hour")]
        public string PostsPerHour { get; set; }

        [JsonProperty("comments_per_hour")]
        public string CommentsPerHour { get; set; }

        [JsonProperty("posts_per_day")]
        public string PostsPerDay { get; set; }

        [JsonProperty("comments_per_day")]
        public long CommentsPerDay { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("active_users")]
        public long ActiveUsers { get; set; }

        [JsonProperty("community_creation")]
        public string CommunityCreation { get; set; }

        [JsonProperty("subscribers")]
        public long Subscribers { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public partial class Facebook
    {
        [JsonProperty("likes")]
        public long Likes { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("is_closed")]
        public string IsClosed { get; set; }

        [JsonProperty("talking_about")]
        public string TalkingAbout { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public partial class CodeRepository
    {
        [JsonProperty("List")]
        public Repository[] Repositories { get; set; }

        [JsonProperty("Points")]
        public long Points { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("InternalId")]
        public long InternalId { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("open_total_issues")]
        public string OpenTotalIssues { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("closed_total_issues")]
        public string ClosedTotalIssues { get; set; }

        [JsonProperty("stars")]
        public long Stars { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("forks")]
        public long Forks { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("closed_issues")]
        public string ClosedIssues { get; set; }

        [JsonProperty("closed_pull_issues")]
        public string ClosedPullIssues { get; set; }

        [JsonProperty("fork")]
        public string Fork { get; set; }

        [JsonProperty("last_push")]
        public string LastPush { get; set; }

        [JsonProperty("source")]
        public Parent Source { get; set; }

        [JsonProperty("open_pull_issues")]
        public string OpenPullIssues { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("subscribers")]
        public long Subscribers { get; set; }

        [JsonProperty("open_issues")]
        public string OpenIssues { get; set; }
    }
}
