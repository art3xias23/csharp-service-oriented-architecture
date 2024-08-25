# csharp-service-oriented-architecture

The point of this repo is to go over 6 patterns in Service Oriented Architecture.

1. Fine grained service oriented architecture
2. Layered APIs over fine grained soa
3. Message oriented state management over layered APIs 
4. Event driven state management over layered APIs 
5. Isolating state in layered APIs
6. Replicating state in layered APIs (event sourcing)


## Fine Grained Service Oriented Architecture

Involves breaking down an application into smaller, more focused services which could be deployed on their own.
You can see the granularity presented via the IOrdersService and the IProductService.

## Layered Over APIs Over Fine Grained Service Oriented Architecture

Involves aggregating the fine grained services, thus providing a higher level abstraction for the easier interaction of the client with the API.
