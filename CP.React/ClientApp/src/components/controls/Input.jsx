import { TextField } from "@mui/material";
import React from "react";

export default function Input(props) {
  const { error = null, label, name, onChange, value, ...other } = props;
  return (
    <TextField
      label={label}
      name={name}
      onChange={onChange}
      value={value}
      variant="outlined"
      {...(error && { error: true, helperText: error })}
      {...other}
    ></TextField>
  );
}
