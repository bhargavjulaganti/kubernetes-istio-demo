# To create the deployment

 -  kubectl apply -f demo-deployment.yml  --> To create the new deployment
 -  Since in the yaml file no svc is defined, we need to expose a svc to hit the deployment publicily
 -  Run this command to expose the deployment via node port --> `kubectl expose deployment/<example-deployment> --type="NodePort" --port 8080`

Note:  Since we are running minikube inside docker container, we need to run the below command to access pod via docker
`minikube service <example-deployment> --url`