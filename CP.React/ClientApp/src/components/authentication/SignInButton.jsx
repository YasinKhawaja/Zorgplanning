import { useMsal } from "@azure/msal-react";
import { Button } from "@mui/material";
import React from "react";
import { loginRequest } from "./authConfig";

function handleLogin(instance) {
  instance.loginRedirect(loginRequest).catch((e) => {
    console.error(e);
  });
}

/**
 * Renders a button which, when selected, will open a popup for login
 */
export const SignInButton = () => {
  const { instance } = useMsal();

  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogin(instance)}
    >
      Sign In
    </Button>
  );
};
