import AuthConfig from '../../auth_config.json'

export const environment = {
  production: false,
  auth: {
    domain: AuthConfig.domain,
    clientId: AuthConfig.clientId,
    redirectUri: window.location.origin
  }
};
