## Whats This Repository?

In this project, an API sample has been designed in accordance with rest standards in microservice architecture.
DDD and CQRS patterns were applied in the project.

**Note: For simplicity of implementation, product and category are included in a single API. Due to the microservice architecture structure, it will be healthier to separate the two processes and connect them to different databases.**

## Requirements

* Visual Studio or VS Code
* .Net Core 5 or later
* Docker Desktop

## Run The Project

**docker-compose up -d**

**Api:** http://localhost:19450/

**Mongo Express:** http://localhost:8081/
* **Username:** admin
* **Password:** case

**Kibana:** http://localhost:5602/

## Flowchart

## Without EventBus
![CaseStudyWithoutEventBus drawio](https://user-images.githubusercontent.com/31844234/149674855-ef8c9112-44dc-4b21-aa91-dbcb9b310fac.png)

## With EventBus
![WithEventBus drawio](https://user-images.githubusercontent.com/31844234/149674870-575cabe7-555f-46a2-ae07-310b5a535402.png)
