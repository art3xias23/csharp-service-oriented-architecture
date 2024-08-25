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

## Message Driven vs Event Driven design

Now, I went throught the message driven and then the event driven type of archutectures and I believed I saw the exact same thing. So I went looking for answers.

First item of evidence is the [Reactive Manifesto](https://www.lightbend.com/blog/reactive-manifesto-20)

>The difference being that messages are directed, events are not—a message has a clear addressable recipient while an event just happen for others (0-N) to observe it.

For example, if we use RabbitMq, what the above says is that 
- We use messages to send to a specicif queue or an exchange with a routing key.
- We use events in a fanout exchange, where we send a notification to anyone listening.

The manifesto also adds.

>A message is an item of data that is sent to a specific destination. An event is a signal emitted by a component upon reaching a given state

This leads me to believe that we would 
- send a message when we want to action something. We want to say this needs to happen.
- send an event when something has already happened.

Second source would be this [comparison](https://www.techtarget.com/searchapparchitecture/tip/Event-driven-vs-message-driven-It-comes-down-to-complexity)
>Messages feel very much like classic programming models: call a function, wait for a result, do something with the result. Along with being familiar to most programmers, this structure can also make debugging more straightforward. Another advantage is that messages "block," which means individual units of calls and responses sit and wait for their turn for processing by the recipient. Events, on the other hand, simply make their mark on the queue and allow the recipient to address it at its convenience, meanwhile moving on to the next call in the chain. This adds a lot of flexibility and speed when it comes to managing and executing unruly amounts of transactions.

The above states that for the message pattern since the publisher knows where the message is going, then the publisher will be expecting an answer.

