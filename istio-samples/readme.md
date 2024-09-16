## Minikube

```bash
# start minikube
minikube start

# install istio-control plane on 
istioctl install --set profile=default -y

# enable ingress
minikube addons enable ingress

# enable istio-injection
kubectl label namespace default istio-injection=enabled
```

## Download istio samples and installing on local machine

```bash
curl -L https://istio.io/downloadIstio | sh -
```

### Adding ISTIOCTL to the path 

<img width="1351" alt="image" src="https://github.com/user-attachments/assets/42cac0b2-47ad-4149-9c39-27000dc33e21">

### Install istioctl


<img width="998" alt="image" src="https://github.com/user-attachments/assets/cddaa9d2-a0d5-466c-ba61-59d798c65e84">

## First demo application

```bash
kubectl apply -f samples/bookinfo/platform/kube/bookinfo.yaml
```
<img width="590" alt="image" src="https://github.com/user-attachments/assets/0048fac2-7481-4076-9d3f-f873948c5cca">


## Install Kiali

```bash
# run the addons folder to install kiali 
kubectl apply -f Documents/dev/kubernetes-demo/kode-kloud-istio/istio-1.23.1/samples/addons
```

<img width="1115" alt="image" src="https://github.com/user-attachments/assets/a1a9d028-be0d-4adb-aea5-a9edaa505a77">

```bash
# To check kiali is running or not
kubectl -n istio-system get svc kiali
```

<img width="575" alt="image" src="https://github.com/user-attachments/assets/ea53e625-9845-4955-9254-cb7e487b7592">

```bash
# open kiali dashboard
istioctl dashboard kiali
```

<img width="1114" alt="image" src="https://github.com/user-attachments/assets/2e0e721e-b0da-4982-812a-0fd55817c990">

----
-----


```bash
# create a gateway so we can hit the deployed application
kubectl apply -f Documents/dev/kubernetes-demo/kode-kloud-istio/istio-1.23.1/samples/bookinfo/networking/bookinfo-gateway.yaml
```
<img width="1209" alt="image" src="https://github.com/user-attachments/assets/57e31093-1c4a-45e7-8043-653ff752c98b">

----
----

```bash

# Get the port numbers 

# port-forward to hit it on localport 8080
kubectl port-forward svc/istio-ingressgateway -n istio-system 8080:80
```
<img width="1668" alt="image" src="https://github.com/user-attachments/assets/31ef2e93-5dec-4213-a93d-d35f7e9700de">

-----
-----
     