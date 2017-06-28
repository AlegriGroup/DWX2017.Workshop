# DWX2017.Workshop

Erreichbar unter: 
> http://bit.ly/DWX17-Workshop-Code2Prod

## Requirements

- Visual Studio 2017 - aktuelle Updates
- Account bei [Visual Studio Team Services](https://www.visualstudio.com/team-services/) (ist kostenlos, inkl. 240 Buildminuten)
- Account bei [Azure](https://azure.microsoft.com/de-de/free/) (ist kostenlos, 170€ Trial ist inklusive)
- [kubectl (Kubernetes Control)](https://kubernetes.io/docs/tasks/tools/install-kubectl/)
- [Azure CLI 2.0](https://docs.microsoft.com/de-de/cli/azure/install-azure-cli)
- [Docker (for Windows)](https://docs.docker.com/docker-for-windows/install/)

Optional:

- Visual Studio Code (oder ein anderer, bequemer Editor mit YAML Unterstützung)

## Setup Container Registry
Create an Azure Contaier Registry:
![IMG_1_Registry.png]
![IMG_2_Registry.png]


## Setup Kubernetes Cluster
Execute the [script](CreateCluster.ps1) 