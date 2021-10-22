# Full_Net_Microservices

-- dotnet --version
-- code -r /Name of Project/ // calling this from the terminal will open our project in vs code
--  dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
-- dotnet add package Microsoft.EntityFrameworkCore
-- dotnet add package Microsoft.EntityFrameworkCore.Design
--  dotnet add package Microsoft.EntityFrameworkCore.InMemory
-- dotnet add package Microsoft.EntityFrameworkCore.Tools
--  dotnet build
-- dotnet run

DOCKER
--  docker --version  //Check if docker is running

-- docker build -t wisdomnwachukwu/servicesplatform .
-- docker run -p 8080:80 -d wisdomnwachukwu/servicesplatform 

-- docker stop /containerId/
-- docker start /containerId/

-- docker push wisdomnwachukwu/servicesplatforms

KUBERNETES
 cd Kubernetes 
 --kubectl apply -f platforms-depl.yaml
 --kubectl get deployments
 -- kubectl get pods
-- kubectl rollout restart deployment platform-depl 
 --  kubectl delete deployment cataloguedash-deployment
 --  kubectl get services

 COMMAND SERVICE
 -- dotnet new webapi -n ServicesCommands

 -- code -r \project\ to open a particular project
 -- kubectl rollout restart deployment platform-depl

 NGINX
 --https://kubernetes.github.io/ingress-nginx/
 -- kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.0.1/deploy/static/provider/cloud/deploy.yaml
 -- kubectl get namespace

 -- kubectl get pods --namespace=ingress-nginx

 -- kubectl get pvc

 -- kubectl create secret generic mssql--from-literal=SA_PASSWORD="secretPassword"

 --  dotnet ef migrations add InitialMigration

 --  dotnet add package RabbitMQ.Client

 PLATFORM GRPC
 -- dotnet add package Grpc.AspNetCore

 COMMAND GRPC
-- dotnet add package Grpc.Tools
-- dotnet add package Grpc.Net.Client
-- Google.Protobuf



 



