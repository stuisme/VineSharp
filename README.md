VineSharp
=========

Wrapper for the undocumented Vine API. Since it is undocumented, it is also unsupported and is subject to change. This library is not intended for production use.

https://www.nuget.org/packages/VineSharp/


Getting Started
---------------

    Install-Package VineSharp

Since Vine does not provide public OAuth for Apps, a username and password are required to obtain a valid token.

    var vineClient = new VineClient(Username, Password);
    
*- OR -*

    var vineClient = new VineClient();
    vineClient.SetCredentials(Username, Password);

``VineClient`` will automatically authenticate with the provided credentials when it needs too. If you would like to store the token for later use, you can call ``VineClient.Authenticate()``.

*``VineClient.SetCredentials`` will cuase the current authenticated user to be reset.

Base Response
-------------
The Vine API wraps all responses with a standard wrapper.

```
{
  "code": "",
  "success": true,
  "error": "",
  "data": {...}
}
```

Most calls are also wrapped with a standard paging wrapper.

```
{
  "code": "",
  "success": true,
  "error": "",
  "data": {
    "count": 499,
    "size": 20,
    "anchorStr": "1234567890",
    "anchor": 1234567890,
    "backAnchor": "9876543210"
    "records": [...]
  }
}
```

The Basics
----------
All calls to the Vine API are async.

```
var result = await vineClient.MyProfile();
//result.Data.AvatarUrl
```

You can navigate through the pages with the optional paging options parameter.

```    
var options = new VinePagingOptions
{
    Size = 5,
    Page = 2,
    Anchor = 123456789
};
var result = await vineClient.TagTimeline("test", options);

foreach(var post in result.Data.Records)
{
    // do something
}
```

Endpoints Covered
------------------

### Users

| Endpoint                    | Verb    | Method                                      | Comments
|-----------------------------|---------|---------------------------------------------|-------------
| users/authenticate          | POST    | .Authenticate()                             | Uses form encoded body
| users/me                    | GET     | .MyProfile()                                | Profile
| users/profile/{userId}      | GET     | .UserProfile(userId)                        | Profile
| users/me/followers          | GET     | .MyFollowers(pagingOptions)                 | Paged Followers
| users/{userId}/followers    | GET     | .UserFollowers(userId, pagingOptions)       | Paged Followers
| users/me/following          | GET     | .MyFollowing(pagingOptions)                 | Paged Followers
| users/{userId}/following    | GET     | .UserFollowing(userId, pagingOptions)       | Paged Followers

### Timelines
| Endpoint                    | Verb    | Method                                      | Comments
|-----------------------------|---------|---------------------------------------------|----------
| timeline/users/me           | GET     | .MyTimeline(pagingOptions)                  | Paged Posts
| timelines/users/{userId}    | GET     | .UserTimeline(userId, pagingOptions)        | Paged Posts
| timelines/popular           | GET     | .PopularTimeline(pagingOptions)             | Paged Posts
| timelines/tags/{tag}        | GET     | .TagTimeline(tag, pagingOptions)            | Paged Posts
| timelines/posts/{postId}    | GET     | .Post(postId)                               | Paged Posts with only 1 record

### Posts
| Endpoint                    | Verb    | Method                                      | Comments
|-----------------------------|---------|---------------------------------------------|----------
| posts/{postId}/likes        | GET     | .Likes(postId, pagingOptions)               | Paged Likes
| posts/{postId}/likes        | POST    | .AddLike(postId)                            | Like Creation
| posts/{postId}/likes        | DELETE  | .RemovedLike(postId)                        | Empty Data
| posts/{postId}/comments     | GET     | .Comments(postId, pagingOptions)            | Paged Comments



Special thanks to https://github.com/starlock/vino for helping me "git" started
