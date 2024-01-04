{{- define "libchart.secretProviderClass" }}
apiVersion: secrets-store.csi.x-k8s.io/v1
kind: SecretProviderClass
metadata:
  name: "{{ .Release.Name }}-workload-identity"
spec:
  provider: azure
  parameters:
    usePodIdentity: "false"
    useVMManagedIdentity: "false"          
    clientID: {{ .Values.entra.managedIdentityClientId }}
    keyvaultName: {{ .Values.keyvaultName }}
    objects:  |
      array:
        - |
          objectName: "AzureAd--ClientSecret"
          objectType: secret
    tenantId: {{ .Values.entra.tenantId }}
  secretObjects: 
  - secretName: {{ .Release.Name }}-secrets
    data:
     - key: "AzureAd--ClientSecret"
       objectName: "AzureAd--ClientSecret"
    type: Opaque
{{ end -}}