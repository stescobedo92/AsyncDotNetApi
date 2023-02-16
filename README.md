# AsyncDotNetApi

Decouple backend processing from a frontend host, where backend processing needs to be asynchronous, but the frontend still needs a clear response.

## Context and problem

In modern application development, it's normal for client applications — often code running in a web-client (browser) — to depend on remote APIs to provide business logic and compose functionality. These APIs may be directly related to the application or may be shared services provided by a third party. Commonly these API calls take place over the HTTP(S) protocol and follow REST semantics.

In most cases, APIs for a client application are designed to respond quickly, on the order of 100 ms or less. Many factors can affect the response latency, including:

* An application's hosting stack.
* Security components.
* The relative geographic location of the caller and the backend.
* Network infrastructure.
* Current load.
* The size of the request payload.
* Processing queue length.
* The time for the backend to process the request.

If you know more about this topic please visit the next url: [Asynchronous Request-Reply pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/async-request-reply)

## Build

dotnet build

## Run

dotnet run
