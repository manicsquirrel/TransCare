import AuthConfig from '../../auth_config.json'

export const environment = {
  production: true,
  auth: {
    domain: AuthConfig.domain,
    clientId: AuthConfig.clientId,
    redirectUri: window.location.origin
  }
};
