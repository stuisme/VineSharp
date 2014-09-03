VineSharp
=========

Wrapper for the undocumented Vine API. Since it is undocumented, it is also unsupported and is subject to change. This library is not intended for production use.

Since Vine does not have a documented API, or the ability to OAuth. You must provide a username and password to obtain a valid token.

Getting Started
---------------

    var vineClient = new VineClient();
    vineClient.SetCredentials(Username, Password);

*- OR -*

    var vineClient = new VineClient(Username, Password);

``VineClient`` will automatically authenticate with the provided credentials when it needs too.

Base Response
-------------
The vine API wraps all thier responses with a standard wrapper.

    {
      "code": "",
      "success": true,
      "error": "",
      "data": {...}
    }

The Basics
----------
All call to the vine server are async.

    var result = await vineClient.MyProfile();
    //result.Data.AvatarUrl

Most calls are also wrapped the their standard paging wrapper.
    
    var options = new new VinePagingOptions
    {
        Size = 5,
        Page = 2
    };
    var result = await vineClient.TagTimeline("test", options);
    
    foreach(var post in result.Data.Records){
        // do something
    }
