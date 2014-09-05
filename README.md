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
var options = new new VinePagingOptions
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

Users
 - users/authenticate
 -- POST
 - users/me
 -- GET
 - users/profile/{userId}
 -- GET
 - users/{userId}/followers
 -- GET

Timelines
 - timeline/users/me
 -- GET
 - timelines/users/{userId}
 -- GET
 - timelines/tags/{tag}
 -- GET
 - timelines/posts/{postId} (single post in the standard paging wrapper)
 -- GET

Post Details
 - posts/{postId}/likes
 -- GET
 -- POST
 -- DELETE
 - posts/{postId}/comments


Special thanks to https://github.com/starlock/vino for helping me "git" started
