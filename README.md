VineSharp
=========

Wrapper for the undocumented Vine API. Since it is undocumented, it is also unsupported and is subject to change. This library is not intended for production use.

https://www.nuget.org/packages/VineSharp/


Getting Started
---------------

    Install-Package VineSharp

Since Vine does not provide public OAuth for Apps, a username and password are required to obtain a valid token.

    var vineClient = new VineClient();
    vineClient.SetCredentials(Username, Password);

*- OR -*

    var vineClient = new VineClient(Username, Password);

``VineClient`` will automatically authenticate with the provided credentials when it needs too.

Base Response
-------------
The Vine API wraps all responses with a standard wrapper.

    {
      "code": "",
      "success": true,
      "error": "",
      "data": {...}
    }

The Basics
----------
All calls to the Vine API are async.

    var result = await vineClient.MyProfile();
    //result.Data.AvatarUrl

Most calls are also wrapped with a standard paging wrapper.
    
    var options = new new VinePagingOptions
    {
        Size = 5,
        Page = 2
    };
    var result = await vineClient.TagTimeline("test", options);
    
    foreach(var post in result.Data.Records)
    {
        // do something
    }

Endpoints Convered
------------------

Users
 - users/authenticate
 - users/me
 - users/profile/{userId}
 - users/{userId}/followers

Timelines
 - MyTimeline wrapper for the authenticated user
 - timelines/users/{userId}
 - timelines/tags/{tag}
 - timelines/posts/{postId} (single post in the standard paging wrapper)

Post Details
 - posts/{postId}/likes
 - posts/{postId}/comments
