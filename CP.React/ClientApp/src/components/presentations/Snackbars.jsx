import { Alert, Snackbar } from "@mui/material";
import React from "react";

export function SuccessSnackbar(props) {
  return (
    <Snackbar open={props.open} autoHideDuration={6000} onClose={props.onClose}>
      <Alert onClose={props.onClose} severity="success">
        {props.message}
      </Alert>
    </Snackbar>
  );
}
