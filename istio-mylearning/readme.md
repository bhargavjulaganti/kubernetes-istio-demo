# Docker Image

### v1.0

```DockerFile
docker pull julagantib/demo-api:v1.0 
```
- Contains only 1 endpoint (/weatherforecast)

### v2.0
- Contains only 1 endpoint (/weatherforecast), but returns below additional object always as part of the response

```json
{
    "date": "2024-09-07", // Date will be in past
    "temperatureC": -13,
    "summary": "Storming",
    "temperatureF": 9
}
```

### v4.0

- Created a new endpoint /jsonwebserver, to call the json placeholder and return the response
```cs

app.MapGet("/JsonServer", async (HttpClient httpClient) =>
{
    var response = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
    return response;
})
.WithName("GetFromJsonServer")
.WithOpenApi();

```

# Create Simple Istio Service

### Create the deployment, ServiceAccount, Gateway and VirtualService

```bash
# Create the deployment and ServiceAccount First 
kubectl apply -f demo-api.yml

# Create the GateWay and Virtual Service 
kubectl apply -f demo-gateway.yml
```

### Do a port-forward
```bash
kubectl port-forward svc/istio-ingressgateway -n istio-system 8080:80
```

### Hit the endpoint http://127.0.0.1:8080/weatherforecast

<img width="1341" alt="image" src="https://github.com/user-attachments/assets/5431e68b-0a9a-430d-91ea-06489b99ac48">

### Can see the traffic on the kiali
<img width="1707" alt="image" src="https://github.com/user-attachments/assets/8651905e-cb75-42f8-8933-fd2c60071698">


# Route traffic between 2 pods/docker-containers

Note: Before running make sure to delete all the existing services,gateways etc

### Create the deployment, ServiceAccount, Gateway and VirtualService
```bash
# Create the deployment and ServiceAccount First 
kubectl apply -f multiple-pods/demo-api.yml

# Create the GateWay and Virtual Service 
kubectl apply -f multiple-pods/demo-gateway.yml
```
---


<img width="929" alt="image" src="https://github.com/user-attachments/assets/39620189-d07b-4195-b072-66e744974e45">

#### Traffic is distributed between the pods versions of deployment (v1 & v2)

<img width="1553" alt="image" src="https://github.com/user-attachments/assets/e634c43e-f5ba-43eb-9a18-c6599629b90c">
