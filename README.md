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

-- docker build -t wisdomnwachukwu/serviceplatforms .
-- docker run -p 8080:80 -d wisdomnwachukwu/serviceplatforms 

-- docker stop /containerId/
-- docker start /containerId/

-- docker push wisdomnwachukwu/servicesplatforms

KUBERNETES
 cd Kubernetes 
 --kubectl apply -f platforms-depl.yaml
 --kubectl get deployments
 -- kubectl get pods

 --  kubectl delete deployment cataloguedash-deployment
 --  kubectl get services

 COMMAND SERVICE
 -- dotnet new webapi -n ServicesCommands

