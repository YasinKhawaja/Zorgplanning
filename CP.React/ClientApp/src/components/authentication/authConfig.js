export const msalConfig = {
  auth: {
    clientId: "d127c753-6d90-4ebe-9aaf-eab0f93094a7",
    authority:
      "https://login.microsoftonline.com/fc699687-50ce-4e72-b09d-0f2d9c7b725c",
    redirectUri: "https://localhost:44428/",
  },
  cache: {
    cacheLocation: "sessionStorage", // This configures where your cache will be stored
    storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
  },
};

// Add scopes here for ID token to be used at Microsoft identity platform endpoints.
export const loginRequest = {
  scopes: ["User.Read"],
};

// Add the endpoints here for Microsoft Graph API services you'd like to use.
export const graphConfig = {
  graphMeEndpoint: "https://graph.microsoft.com/v1.0/me",
};
