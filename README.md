# Microservices API 

![API Architecture](https://raw.githubusercontent.com/ouss4m4/k8s-net-rabbitmq/main/k8s-ms-arch-example.png)


This Project covers the following: 

*  PlatformService API built in .NETCore using REST API Pattern
* CommandService API built in .NETCore using REST API Pattern
* SQLServer for the PlatformService - with PersistentVolumeClaim 
* InMemory database using EntityFramework for the CommandService
* NODEPORT service in K8S for local access
• Ingress Nginx for proxe reverse (API Gateway)
* ClusterIP configuration for networking (port forwarding between the 2 sevices)
• Building Synchronous messaging between services (HTTP & gRPC)
• Building Asynchronous messaging between services using an Event Bus ()
• Deploying our services to Kubernetes cluster

The 2 API are not full of features because the main goal of this project is not building a complex API, but rather deploying a microservice architecture to kubernetes.  
the API runs on different Ports & hostnames between Development environment, and Production. 

Sadly API Is not deployed on a public hosting service for the lack of free or developers plans that provide Clusters for free.


Inspired by : https://youtu.be/DgVjEo3OGBI 




