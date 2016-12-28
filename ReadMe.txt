Thank you for the opportunity and welcome to my Homework for Guaranteed Rate. I am excited to share it with you.

Some things to know in order to run:

>I have included the sample files in the command line window, in the Console > Properties > Build window for ease. 
>There is a specific order, as outlined in the Program Console, it can be changed, but it has to match. It is currently comma, pipe, space.
>The Web API can be run from http://localhost:13080/api/Records/Name, or any of the HTTPGET to start off.
>Authentication, Authorization, Dependency Injection was considered outside the scope of this assignment. 
>Unit testing was saved for the main implementations, trivial infrastructure and factories where not put under test.
>Web API returns are all serialzed to JSON format.
>There are strategy patterns for both builder classes and Persons model.

Approach 

Modularity, SOLID, and patterns where emphasized in the design. A unique and opinionated Builder Pattern was used for the
console and services clients. The Builder Pattern was implemented with a unique Fluent API that is meant to read like a 
sentance and be near fool-proof in its implementation. The main idea is that the intellisense will clearly guide the client
to making the correct decision. The result is clean, sentance like API's that clearly read the steps and process and requirements
taken. 

The builders, one from Files, and the other from a Mock Data source, both derive from abstract builder class, to a PersonsFileBuilder and
PersonsRestBuilder, respectively. Confusion and knee jerk can stem if one has never seen the Interface holder approach. This at first seems tricky, 
but can be appreciated quickly. The idea is leveraging the Interface Segregation Principle. Instead of returning void or a value type and burdening the 
client with what the next step is, Holder Interfaces dicatate 1-2 methods that are implemented in the abstract parent builder if shared, or if
specific to the build process, implemented in the child builder. The reward is that only 1 -2 methods are returned, each being known valid steps.
C# makes references to reference types easy and safe, the Holder Pattern very much relies on this.

If built correctly a collection class is returned, that encaplsulates basic collection data types. A strategy pattern is used here
to respect Open/Close principal and give flexibility and modularity to changing requirements. These strategy classes for models and builders
remove the responsbility of specifiying concrete implementation and allow for well defined unit testing, not integration testing. Which is 
where should IoC be implemented. The builders constructors where also set to private. They can only be access statically, so that the correct first
step is guaranteed. This also ensures that malcious or incompetitent clients can not abuse the builders.

The Person Service which is consumed by the Records Controller in the WebApi, is initalized in the Records controller, *Which is not recommended*
for production code. To respect Open/Close principal the service is not burdened with knowning how its initalized, and a delegate is passed in which
must return a  collection class interface (IPersons). This makes the code versiatile, if we need add a data layer we can do so easily here, and still
allow seemless mocking for unit testing.

Another style choice, is the lack of null returns. Instead Singleton Patterns via Singleton Model Classes are created to represent incorrect states such as uninitalized,
null, or empty. This makes reference checking easy, fluent, and controller. It also sets basic states. Only in the build process is checking enforced
and throws exceptions to prevent further progress, as to guarantee a correct state by the time building is called.

A note on extenstion methods, where alot of abuse can occur. Extenstion methods were saved for infrastructure. Strategy classes which could be
intereprted as an extention methods have one major difference: business logic. Extenstion methods should never have business logic embedded in them
and this was respected here.

There might be inconsistences where it comes to internal classes. I am now evolving to not only fluent API's but fluent namespaces as well, and I tried
to avoid namespace pollution as much as possible, however upon writing unit test, several comprimises had to be made.

It is my hope that my passion for coding comes through. I purposefully took the time to make sure SOLID principales where respected as well as a chance
to showcase exciting new code styles that make for beautiful API's. This code is highly flexible, testible, extensiable, and easily read.

Thank you to Guaranteed Rate for the opportunity, I truly hope you enjoy this. 

