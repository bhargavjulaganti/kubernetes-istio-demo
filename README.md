# Docker Image

- `docker pull julagantib/demo-api:v1.0`
- `docker run -d -p 8080:8080 --name demo-container julagantib/demo-api:v1.0` → Run the Docker image

# Pushing Docker Image

- `docker build -t julagantib/demo-api:v2.0 .`
- `docker push julagantib/demo-api:v2.0`

## Start Minikube

- `minikube start` → To start Minikube
- `minikube start --memory=8192mb --cpus=4` --> start with more memory
- `minikube dashboard` → To open the dashboard on the UI

## Create Deployment

- `kubectl create deployment demo-deployment --image=julagantib/demo-api:v1.0`

## Access the Deployment Using the Proxy

- `kubectl proxy` → To create the proxy
- `kubectl get pods` → Get the pod name
- Sample endpoint: `http://localhost:8001/api/v1/namespaces/default/pods/demo-deployment-8487df47c4-qkz97:8080/proxy/weatherforecast` → Hit the container

## Expose the App Publicly

- `kubectl get services`
- `kubectl expose deployment/<deployment-name> --type="NodePort" --port 8080` → Expose the deployment
- `minikube service <kubernetes-bootcamp> --url` → If Kubernetes is running inside Docker, run this command to get the public URL
  - [Kubernetes Documentation: Exposing Services](https://kubernetes.io/docs/tutorials/kubernetes-basics/expose/expose-intro/)

## Scale the Deployment

- `kubectl get rs` → To get the number of replica sets
- `kubectl scale deployments/<demo-deployment> --replicas=4` → To increase the replica sets
- `kubectl get pods -o wide` → View 4 instances of pods with different IP addresses

# Lesson 1 - To create a new deployment using yml

- `kubectl apply -f demo-deployment.yml` → To create the new deployment
- Since the YAML file does not define a Service, you need to expose a Service to access the deployment publicly.
- Run this command to expose the deployment via NodePort: `kubectl expose deployment/<example-deployment> --type="NodePort" --port 8080`

**Note:** Since we are running Minikube inside a Docker container, you need to run the following command to access the pod via Docker:
`minikube service <example-deployment> --url`

# Lesson 2 - Expose the deployment via NodePort using yml configuration

- `kubectl apply -f demo-deployment.yml` → To create the new deployment
- Since the YAML file includes a Service, you just need to run `minikube service <example-deployment> --url` to expose it publicly.
- To delete the complete deployment --> `kubectl delete  -f demo-deployment.yml`

# Services
In theory, you could talk to these pods directly, but what happens when a node dies? The pods die with it, and the ReplicaSet inside the Deployment will create new ones, with different IPs. This is the problem a Service solves
- 

# Argo Credentials 

username/password : admin/Bh@17037