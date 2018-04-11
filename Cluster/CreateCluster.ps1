$nameSuffix = "mka" # A unique suffix for naming

$RESOURCEGROUP="code2prod"
$LOCATION="westeurope"
$DNSPREFIX="demo-c2p-$nameSuffix"
$CLUSTERNAME="demo-c2p-$nameSuffix-cluster"

$DOCKER_REGISTRY_SERVER ="code2prodhub.azurecr.io" # Your docker registry
$DOCKER_USER="code2prodhub.azurecr.io"             # Your docker registry user
$DOCKER_PASSWORD="*****"                           # Your docker registry password
$DOCKER_EMAIL="mail@me.de"                         # Email

$AzureSubscriptionId = "<the id of your subscription>"

# Login to your Azure subscription
az login 
az account set --subscription $AzureSubscriptionId

Write-Host "Create Kubernetes cluster"
az group create --name=$RESOURCEGROUP --location=$LOCATION
az acs create --orchestrator-type=kubernetes --resource-group $RESOURCEGROUP --name=$CLUSTERNAME --dns-prefix=$DNSPREFIX --generate-ssh-keys

Write-Host "Cluster created. Wait for the Nodes to spin up..."
pause

Write-Host "Connect to Cluster"
az acs kubernetes get-credentials --resource-group=$RESOURCEGROUP --name=$CLUSTERNAME

# You need the following output to connect VSTS to your cluster
Get-Content "$env:USERPROFILE\.kube\config"

pause

Write-Host "see nodes"
kubectl get nodes

pause

Write-Host "Configure private Azure Container Registry"
kubectl create secret docker-registry myregistrykey --docker-server=$DOCKER_REGISTRY_SERVER --docker-username=$DOCKER_USER --docker-password=$DOCKER_PASSWORD --docker-email=$DOCKER_EMAIL
pause

Start-Process  "http://localhost:8001/ui"
kubectl proxy
# Now refresh the browoser to see the kubernetes dashboard

