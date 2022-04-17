import { useMsal } from "@azure/msal-react";
import { Button } from "@mui/material";
import React from "react";

function handleLogout(instance) {
  instance.logoutRedirect().catch((e) => {
    console.error(e);
  });
}

/**
 * Renders a button which, when selected, will open a popup for logout
 */
export const SignOutButton = () => {
  const { instance } = useMsal();

  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogout(instance)}
    >
      Sign Out
    </Button>
  );
};
